using DataAccess.Core;
using DataAccess.Repositories;
using Model.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Services.PictureServices
{
    public class PictureServices: Services.AbstractService.AbstractService
    {
        #region constructors
        public PictureServices() : base() { }
        public PictureServices(DataAccess.Core.AppContext context) : base(context) { }

        #endregion
    }
}
