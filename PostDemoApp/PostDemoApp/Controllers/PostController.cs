using Microsoft.AspNetCore.Mvc;
using PostDemoApp.Models;
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
            var result = await this.postService.List();
            return Ok(result);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await this.postService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] PostModel model)
        {
            var result = await this.postService.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] PostModel model)
        {
            var result = await this.postService.Update(model);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.postService.Delete(id);
            return Ok();
        }
    }
}
