using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface.Services
{
   public interface IModeloService : IDisposable
    {
        Task Adicionar(Modelo modelo);
        Task Editar(int id, Modelo modelo);        
        Task Excluir(int id);        
    }
}
