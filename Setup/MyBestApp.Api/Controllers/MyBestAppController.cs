using Microsoft.AspNetCore.Mvc;

namespace MyBestApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyBestAppController : ControllerBase
    {
        [HttpGet("Ping")]
        public string PingPong()
        {
            return "Pong";
        }
    }
}