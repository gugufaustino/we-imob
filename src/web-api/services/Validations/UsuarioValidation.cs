using Domain.Interface.Repository;
using Domain.Models;
using FluentValidation;

namespace Business.Services.Validations
{
	public class UsuarioValidation : AbstractValidator<Usuario>
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioValidation(IUsuarioRepository repository)
        {
            this._repository = repository;

            RuleFor(u => u.Nome)
                .NotNull()
                .NotEmpty()
                .Length(2, 100);

            RuleFor(u => u.Password)
                .NotNull()
                .NotEmpty();

            RuleFor(u => u.Password).Equal(u => u.ConfirmPassword)
                .WithMessage("O campo senha não confere, não está igual a confirmação.");

            RuleFor(u => u.Nome).Must(prop => prop.Contains(" "))
               .WithMessage("Escreva o nome completo.");

            RuleFor(u => u.CPF).Must(CpfUnico)
                .WithMessage("Este CPF já está cadastrado.");

            RuleFor(u => u.Telefone).Must(TelefoneUnico)
                .WithMessage("Este Telefone já está sendo utilizado.");
            
        }

        private bool CpfUnico(Usuario usuario, string cpf)
        {
            return !_repository.Existe(i => i.CPF == cpf).Result;
        }
        private bool TelefoneUnico(Usuario usuario, string telefone)
        {
            return !_repository.Existe(i => i.Telefone == telefone).Result;
        }
    }
}
