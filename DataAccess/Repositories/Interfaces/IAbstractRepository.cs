using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface IAbstractRepository<TEntity> : IDisposable
    {
        IEnumerable<TEntity> GetAll();
    }
}
