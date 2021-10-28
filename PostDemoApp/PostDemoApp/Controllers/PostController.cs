using Microsoft.AspNetCore.Mvc;
using PostDemoApp.Services.Interfaces;
using System.Threading.Tasks;

namespace PostDemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }


        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var logs = await this.postService.List();
            return Ok(logs);
        }
    }
}
