using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PostDemoApp.Services.Interfaces;
using PostDemoApp.Models;

namespace UserDemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var result = await this.userService.List();
            return Ok(result);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await this.userService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] UserModel model)
        {
            var result = await this.userService.Add(model);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UserModel model)
        {
            var result = await this.userService.Update(model);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.userService.Delete(id);
            return Ok();
        }
    }
}
