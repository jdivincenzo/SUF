using Model.Entities;
using System;

namespace DataAccess.Repositories.Interfaces
{
    public interface IPictureRepository : IAbstractRepository<Picture>, IDisposable
    {
    }
}
