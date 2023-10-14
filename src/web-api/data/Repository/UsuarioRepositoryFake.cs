using Business.Interface.Repository;
using Business.Models;
using Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UsuarioRepositoryFake : IUsuarioRepository
    {
        public UsuarioRepositoryFake()
        {   

        }

        public Task<Usuario> Adicionar(Usuario entity)
        {
            return new Task<Usuario>(() => { return entity; });
        }

        Task IRepository<Usuario>.Adicionar(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task Editar(Usuario entity)
        {
            throw new NotImplementedException();
        }
         

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> Listar(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuario>> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Obter(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remover(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Existe(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObterUsuarioLogon(string email)
        {
            throw new NotImplementedException();
        }
    }
}
