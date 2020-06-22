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

namespace Services.PostServices
{
    public class PostService: AbstractService
    {
        #region constructors
        public PostService() : base() { }
        public PostService(DataAccess.Core.AppContext context) : base(context) { }

        #endregion

        public IEnumerable<GetNearbyPostsReturn> GetNearby(GetNearbyPostsInvoke invoke)
        {
            using (var ctx = NewContext())
            {
                IList<GetNearbyPostsReturn> ret = new List<GetNearbyPostsReturn>();
                var posts = new PostRepository(ctx).GetNearbyPosts(invoke.Lat, invoke.Lon, invoke.Distance);
                foreach (var p in posts)
                    ret.Add(new GetNearbyPostsReturn { Id = p.PostId, Lat = p.Lat, Lon = p.Lon });

                return ret;
            }
        }

        public GetPostReturn GetPost(GetPostInvoke invoke)
        {
            using (var ctx = NewContext())
            {
                List<Post> posts = new PostRepository(ctx).GetAll().ToList();
                var post = new PostRepository(ctx).GetById(invoke.Id);
                if (post == null) throw new Exception("Post does not exist.");
                return new GetPostReturn { Id = post.PostId, Lat = post.Lat, Lon = post.Lon };
            }
        }
    }
}
