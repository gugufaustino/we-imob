using System;

namespace Domain.Models
{
    public class Endereco : EntityKey
    {
		public string Cep { get; set; }

		public string Logradouro { get; set; }

		public int? Numero { get; set; }

		public string Complemento { get; set; }

		public string Bairro { get; set; }

		public string NomeMunicipio { get; set; }

		public string SiglaUf { get; set; }

		public double? Latitude { get; set; }

		public double? Longitude { get; set; }
	}
}
