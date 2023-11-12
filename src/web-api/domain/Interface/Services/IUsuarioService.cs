using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Services
{
    public interface IUsuarioService : IDisposable
    {
        Task Registrar(Usuario usuario);
        Task<Usuario> ObterUsuarioLogon(string email);

        Task AdicionarOrganizacaoEmpresa(Organizacao agencia);
    }
}
