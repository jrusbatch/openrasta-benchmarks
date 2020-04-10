using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenRasta.Hosting.AspNetCore;

namespace BasicAspNetCoreApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<IISServerOptions>(
                opts =>
                {
                    opts.AutomaticAuthentication = false;
                    opts.AllowSynchronousIO = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder appBuilder, IWebHostEnvironment env)
        {
            appBuilder.Map("/aspnetcore",
                app =>
                {
                    app.UseRouting();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                });

            appBuilder.Map("/openrastacore",
                app =>
                {
                        var configSources = new Configuration();

                        app.UseOpenRasta(configSources, configSources);

                });
        }
    }
}
