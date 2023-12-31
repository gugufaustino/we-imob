using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface.Services
{
   public interface IOrganizacaoService : IDisposable
    {
        Task<int> AdicionarAgenciaEmpresa(Organizacao agencia);
        Task Adicionar(Organizacao lstAgencias);
        Task Editar(int id, Organizacao agencia);        
        Task Excluir(int id);        
    }
}
