using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PostDemoApp.Services.Interfaces;

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
            var logs = await this.userService.List();
            return Ok(logs);
        }
    }
}
