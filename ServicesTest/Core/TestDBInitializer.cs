using DataAccess.Core;
using Model.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace ServicesTest.Core
{
    public class TestDBInitializer : DropCreateDatabaseAlways<DevContext>
    {
        protected override void Seed(DevContext context)
        {
            IList<Post> posts = new List<Post>();
            Post post1 = new Post() { Lat = -34.631298,Lon=-58.695334 };
            Post post2 = new Post() { Lat = -34.632455,Lon=-58.696286 };
            Post post3 = new Post() { Lat = -34.633683, Lon=-58.697299 };

            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            context.Posts.AddRange(posts);

            IList<Picture> pictures = new List<Picture>();
            pictures.Add(new Picture() { FileName = "Foto 1", Post = post1 });
            pictures.Add(new Picture() { FileName = "Foto 2", Post = post2 });
            pictures.Add(new Picture() { FileName = "Foto 3", Post = post3 });
            context.Pictures.AddRange(pictures);

            base.Seed(context);
        }
    }
}