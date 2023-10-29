using Domain.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IEmpresaRepository : IDisposable      
    {
        Task Adicionar(Empresa entity);

        Task<bool> Existe(Expression<Func<Empresa, bool>> predicate);
    }
}