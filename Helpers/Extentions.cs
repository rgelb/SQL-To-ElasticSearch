using Newtonsoft.Json;

namespace SqlToElasticSearchConverter.Helpers
{
    public static class Extentions
    {
        public static string PrettyJson(this string jsonString) {
            dynamic parsedJson = JsonConvert.DeserializeObject(jsonString);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }
}
