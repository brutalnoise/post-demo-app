using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PostDemoApp.Services.Interfaces;
using PostDemoApp.Models;

namespace UserDemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MiscController : ControllerBase
    {
        private readonly IApiService apiService;
        public MiscController(IApiService apiService)
        {
            this.apiService = apiService;
        }


        [HttpGet]
        [Route("RefreshData")]
        public async Task<IActionResult> List()
        {
            await this.apiService.MigrateData();
            return Ok();
        }
    }
}
