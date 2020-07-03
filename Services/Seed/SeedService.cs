using DataAccess.Core;
using DataAccess.Repositories;
using Model.Entities;
using Services.Common;
using Services.PostServices.ExternalModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Services.Seed
{
    public class SeedService: Services.AbstractService.AbstractService
    {
        #region constructors
        public SeedService() : base() { }
        public SeedService(DataAccess.Core.BaseContext context) : base(context) { }
        public SeedService(DataAccess.Core.BaseContext context, IFileUtils fileUtils) : base(context, fileUtils) { }

        #endregion

        public void Seed()
        {
            using (var ctx = NewContext())
            {
                new SeedRepository(ctx).Seed();
            }
        }
    }
}
