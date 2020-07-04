using System;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IAbstractRepository<TEntity> : IDisposable
    {
        IEnumerable<TEntity> GetAll();
        //TEntity New();// create instancies and add to context automatically
        TEntity GetById(int id);
    }
}
