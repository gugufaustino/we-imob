using System.ComponentModel.DataAnnotations;

namespace ApiApplication.ViewModel
{
    public class UsuarioViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Telefone { get; set; }
        
        [Required]
        public string CPF { get; set; }

        [Required]
        public string Email { get; set; }

        public string Imagem { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public int TipoCadastro { get; set; }



    }
}
