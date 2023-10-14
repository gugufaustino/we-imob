using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Models
{
    public interface IEntityState
    {
        public DateTime DthInclusao { get; set; }
        public DateTime DthAtualizacao { get; set; }
    }
}
