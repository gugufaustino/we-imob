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
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository  
    {
        public EmpresaRepository(AppDbContext appDbContext, IUser user) : base(appDbContext, user)
        {
        }
   
    }
}
