using Microsoft.AspNetCore.Mvc;
using MyBestApp.Api.Model;

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

        [HttpGet("QueryExample")]
        public string FormQuery([FromQuery] string text)
        {
            return $"Your text form Query -> {text}";
        }

        [HttpPost("BodyExample")]
        public string FormBody([FromBody] ExampleRequest request)
        {
            return String.Concat(Enumerable.Repeat(request.Text, request.Amount));
        }

        [HttpGet("RouteExample/{text}")]
        public string FormRoute(string text)
        {
            return $"Your text form Query -> {text}";
        }

        [HttpPost("FileUploadExample")]
        public string FromForm(IFormFile file)
        {
            return $"Received: {file.FileName}, {file.ContentType}";
        }

        [HttpPost("ActionResultExample")]
        public ActionResult<string> FormBodyActionResult([FromBody] ExampleRequest request)
        {
            if (request.Amount < 0)
                return new BadRequestObjectResult("Amount must be bigger that 0");

            return Ok(String.Concat(Enumerable.Repeat(request.Text, request.Amount)));
        }

        [HttpPost("IActionResultExample2")]
        public IActionResult FormBodyIActionResult([FromBody] ExampleRequest request)
        {
            if (request.Amount < 0)
                return new BadRequestObjectResult("Amount must be bigger that 0");

            return Ok(String.Concat(Enumerable.Repeat(request.Text, request.Amount)));
        }
    }
}