using System;
using System.Net;
using System.Threading;
using OpenRasta.Hosting;
using OpenRasta.Hosting.HttpListener;

namespace OpenRastaHttpListenerFullFX
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.DefaultConnectionLimit = 144;
            ThreadPool.SetMinThreads(100, 100);
            ThreadPool.SetMaxThreads(250, 250);

            var config = new Configuration();
            using (var host = new HttpListenerHost(config, config.Resolver))
            {
                host.Initialize(new[] { "http://localhost:9070/" }, string.Empty);
                host.StartListening();

                Console.WriteLine("Press any key to stop listening...");
                Console.ReadKey(true);
                host.StopListening();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
