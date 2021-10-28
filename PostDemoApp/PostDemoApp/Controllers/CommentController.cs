using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PostDemoApp.Services.Interfaces;
using PostDemoApp.Models;

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
            var result = await this.commentService.List();
            return Ok(result);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] CommentModel model)
        {
            var result = await this.commentService.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] CommentModel model)
        {
            var result = await this.commentService.Update(model);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.commentService.Delete(id);
            return Ok();
        }
    }
}
