using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practical16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger logger;
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            logger.LogInformation("Hello world");
            return Ok("Hello world  successfull");
        }
    }
}
