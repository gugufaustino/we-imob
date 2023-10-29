using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterUsuarioLogon(string email);
    }
}
