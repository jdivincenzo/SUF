using System;
using System.Collections.Generic;
using System.Text;

namespace Services.PostServices.ExternalModel
{
    public class GetNearbyPostsInvoke
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double Distance { get; set; }
    }
}
