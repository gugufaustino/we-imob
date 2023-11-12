using Domain.Interface.Repository;
using Domain.Models;
using FluentValidation;

namespace Business.Services.Validations
{
	public class EmpresaValidation : AbstractValidator<Empresa>
    {
        private readonly IEmpresaRepository _repository;

        public EmpresaValidation(IEmpresaRepository repository)
        {
            this._repository = repository;
             
            RuleFor(u => u.Email).Must(EmailUnico)
                .WithMessage("Este E-mail já está sendo utilizado.");

            RuleFor(u => u.Cnpj).Must(CnpjUnico)
                .WithMessage("Este CNPJ já está cadastrado.");
            
        }

        private bool EmailUnico(string cpf)
        {
            return !_repository.Existe(i => i.Email == cpf).Result;
        }
        private bool CnpjUnico(string telefone)
        {
            return !_repository.Existe(i => i.Cnpj == telefone).Result;
        }
    }
}
