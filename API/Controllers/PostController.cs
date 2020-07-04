using API.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.PostServices;
using Services.PostServices.ExternalModel;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : AbstractController<PostController>
    {
        public PostController(ILogger<PostController> logger): base(logger){ }

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
            LogRequest(Request, HttpContext.TraceIdentifier, lat, lon, files.Select(x=> x.FileName).ToArray<object>());
            await Task.Run(() =>
            {
                var ret = new PostService().CreatePost(new CreatePostInvoke
                {
                    Lat = lat,
                    Lon = lon,
                    Files = new FileUtils().GetDescriptors(files)
                });
                LogResponse(JsonSerializer.Serialize(ret), HttpContext.TraceIdentifier);
                return ret;
            });
        }

        [Route("GetPost")]
        [HttpGet]
        public GetPostReturn GetPost(int id)
        {
            return new PostService().GetPost(new GetPostInvoke { Id = id });
        }
    }
}
