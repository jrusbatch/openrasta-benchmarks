using System.Threading.Tasks;
using BasicAspNetCoreApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicAspNetCoreApi.Controllers
{

    [Route("healthcheck")]
    public class HealthcheckController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Yield();
            return Ok(new healthcheck { count = "OK" });
        }
    }
}
