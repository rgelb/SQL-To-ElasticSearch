using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SqlToElasticSearchConverter {
    public class Program {
        public static void Main(string[] args) {
            CreateWebHostBuilder(args).Build().Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) {

            // support for custom ports
            var appArgs = new Arguments();
            Parser.ParseArgumentsWithUsage(args, appArgs);

            return WebHost.CreateDefaultBuilder(args)
                .ApplyPorts(appArgs)
                .UseStartup<Startup>();
        }

    }

    public static class WebHostBuilderExtension {
        public static IWebHostBuilder ApplyPorts(this IWebHostBuilder host, Arguments appArgs) {
            if (appArgs.Port > 0) {
                //host.UseUrls($"http://0.0.0.0:{appArgs.Port}");
                host.UseUrls($"http://*:{appArgs.Port}");
            }

            return host;
        }
    }

    [CommandLineArguments(CaseSensitive = false)]
    public class Arguments {
        [Argument(ArgumentType.AtMostOnce, HelpText = "Port", DefaultValue = -1, LongName = "Port", ShortName = "p")]
        public int Port;
    }


}
