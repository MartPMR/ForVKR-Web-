using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Data
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Data { get; }

        TEntity Select(object ID);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
