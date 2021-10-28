using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PostDemoApp.Services.Interfaces;

namespace CommentDemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }


        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var logs = await this.commentService.List();
            return Ok(logs);
        }
    }
}
