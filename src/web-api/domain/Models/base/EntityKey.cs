using Business.Interface.Models;

namespace Business.Models
{
    public abstract class EntityKey : IEntityKey
    {
        protected EntityKey()
        {

        }

        public int Id { get; set; }

    }
}
