using Model.Entities;
using System;


namespace DataAccess.Repositories
{
    public class SeedRepository : AbstractRepository<Post>, IDisposable
    {
        #region Constructores
        public SeedRepository(Core.BaseContext context) : base(context) { }

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
