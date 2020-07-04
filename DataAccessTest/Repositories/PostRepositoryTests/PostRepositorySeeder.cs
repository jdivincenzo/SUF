using DataAccess.Core;
using Model.Entities;
using System.Collections.Generic;

namespace DataAccessTest.Repositories.PostRepositoryTests
{
    public class PostRepositorySeeder : BaseSeeder, ISeeder
    {
        public PostRepositorySeeder(bool transient) : base(transient) { }

        public override void Seed(BaseContext context)
        {
            IList<Post> posts = new List<Post>();
            Post post1 = new Post() { Lat = -34.629405, Lon=-58.691752 };
            Post post2 = new Post() { Lat = -34.630623, Lon=-58.692679 };

            posts.Add(post1);
            posts.Add(post2);
            context.Posts.AddRange(posts);

            IList<Picture> pictures = new List<Picture>
            {
                new Picture() { FileName = "Foto 1", Post = post1 },
                new Picture() { FileName = "Foto 2", Post = post2 },
                new Picture() { FileName = "Foto 3", Post = post2 }
            };
            context.Pictures.AddRange(pictures);

            context.SaveChanges();
        }
    }
}