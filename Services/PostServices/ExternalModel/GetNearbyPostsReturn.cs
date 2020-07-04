using Model.Entities;
using System.Linq;

namespace Services.PostServices.ExternalModel
{
    public class GetNearbyPostsReturn
    {
        public GetNearbyPostsReturn(Post p)
        {
            Id = p.PostId; Lat = p.Lat; Lon = p.Lon;
            if(p.Pictures != null) PicturesIds = p.Pictures.Select(p => p.PictureId).ToArray();
        }

        public int Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int[] PicturesIds { get; set; }
    }
}
