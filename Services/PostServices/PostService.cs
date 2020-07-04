using DataAccess.Repositories;
using Model.Entities;
using Services.Common;
using Services.PostServices.ExternalModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.PostServices
{
    public class PostService: Services.AbstractService.AbstractService
    {
        #region constructors
        public PostService() : base() { }
        public PostService(DataAccess.Core.BaseContext context) : base(context) { }
        public PostService(DataAccess.Core.BaseContext context, IFileUtils fileUtils) : base(context, fileUtils) { }

        #endregion

        public IEnumerable<GetNearbyPostsReturn> GetNearby(GetNearbyPostsInvoke invoke)
        {
            using var ctx = NewContext();
            var posts = new PostRepository(ctx).GetNearbyPosts(invoke.Lat, invoke.Lon, invoke.Distance);
            List<GetNearbyPostsReturn> ret = posts.ToList().ConvertAll(x => new GetNearbyPostsReturn(x));
            return ret;
        }

        public GetPostReturn GetPost(GetPostInvoke invoke)
        {
            using var ctx = NewContext();
            var post = new PostRepository(ctx).GetById(invoke.Id);
            if (post == null) throw new Exception("Post does not exist.");
            return new GetPostReturn(post);
        }

        public CreatePostReturn CreatePost(CreatePostInvoke invoke)
        {
            using var ctx = NewContext();
            if (invoke.Files == null || invoke.Files.Count == 0) throw new Exception("Post does not have pictures.");
            List<Picture> pics = new List<Picture>();

            foreach (FileDescriptor f in invoke.Files)
            {
                GetFileUtils().SaveFile(f.Content, f.Filename);
                pics.Add(new Picture { FileName = f.Filename, MimeType = f.MimeType });
            }

            var post = new Post { Lat = invoke.Lat, Lon = invoke.Lon, Pictures = pics };
            ctx.Posts.Add(post);
            ctx.SaveChanges();
            return new CreatePostReturn(post);
        }
    }
}
