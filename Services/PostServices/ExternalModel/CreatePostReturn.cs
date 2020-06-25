using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.PostServices.ExternalModel
{
    public class CreatePostReturn
    {
        public CreatePostReturn(Post p)
        {
            Id = p.PostId; Lat = p.Lat; Lon = p.Lon;
        }

        public int Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
