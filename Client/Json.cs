using Newtonsoft.Json;

namespace AntraxClient.Json
{
    public static class JsonWrapper
    {
        public static NetworkProperties DeserializeString(string json)
        {
            return JsonConvert.DeserializeObject<NetworkProperties>(json, Converter.Settings);
        }

        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, Converter.Settings);
        }

        public class NetworkProperties
        {
            public Target Target = new Target();
        }

        public class Target
        {
            [JsonProperty("Address")]
            public string Address { get; set; } = "127.0.0.1";

            [JsonProperty("Port")]
            public int Port { get; set; } = 5050;
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None
        };
    }
}
