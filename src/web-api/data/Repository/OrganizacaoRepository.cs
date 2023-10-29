using Domain.Interface;
using Domain.Interface.Repository;
using Domain.Models;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class OrganizacaoRepository : Repository<Organizacao>, IOrganizacaoRepository
    {
        public OrganizacaoRepository(AppDbContext appDbContext, IUser user) : base(appDbContext, user)
        {
        }
  
        public async override Task<List<Organizacao>> ListarTodos()
        {
            return await Db.Organizacao.AsNoTracking()                            
                            .ToListAsync();
        }

        public async override Task<Organizacao> ObterPorId(int id)
        {
            return await Db.Organizacao                            
                            .FirstAsync(i => i.Id == id);
        } 
       
    }
}
