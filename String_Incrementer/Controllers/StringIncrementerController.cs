using Microsoft.AspNetCore.Mvc;
using String_Incrementer.Attributes;
using String_Incrementer.Helpers;

namespace String_Incrementer.Controllers
{
    [ApiSecretKey]
    [ApiController]
    [Route("api/[controller]")]
    public class StringIncrementerController : ControllerBase
    {
        [HttpGet("{inputString}")]
        public IActionResult Get(string inputString)
        {
            return Ok(StringHelpers.IncreaseString(inputString));
        }
    }
}