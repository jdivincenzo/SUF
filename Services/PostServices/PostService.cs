using DataAccess.Core;
using DataAccess.Repositories;
using Model.Entities;
using Services.PostServices.ExternalModel;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Services.PostServices
{
    public class PostService
    {
        public IEnumerable<GetNearbyPostsReturn> GetNearby(GetNearbyPostsInvoke invoke)
        {
            using (var ctx = new DataAccess.Core.AppContext())
            {
                IList<GetNearbyPostsReturn> ret = new List<GetNearbyPostsReturn>();
                var posts = new PostRepository(ctx).GetNearbyPosts(invoke.Lat, invoke.Lon, invoke.Distance);
                foreach (var p in posts)
                    ret.Add(new GetNearbyPostsReturn { Id = p.PostId, Lat = p.Lat, Lon = p.Lon });

                return ret;
            }
        }
    }
}
