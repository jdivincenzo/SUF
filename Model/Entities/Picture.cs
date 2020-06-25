using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Picture
    {
        public int PictureId { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public Post Post { get; set; }
    }
}
