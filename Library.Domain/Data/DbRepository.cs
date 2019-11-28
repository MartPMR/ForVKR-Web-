using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Library.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DbContext Context;

        public IQueryable<TEntity> Data
        {
            get { return Context.Set<TEntity>().AsQueryable(); }
        }

        public DbRepository(DbContext DBContext)
        {
            this.Context = DBContext;
        }


        public TEntity Select(object ID)
        {
            return Context.Set<TEntity>().Find(ID);
        }

        public void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            //if (Context.Entry<TEntity>(entity).State == EntityState.Detached)
            //{
            //    Context.Set<TEntity>().Attach(entity);
            //    Context.Entry<TEntity>(entity).State = EntityState.Modified;
            //}

            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }
    }
}
