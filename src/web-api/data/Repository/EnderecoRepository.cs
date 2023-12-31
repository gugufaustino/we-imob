using Domain.Interface.Repository;
using Domain.Models;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;

namespace Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext appDbContext, IUser user)  : base(appDbContext, user)
        {
        }
  
        public async override Task<List<Endereco>> ListarTodos()
        {
            return await Db.Endereco.AsNoTracking()                            
                            .ToListAsync();
        }

        public async override Task<Endereco> ObterPorId(int id)
        {
            return await Db.Endereco
                            .FirstAsync(i => i.Id == id);
        }
    }
}
