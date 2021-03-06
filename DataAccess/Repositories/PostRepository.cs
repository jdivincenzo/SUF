﻿using DataAccess.Core;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Repositories
{
    public class PostRepository : AbstractRepository<Post>, IPostRepository, IDisposable
    {
        #region Constructores
        public PostRepository(Core.IBaseContext context) : base(context) { }

        #endregion

        #region IPostRepository methods
        public IEnumerable<Post> GetNearbyPosts(double lat, double lon, double distance)
        {
            return context.Posts.Include(p=>p.Pictures).Where(p =>BaseContext.CalculateDistance(lat, lon, p.Lat, p.Lon) <= distance);
        }

        public Post Get(int id)
        {
            return context.Posts.Include(p => p.Pictures).Where(p => p.PostId == id).FirstOrDefault();
        }

        #endregion
    }
}
