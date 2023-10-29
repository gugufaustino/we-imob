using Domain.Interface;
using Domain.Interface.Repository;
using Domain.Interface.Services;
using Domain.Models;
using FluentValidation;

namespace Services
{
	public class OrganizacaoService : BaseService, IOrganizacaoService
    {

        private readonly IOrganizacaoRepository _repository;
        private readonly IEmpresaRepository _repositoryEmpresa;
        private readonly IValidator<Empresa> _validator;
        public OrganizacaoService(IBroadcaster broadcaster,
                                IOrganizacaoRepository AgenciaRepository,
                                IEmpresaRepository repositoryEmpresa,
                                IValidator<Empresa> validator)
            : base(broadcaster)
        {
            _repository = AgenciaRepository;
            _repositoryEmpresa = repositoryEmpresa;
            _validator = validator;
        }

        public async Task<int> AdicionarAgenciaEmpresa(Organizacao organizacao)
        {
            
            if (!ExecuteValidations(_validator, organizacao.Empresa)) return 0;

            await _repository.Adicionar(organizacao);
            return 1;
        }

        public async Task Adicionar(Organizacao agencia )
        {
            await _repository.Adicionar(agencia);            
        }

        public async Task Editar(int Id, Organizacao agencia)
        {
            var entity = await _repository.ObterPorId(Id);
            
             

            await _repository.Editar(entity);
        }
 

        public async Task Excluir(int id)
        {
            var entity = await _repository.ObterPorId(id);
           
            await _repository.Remover(entity);
        }
 

        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
