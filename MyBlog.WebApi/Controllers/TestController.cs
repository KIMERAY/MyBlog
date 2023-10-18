using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("this is NoAuthorize")]
        public string NoAuthorize()
        {
            return "this is NoAuthorize";
        }
        [Authorize]
        [HttpGet("this is Authorize")]
        public string Authoriize()
        {
            return "this is Authorize";
        }
    }
}
