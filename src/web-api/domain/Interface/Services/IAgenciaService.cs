using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface.Services
{
   public interface IAgenciaService : IDisposable
    {
        Task<int> AdicionarAgenciaEmpresa(Organizacao agencia);
        Task Adicionar(Organizacao lstAgencias);
        Task Editar(int id, Organizacao agencia);        
        Task Excluir(int id);        
    }
}
