using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Services.PostServices.ExternalModel
{
    public class CreatePostInvoke
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public List<FileDescriptor> Files { get; set; }
    }

    public class FileDescriptor
    { 
        public Stream Content { get; set; }
        public String Filename { get; set; }
        public String MimeType { get; set; }
    }
}

