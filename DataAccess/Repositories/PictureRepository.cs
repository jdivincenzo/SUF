using DataAccess.Core;
using DataAccess.Repositories.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class PictureRepository : AbstractRepository<Picture>, IPictureRepository, IDisposable
    {
        #region Constructores
        public PictureRepository(Core.BaseContext context) : base(context) { }

        #endregion
    }
}
