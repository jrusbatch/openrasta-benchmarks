using System.Threading.Tasks;
using BasicAspNetCoreApi.Models;
using OpenRasta.Web;

namespace BasicAspNetCoreApi.Handlers
{
    public class HealthCheckHandler
    {
        public async Task<OperationResult> Get()
        {
            await Task.Yield();
            return new OperationResult.OK(
                        new healthcheck
                        {
                            count = "OK"
                        });
        }
    }
}
