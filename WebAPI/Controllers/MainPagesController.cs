using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainPagesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Welcome main page!";
        }
    }
}
