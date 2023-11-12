namespace Domain.Models
{
    public class Empresa : EntityKey
    {
        public string NomeFantasia { get; set; } = string.Empty;
        public string RazaoSocial { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //public Organizacao Organizacao { get; set; }
    }
}
