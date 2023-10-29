using Domain.Interface;
using Domain.Interface.Models;
using Domain.Interface.Repository;
using Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntityKey ,  new()

    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IUser User;
        public Repository(AppDbContext db,
            IUser user)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
            User = user;                        
        }

        public async Task<List<TEntity>> Listar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> ListarTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> Obter(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }
        
        public virtual async Task<bool> Existe(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            if (entity.GetType().GetInterfaces().Any(t => t == typeof(IEntityDates)))
            {
                var castEntity = (entity as IEntityDates);
                
                castEntity.DthInclusao = DateTime.Now;
                castEntity.DthAtualizacao = DateTime.Now;
                castEntity.UsuarioInclusao = User.UserName;
                castEntity.UsuarioAtualizacao= User.UserName;
            }
            Db.Add(entity);
            await SaveChanges(); 
        }

        public virtual async Task Editar(TEntity entity)
        {
            if (entity.GetType().GetInterfaces().Any(t => t == typeof(IEntityDates)))
            {
                var castEntity = (entity as IEntityDates);
                castEntity.DthAtualizacao = DateTime.Now;
                castEntity.UsuarioAtualizacao = User.UserName;
            }

            Db.Update(entity);
            await SaveChanges();
        }


        public virtual async Task Remover(int id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges(); 
        }

        public virtual async Task Remover(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChanges();
        }


        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }


        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
