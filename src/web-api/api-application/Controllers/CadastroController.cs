using ApiApplication.Extensions;
using ApiApplication.ViewModel;
using AutoMapper;
using Domain.Interface;
using Domain.Interface.Repository;
using Domain.Interface.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Util;


namespace ApiApplication.Controllers
{
	[Route("api/cadastro")]
    public class CadastroController : BaseApiController
    {

        const string Permissao = "USUARIO";

        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioService _service;
        private readonly IOrganizacaoService _serviceOrganizacao;
        private readonly IMapper _mapper;

        public CadastroController(IUsuarioRepository repository,
                                  IUsuarioService service,
                                  IMapper mapper,
                                  IBroadcaster broadcaster,
                                  IOrganizacaoService serviceOrganizacao
                                  )
           : base(broadcaster)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
            _serviceOrganizacao = serviceOrganizacao;
        }

        [HttpGet]
		[AllowAnonymous]
		public async Task<IEnumerable<UsuarioViewModel>> Listar()
        {
            var lista = await _repository.ListarTodos();
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(lista);
        }


        [HttpGet("listar/{nome}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<IEnumerable<UsuarioViewModel>> ListarPorNome(string nome)
        {
            var lista = await _repository.Listar(e => e.Nome == nome);
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(lista);
        }


        [HttpGet("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<UsuarioViewModel>> Obter(int id)
        {
            var usuario = await _repository.ObterPorId(id);
            if (usuario == null) return NotFound();

            return _mapper.Map<UsuarioViewModel>(usuario);
        }

        [HttpGet("obter-apelido/{email}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<UsuarioViewModel>> ObterApelido(string email)
        {

            var result = await _repository.Listar(e => e.Email == email);
            var usuario = result.FirstOrDefault();
            if (usuario == null) return NotFound();

            return CustomResponse(new { apelido = usuario.Apelido });
        }

       
        [HttpPost]
        [ClaimsAuthorize(Permissao)]
        public  Task<ActionResult> Adicionar(EmpresaViewModel empresaModel)
        {
            throw new System.Exception();
            //if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            //await _service.AdicionarAgencia(new Agencia(empresaModel.RazaoSocial, 
            //                                            empresaModel.Cnpj,
            //                                            empresaModel.NomeFantasia,
            //                                            empresaModel.Instagram,
            //                                            empresaModel.Email));

            //return CustomResponse(empresaModel);
        }

        [HttpPost("adicionar-agencia")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult> AdicionarAgenciaEmpresa(EmpresaViewModel empresaModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.AdicionarAgenciaEmpresa(new Organizacao(empresaModel.RazaoSocial,
                                                        empresaModel.Cnpj.RemoverMascara(),
                                                        empresaModel.NomeFantasia,
                                                        empresaModel.Instagram,
                                                        empresaModel.Email));

            return CustomResponse(empresaModel);
        }

        
        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, UsuarioViewModel usuarioViewModel)
        {

            if (id != usuarioViewModel.Id) return BadRequest();
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            //TODO implementar aqui service atualização da entidade

            return CustomResponse();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            UsuarioViewModel usuarioViewModel = new() { Id = id };
            if (usuarioViewModel.Nome == null) return NotFound();

            return CustomResponse();
        }
    }
}
