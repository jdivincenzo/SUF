using DataAccess.Core;
using DataAccess.Repositories.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace DataAccess.Repositories
{
    public class PostRepository : AbstractRepository<Post>, IPostRepository, IDisposable
    {
        #region Constructores
        public PostRepository(Core.AppContext context) : base(context) { }

        #endregion

        #region IPostRepository methods
        public IEnumerable<Post> GetNearbyPosts(double lat, double lon, double distance)
        {
            return context.Set<Post>().Where(p => context.CalculateDistance(lat, lon, p.Lat, p.Lon) <= distance);
        }

        #endregion
    }
}
