using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AntraxClient.Network
{
    class Network
    {
        static string BaseAddress { get; set; }
        static TcpListener _listener { get; set; }
        static HttpClient _httpClient = new HttpClient();

        static bool tcpServerRunning = false;

        public static class Tcp
        {
            public static async Task Initialize(Json.Holder.NetworkProperties holder)
            {
                BaseAddress = await File.ReadAllTextAsync(Resource.dNetProp);
                _httpClient = new HttpClient();
            }
            public class Message
            {
                public static async Task Broadcast()
                {

                }
            }
        }

        public static class Http
        {
            public static async Task<string> Post(string id, string message)
            {
                var values = new Dictionary<string, string> {
                    { "identifier", id },
                    { "message", message }
                };

                var response = await _httpClient.PostAsync(BaseAddress, new FormUrlEncodedContent(values));
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
