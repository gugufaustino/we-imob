using Business.Models;
using System.Threading.Tasks;

namespace Business.Interface.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterUsuarioLogon(string email);
    }
}
