using DevIO.Business.Core.Models;
using DevIO.Business.Data;
using DevIO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> Dbset;


        protected Repository()
        {
            Db = new MeuDbContext();
            Dbset = Db.Set<TEntity>();
         
        }


        public virtual async Task Adicionar(TEntity entity)
        {
            
             Dbset.Add(entity);
             await SaveChange();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            await SaveChange();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await Dbset.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await Dbset.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await Dbset.ToListAsync();
        }

        public  virtual async Task Remover(Guid id)
        {
            Db.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
            await SaveChange();
        }

        public virtual async Task<int> SaveChange()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }

    }
}
