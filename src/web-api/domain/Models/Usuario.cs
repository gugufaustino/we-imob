﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class Usuario : EntityKey
    {
        public string Nome { get; set; } = string.Empty;

		public string? Apelido { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string? Imagem { get; set; }
        public TipoCadastroEnum  TipoCadastro { get; set; }
        public int? IdOrganizacao { get; set; }
        public Organizacao Organizacao { get; set; }

        public string Abreviatura()
        {
            var arrNome = this.Nome.Trim().Split(' ');
            var primeira = arrNome[0].Substring(0, 1);
            var ultima = string.Empty;
            
            if(arrNome.Length > 1)
                ultima = arrNome.LastOrDefault().Substring(0, 1);             
            
            return (primeira + ultima).ToUpper();
        }

    } 

    public enum TipoCadastroEnum
    {
        AgenteAutonomo = 1,
        Empresa = 2,
    }
}
