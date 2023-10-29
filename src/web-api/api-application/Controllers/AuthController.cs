using ApiApplication.Extensions;
using ApiApplication.ViewModel;
using AutoMapper;
using Domain.Interface;
using Domain.Interface.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;

namespace ApiApplication.Controllers
{
	[AllowAnonymous]
    [Route("api")]
    public class AuthController : BaseApiController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public AuthController(IBroadcaster broadcaster,
             SignInManager<IdentityUser> signInManager,
             UserManager<IdentityUser> userManager,
             IOptions<AppSettings> appSettings,
             IUsuarioService usuarioService, IMapper mapper) : base(broadcaster)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpPost("registrar-conta")]
        public async Task<ActionResult> Registrar(AccountViewModel usuarioModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuarioo = _mapper.Map<Usuario>(usuarioModel);
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {

                    await _usuarioService.Registrar(usuarioo);
                    if (_broadcaster.HasNotifications()) return CustomResponse(usuarioModel);

                    IdentityUser identityUser = new()
                    {
                        UserName = usuarioModel.Email,
                        Email = usuarioModel.Email,
                        EmailConfirmed = true
                    };

                    var create = await _userManager.CreateAsync(identityUser, usuarioModel.Password);
                    if (!create.Succeeded)
                        ToTransmit(create.Errors);

                    else
                    {
                        var addClaims = await _userManager.AddClaimsAsync(identityUser, new List<Claim>
                        {
                            new Claim("MODELO", "CONSULTAR, INSERIR, EDITAR, DELETAR"),
                            new Claim("USUARIO", "CONSULTAR, INSERIR-AGENDA")
                        });
                        if (!addClaims.Succeeded)
                            ToTransmit(addClaims.Errors);
                    }
                    if (!_broadcaster.HasNotifications())
                    {
                        await _signInManager.SignInAsync(identityUser, isPersistent: false);

                        usuarioModel.Password = string.Empty;
                        usuarioModel.ConfirmPassword = string.Empty;
                        var dataResult = GerarJwt(usuarioModel.Email).Result;

                        scope.Complete();
                        return CustomResponse(dataResult);
                    }

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    ToTransmit(ex.Message);
                }
            }
            return CustomResponse(usuarioModel);
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginViewModel login)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent: false, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                return CustomResponse(await GerarJwt(login.Email));
            }
            if (result.IsLockedOut)
            {
                ToTransmit("Usuário bloqueado");
                return CustomResponse(login);
            }

            ToTransmit("Usuário ou senha inválidos");
            return CustomResponse(login);
        }


        private async Task<LoginResponseViewModel> GerarJwt(string email)
        {
            var usuario = await _usuarioService.ObterUsuarioLogon(email);
            var identityUser = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(identityUser);
            var userRoles = await _userManager.GetRolesAsync(identityUser);

            foreach (var role in userRoles)
            {
                claims.Add(new Claim("role", role));
            }


            claims.Add(new Claim(nameof(Usuario.Apelido), usuario.Apelido ?? ""));
            claims.Add(new Claim(nameof(Usuario.CPF), usuario.CPF));
            claims.Add(new Claim(nameof(Usuario.Telefone), usuario.Telefone ?? ""));
            claims.Add(new Claim(nameof(Usuario.Imagem), usuario.Imagem ?? ""));
            claims.Add(new Claim(nameof(Usuario.Abreviatura), usuario.Abreviatura() ?? ""));
            var claimsUserToken = new List<Claim>(claims);

            //claims usadas pelo Identity, essas não precisam ficar publicas no userToken
            claims.Add(new Claim(nameof(Usuario.IdOrganizacao), usuario.IdOrganizacao.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, usuario.Nome));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, identityUser.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, identityUser.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.ExpiracaoMinutos),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

                Subject = identityClaims
            });

            var encoded = tokenHandler.WriteToken(token);


            var response = new LoginResponseViewModel
            {
                AccessToken = encoded,
                UserToken = new UserTokenViewModel
                {
                    Claims = claimsUserToken.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value }),
                    Email = identityUser.Email,
                    Nome = usuario.Nome,
                    TipoCadastro = usuario.TipoCadastro,
                    AgenciaTipoSituacao = usuario?.Organizacao?.TipoSituacao,
                    Agencia = usuario?.Organizacao?.TipoSituacao == TipoSituacaoEnum.Ativado ? usuario?.Organizacao : default(AgenciaViewModel),
                }
            };

            return response;
        }
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
