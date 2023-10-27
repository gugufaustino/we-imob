using Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiApplication.ViewModel
{
    public class AccountViewModel
    {

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public TipoCadastroEnum TipoCadastro { get; set; }

    }

    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenViewModel UserToken { get; set; }
    }


    public class UserTokenViewModel
    {
        public IEnumerable<ClaimViewModel> Claims { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoCadastroEnum TipoCadastro { get; set; }
        public AgenciaViewModel Agencia { get; set; }
        public TipoSituacaoEnum? AgenciaTipoSituacao { get; set; }
    }

    public class AgenciaViewModel
    {
        public string NomeAgencia { get; set; }

        public static implicit operator AgenciaViewModel(Organizacao agencia)
            => new AgenciaViewModel { NomeAgencia = agencia.Nome };
    }
    public class EmpresaViewModel
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Instagram { get; set; }
        public string Email { get; set; }
    }

    public class ClaimViewModel
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
