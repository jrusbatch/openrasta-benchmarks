using System.Threading.Tasks;
using OpenRasta.Web;
using OpenRastaHttpListenerFullFX.Models;

namespace OpenRastaHttpListenerFullFX.Handlers
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
