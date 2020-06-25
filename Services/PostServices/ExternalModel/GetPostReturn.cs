using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.PostServices.ExternalModel
{
    public class GetPostReturn
    {
        public GetPostReturn(Post post)
        {
            Id = post.PostId; Lat = post.Lat; Lon = post.Lon;
        }

        public int Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
