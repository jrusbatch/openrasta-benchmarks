using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OpenRasta.Hosting.Katana;
using Owin;

namespace BasicOpenRastaApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Map("/webapi", app => ConfigureWebApi(app))
                .Map("/openrasta", app => ConfigureOpenRasta(app));
        }
        private static void ConfigureOpenRasta(IAppBuilder app)
        {
            var configSources = new Configuration();

            app.UseOpenRasta(configSources, configSources);
        }

        private static void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            //var xmlFormatter = config.Formatters.XmlFormatter;
            //var jsonFormatter = config.Formatters.JsonFormatter;
            //config.Formatters.Clear();
            //config.Formatters.Add(xmlFormatter);
            //config.Formatters.Add(jsonFormatter);

            config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            app.UseWebApi(config);
        }
    }
}
