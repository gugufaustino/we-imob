using Business.Interface;
using Business.Interface.Repository;
using Business.Models;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext appDbContext, IUser user) : base(appDbContext, user)
        {

        }

        public Task<Usuario> ObterUsuarioLogon(string email)
        {
            return this.DbSet.Include(i => i.Agencia)
                              .ThenInclude(ae => ae.Empresa)
                              .AsNoTracking()
                              .SingleAsync(i => i.Email.ToLower() == email.ToLower());
        }
    }
}
