using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BasicOpenRastaApi.Models;

namespace BasicOpenRastaApi.Controllers
{
    public class HealthcheckController : System.Web.Http.ApiController
    {
        [Route("healthcheck")]
        public async Task<IHttpActionResult> Get()
        {
            await Task.Yield();
            return Ok(new healthcheck { count = "OK" });
        }
    }
}
