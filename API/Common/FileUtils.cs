using Microsoft.AspNetCore.Http;
using Services.PostServices.ExternalModel;
using System.Collections.Generic;

namespace API.Common
{
    public class FileUtils
    {
        public List<FileDescriptor> GetDescriptors(IFormFile[] files)
        { 
            List<FileDescriptor> filesDescriptors = new List<FileDescriptor>();
            foreach (IFormFile f in files)
                filesDescriptors.Add( new FileDescriptor { Content = f.OpenReadStream(), Filename = f.FileName, MimeType = f.ContentType } );
            return filesDescriptors;
        }
    }
}
