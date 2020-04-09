using System;
using System.Diagnostics;
using BasicAspNetCoreApi.Handlers;
using BasicAspNetCoreApi.Models;
using Castle.Windsor;
using OpenRasta.Configuration;
using OpenRasta.Configuration.Fluent;
using OpenRasta.DI;
using OpenRasta.DI.Windsor;

namespace BasicAspNetCoreApi
{
    public class Configuration : IConfigurationSource, IDependencyResolverAccessor
    {
        private readonly static Lazy<IDependencyResolver> _lazyDependencyResolver =
               new Lazy<IDependencyResolver>(CreateDependencyResolver);

        public IDependencyResolver Resolver => _lazyDependencyResolver.Value;

        public void Configure()
        {
            AddRoute<healthcheck, HealthCheckHandler>("/healthcheck");
        }

        private static IUriDefinition<TResource> AddRoute<TResource, THandler>(params string[] url)
        {
            Debug.Assert(url != null && url.Length > 0);

            var definition = ResourceSpace.Has.ResourcesOfType<TResource>().AtUri(url[0]);

            for (var i = 1; i < url.Length; i++)
                definition.And.AtUri(url[i]);

            definition.HandledBy<THandler>().AsXmlSerializer().And.AsJsonDataContract();

            return definition;
        }

        private static IDependencyResolver CreateDependencyResolver()
        {
            var container = new WindsorContainer();

            // Register stubs to stop Windsor complaining
            //container.Register(
            //    Component.For<HttpContext>().UsingFactoryMethod(() => (HttpContext)null));
            //Component.For<AspNetRequest>().UsingFactoryMethod(() => (AspNetRequest)null),
            //Component.For<AspNetResponse>().UsingFactoryMethod(() => (AspNetResponse)null));

            return new WindsorDependencyResolver(container);
        }
    }
}
