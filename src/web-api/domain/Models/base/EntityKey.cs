using Domain.Interface.Models;

namespace Domain.Models
{
    public abstract class EntityKey : IEntityKey
    {
        protected EntityKey()
        {

        }

        public int Id { get; set; }

    }
}
