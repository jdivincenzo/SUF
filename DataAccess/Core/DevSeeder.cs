using Model.Entities;
using System.Collections.Generic;

namespace DataAccess.Core
{
    public class DevSeeder: BaseSeeder, ISeeder
    {
        public DevSeeder(bool transient):base(transient) { }

        public override void Seed(BaseContext context)
        {
            IList<Post> posts = new List<Post>();
            Post post1 = new Post() { Lat = -34.631298, Lon = -58.695334 };
            Post post2 = new Post() { Lat = -34.632455, Lon = -58.696286 };
            Post post3 = new Post() { Lat = -34.633683, Lon = -58.697299 };

            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            context.Posts.AddRange(posts);

            IList<Picture> pictures = new List<Picture>
            {
                new Picture() { FileName = "Foto 1", Post = post1 },
                new Picture() { FileName = "Foto 2", Post = post2 },
                new Picture() { FileName = "Foto 3", Post = post3 }
            };
            context.Pictures.AddRange(pictures);

            context.SaveChanges();
        }
    }
}
