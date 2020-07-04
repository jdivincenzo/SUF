using Model.Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IPostRepository : IAbstractRepository<Post>, IDisposable
    {
        IEnumerable<Post> GetNearbyPosts(double lat, double lon, double distance);
    }
}
