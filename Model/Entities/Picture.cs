using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Picture
    {
        public int PictureId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        //public DateTime CreationDate { get; set; }
    }
}
