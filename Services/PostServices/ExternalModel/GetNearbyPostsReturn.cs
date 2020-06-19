using System;
using System.Collections.Generic;
using System.Text;

namespace Services.PostServices.ExternalModel
{
    public class GetNearbyPostsReturn
    {
        public int Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
