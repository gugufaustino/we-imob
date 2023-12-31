﻿using Domain.Interface.Models;
using System;

namespace Domain.Models
{
    public abstract class EntityDateKey : EntityKey, IEntityDates
    {
        protected EntityDateKey()
        {

        }

        public string UsuarioInclusao { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public DateTime DthInclusao { get; set; }
        public DateTime DthAtualizacao { get; set; }

    }
}
