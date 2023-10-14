using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interface.Services
{
   public interface IEnderecoService : IDisposable
    {
        Task Adicionar(Endereco endereco);
        Task Adicionar(List<Endereco> lstEnderecos);
        Task Editar(int id, Endereco endereco);        
        Task Excluir(int id);        
    }
}
