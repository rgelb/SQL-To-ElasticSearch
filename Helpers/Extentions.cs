using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace SqlToElasticSearchConverter.Helpers;

public static class Extentions
{
    public static string PrettyJson(this string jsonString) {
        dynamic parsedJson = JsonConvert.DeserializeObject(jsonString);
        return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
    }

    public static IWebHostBuilder ApplyPorts(this ConfigureWebHostBuilder host, AppArguments appArgs) {
        if (appArgs.Port > 0) {
            host.UseUrls($"http://*:{appArgs.Port}");
        }

        return host;
    }
}
