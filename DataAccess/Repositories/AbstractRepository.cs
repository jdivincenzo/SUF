using DataAccess.Core;
using DataAccess.Repositories.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public abstract class AbstractRepository<TEntity> : IAbstractRepository<TEntity>, IDisposable where TEntity : class, new()
    {
        #region fields

        internal Core.AppContext context;
        private bool disposed = false;

        #endregion

        #region Constructors
        public AbstractRepository(Core.AppContext context)
        {
            this.context = context;
        }

        #endregion

        #region IAbstractRepository methods
        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        // create instancies and add to context automatically
        //public TEntity New()
        //{
        //    TEntity obj = new TEntity();
        //    context.Set<TEntity>().Add(obj);
        //    return obj;
        //}

        #endregion

        #region IDisposable mothods
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
