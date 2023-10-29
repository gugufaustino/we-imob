using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using FluentValidation;
using System.Threading.Tasks;

namespace Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IAgenciaService _agenciaService;
        private readonly IUsuarioRepository _repository;
        private readonly IUser _user;
        private readonly IValidator<Usuario> _validator;
        public UsuarioService(IUsuarioRepository repository,
                                IBroadcaster broadcaster,
                                IAgenciaService agenciaService,
                                IUser user,
                                IValidator<Usuario> validator)
            : base(broadcaster)
        {
            _repository = repository;
            _agenciaService = agenciaService;
            _user = user;
            _validator = validator;
        }

        public async Task Registrar(Usuario usuario)
        {
            if (!ExecuteValidations(_validator, usuario)) return;

            if (usuario.TipoCadastro == TipoCadastroEnum.AgenteAutonomo)
            {
                var agencia = new Agencia(usuario.Nome)
                {
                    TipoSituacao = TipoSituacaoEnum.Ativado
                };

                await _agenciaService.Adicionar(agencia);
                usuario.Agencia = agencia;
            }

            await _repository.Adicionar(usuario);

        }

        public async Task AdicionarAgenciaEmpresa(Agencia agenciaEmpresa)
        {

            agenciaEmpresa.TipoSituacao = TipoSituacaoEnum.EmElaboracao;

            if (await _agenciaService.AdicionarAgenciaEmpresa(agenciaEmpresa) == 0) return;


            var usuario = await _repository.Obter(i => i.Email.ToLower() == _user.Email.ToLower());
            usuario.Agencia = agenciaEmpresa;

            await _repository.Editar(usuario);


        }

        public async Task<Usuario> ObterUsuarioLogon(string email)
        {
            return await _repository.ObterUsuarioLogon(email);

        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
