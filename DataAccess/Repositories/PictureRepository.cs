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
    public class PictureRepository : AbstractRepository<Picture>, IPictureRepository, IDisposable
    {
        public PictureRepository(Core.AppContext context) : base(context) { }
    }
}
