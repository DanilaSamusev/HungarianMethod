using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class Home : Controller
    {
        [HttpPost("r")]
        public IActionResult GetSolution([FromBody] object data)
        {
            var a = 0;
            return Ok("alarm");
        }
    }
}