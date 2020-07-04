using DataAccess.Repositories.Interfaces;
using Model.Entities;
using System;

namespace DataAccess.Repositories
{
    public class PictureRepository : AbstractRepository<Picture>, IPictureRepository, IDisposable
    {
        #region Constructores
        public PictureRepository(Core.BaseContext context) : base(context) { }

        #endregion
    }
}
