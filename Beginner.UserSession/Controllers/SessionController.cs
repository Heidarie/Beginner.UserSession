using Beginner.UserSession.Extensions;
using Beginner.UserSession.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Beginner.UserSession.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IRedisCacheHelper _redisCacheHelper;

        public SessionController(IRedisCacheHelper redisCacheHelper)
        {
            _redisCacheHelper = redisCacheHelper;
        }

        [HttpGet("{key}")]
        public IActionResult GetSessionValue([FromRoute]string key)
        {
            var value = _redisCacheHelper.Get(key);
            return Ok(value);
        }

        [HttpPut("{key}")]
        public IActionResult SetSessionValue([FromRoute]string key, [FromBody]string value)
        {
            _redisCacheHelper.Set(key, value);
            return Ok();
        }

        [HttpPost("Logout/{key}")]
        public IActionResult DeleteSessionValue([FromRoute]string key)
        {
            _redisCacheHelper.Delete(key);
            return Ok();
        }
    }
}
