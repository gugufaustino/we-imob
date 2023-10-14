using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Services
{
    public interface IUsuarioService : IDisposable
    {
        Task Registrar(Usuario usuario);
        Task<Usuario> ObterUsuarioLogon(string email);

        Task AdicionarAgenciaEmpresa(Organizacao agencia);
    }
}
