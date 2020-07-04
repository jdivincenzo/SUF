using Microsoft.VisualBasic;
using Model.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Services.PostServices.ExternalModel
{
    public class GetPostReturn
    {
        public GetPostReturn(Post post)
        {
            Id = post.PostId; Lat = post.Lat; Lon = post.Lon;
            Pictures = new List<KeyValuePair<int, string>>(post.Pictures.Select(p => ( new KeyValuePair<int, string>( p.PictureId, p.FileName ))));
        }

        public int Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public IEnumerable<KeyValuePair<int, string>> Pictures { get; set; }
    }
}
