using System.Collections.Generic;

namespace Domain.Models
{
    public class Organizacao : EntityKey
    {
        public Organizacao()
        {

        }
        /// <summary>
        /// Constroi  Tipo AgenteAutonomo 
        /// </summary>
        /// <param name="nome"></param>
        public Organizacao(string nome)
        {
            Nome = nome;
            TipoCadastro = TipoOrganizacaoEnum.AgenteAutonomo;
        }

		/// <summary>
		/// Constroi Tipo Imobiliaria
		/// </summary>
		public Organizacao(string razaoSocial, string cnpj, string nomeFantasia, string instagram, string email)  
        {
           
            Nome = nomeFantasia;
            Instagram = instagram;
            TipoCadastro = TipoOrganizacaoEnum.Imobiliaria;

            Empresa = new Empresa
            {
                RazaoSocial = razaoSocial,
                Cnpj = cnpj,
                NomeFantasia = nomeFantasia,
                Email = email
            };

        }

        public string Nome { get; set; }
        public string? Instagram { get; set; }
        public TipoOrganizacaoEnum TipoCadastro { get; set; }
        public TipoSituacaoEnum TipoSituacao { get; set; }
        public Empresa Empresa { get; set; }
        public IEnumerable<Usuario> Usuario { get; set; }
    }

    public enum TipoOrganizacaoEnum
    {
        AgenteAutonomo = 1,
        Imobiliaria = 2,
    }
}
