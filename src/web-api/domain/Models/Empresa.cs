namespace Domain.Models
{
    public class Empresa : EntityKey
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        //public Agencia Agencia { get; set; }
    }
}
