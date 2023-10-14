using Business.Interface.Repository;
using Business.Models;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Interface;

namespace Data.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IAgenciaEmpresaRepository  
    {
        public EmpresaRepository(AppDbContext appDbContext, IUser user) : base(appDbContext, user)
        {
        }
   
    }
}
