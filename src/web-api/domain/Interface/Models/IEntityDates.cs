using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Models
{
    public interface IEntityDates
    {
        public string UsuarioInclusao { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public DateTime DthInclusao { get; set; }
        public DateTime DthAtualizacao { get; set; }
    }
}
