using DataAccess.Core;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace DataAccess.Repositories
{
    public class SeedRepository : AbstractRepository<Post>, IDisposable
    {
        #region Constructores
        public SeedRepository(Core.DevContext context) : base(context) { }

        #endregion

        #region IPostRepository methods
        public void Seed()
        {
            CleanDB();
            context.Seed();
        }

        private void CleanDB()
        {
            context.Posts.RemoveRange(context.Posts);
            context.Pictures.RemoveRange(context.Pictures);
            context.SaveChanges();
        }
        #endregion
    }
}
