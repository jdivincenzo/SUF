using DataAccess.Core;
using Model.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess.DatabaseInit
{
    public class AppDBInitializer : DropCreateDatabaseAlways<BaseContext>
    {
        protected override void Seed(BaseContext context)
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

            //SACAAR ESTO DE ACA!
            context.Database.ExecuteSqlCommand("DROP FUNCTION IF EXISTS CalculateDistance;");
            context.Database.ExecuteSqlCommand(@"CREATE FUNCTION CalculateDistance
                                                (
                                                    @Lat1 FLOAT,
                                                    @Lon1 FLOAT,
                                                    @Lat2 FLOAT,
                                                    @Lon2 FLOAT
                                                )
                                                RETURNS FLOAT
                                                AS
                                                BEGIN
                                                    DECLARE @rlat1 FLOAT
                                                    DECLARE @rlat2 FLOAT
                                                    DECLARE @theta FLOAT
                                                    DECLARE @rtheta FLOAT
                                                    DECLARE @dist FLOAT

                                                    SET @rlat1 = PI() * @Lat1 / 180
                                                    SET @rlat2 = PI() * @Lat2 / 180
                                                    SET @theta = @Lon1 - @Lon2
                                                    SET @rtheta = PI() * @theta / 180;
                                                    SET @dist = SIN(@rlat1) * SIN(@rlat2) + COS(@rlat1) * COS(@rlat2) * COS(@rtheta)
                                                    SET @dist = ACOS(@dist)
                                                    SET @dist = @dist * 180 / PI()
                                                    SET @dist = @dist * 60 * 1.1515

                                                    RETURN @dist *16.09344;
                                                END");
        }
    }
}