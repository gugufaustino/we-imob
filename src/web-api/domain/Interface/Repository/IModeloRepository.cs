using Business.Models;
using Business.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Interface.Repository
{
    public interface IModeloRepository : IDisposable
    {
        Task<List<Modelo>> Pesquisar(CatalogoModeloFilter filtro);
        Task<int> RemoverModeloTipoCasting(IEnumerable<ModeloTipoCasting> modeloTipoCastings);
        Task<int> AdicionarModeloTipoCasting(IEnumerable<ModeloTipoCasting> novosModeloTipoCastings);
        Task RemoverPorModeloTipoCasting(int idModelo);

        Task<Modelo> ObterPorId(int id);
        Task Adicionar(Modelo modelo);
        Task Editar(Modelo entity);
        Task Remover(Modelo entity); 
        Task<bool> Existe(Expression<Func<Modelo, bool>> predicate);
    }
}