using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
