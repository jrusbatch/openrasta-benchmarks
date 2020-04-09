using System.Threading.Tasks;
using BasicOpenRastaApi.Models;
using OpenRasta.Web;

namespace BasicOpenRastaApi.Handlers
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
