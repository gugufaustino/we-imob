using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class Modelo : EntityDateKey
    {
        public int IdEndereco { get; set; }
        public TipoSituacaoEnum IdTipoSituacao { get; set; }
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Rg { get; set; }
        public string CPF { get; set; }
        public string Diponibilidade { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }


        public int Altura { get; set; }
        public int Peso { get; set; }
        public int Manequim { get; set; }
        public int Sapato { get; set; }
        public CorOlhosEnum CorOlhos { get; set; }
        public CorCabeloEnum CorCabelo { get; set; }
        public TipoCabeloEnum TipoCabelo { get; set; }
        public TipoCabeloComprimentoEnum TipoCabeloComprimento { get; set; }

        public Endereco Endereco { get; set; }
        public TipoSituacao TipoSituacao { get; set; }
        public IEnumerable<ModeloTipoCasting> ModeloTipoCasting { get; set; }

        public string ImagemPerfilNome { get; set; }

        public int IdImobiliaria { get; set; }
        public Imobiliaria Imobiliaria { get; set; }

    }

    public enum TipoCastingEnum
    {
        Comercial = 1,
        Eventos = 2,
        Fashion = 3,
        FashionComercial = 4,
        Atoratriz = 5
    }

    public enum CorOlhosEnum
    {
        Azul = 1,
        Verde = 2,
        CastanhoClaro = 3,
        CastanhoEscuro = 4,
        Preto = 5,
    }

    public enum CorCabeloEnum
    {
        Preto = 1,
        CastanhoClaro = 2,
        CastanhoEscuro = 3,
        Grisalho = 4,
        LoiroClaro = 5,
        LoiroEscuro = 6,
        Ruivo = 7,
        Mechas = 8,
        Colorido = 9,
    }

    public enum TipoCabeloEnum
    {
        Cacheado = 1,
        Liso = 2,
        Ondulado = 3,
        Crespo = 4
    }

    public enum TipoCabeloComprimentoEnum
    {
        Raspado = 1,
        Curto = 2,
        Medio = 3,
        Longo = 4,
        MuitoLongo = 5
    }
}
