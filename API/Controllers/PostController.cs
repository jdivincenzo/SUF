using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.PostServices;
using Services.PostServices.ExternalModel;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        [Route("GetNearbyPosts")]
        [HttpGet]
        public IEnumerable<GetNearbyPostsReturn> GetNearbyPosts(double lat, double lon, int dist)
        {
            return new PostService().GetNearby(new GetNearbyPostsInvoke { Lat = lat, Lon = lon, Distance = dist }).ToArray();
        }

        [Route("CreatePost")]
        [HttpPost]
        public async Task CreatePost([FromForm] double lat, [FromForm] double lon, [FromForm] IFormFile[] files)
        {
            List<FileDescriptor> filesDescriptors = new List<FileDescriptor>();
            foreach (IFormFile f in files)
                filesDescriptors.Add( new FileDescriptor { Content = f.OpenReadStream(), Filename = f.FileName, MimeType = f.ContentType } );

            await Task.Run(() => new PostService().CreatePost(new CreatePostInvoke { Lat = lat, Lon = lon, Files = filesDescriptors }));
        }
    }
}
