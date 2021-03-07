using AntraxClient.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AntraxClient.Network;

namespace AntraxClient
{
    public static class Resource
    {
        // Root Directories
        public static string dResource = @"Resource";
        public static string dChat = $"{dResource}/Chat";
        public static string dUser = $"{dResource}/User";
        public static string dGeneral = $"{dUser}/General";
        public static string dMeta = $"{dGeneral}/Meta";
        public static string dSetting = $"{dGeneral}/Setting";

        // Other
        public static string dNetProp = $"{dResource}/NetworkProperties.json";

        // Local Chat " ID's Database"
        public static class Chat
        {
            public static string GroupsChats = $"{dResource}/GroupChats/";
            public static string PrivateChats = $"{dResource}/PrivateChats/";
        }

        // File Paths
        public static class User
        {
            public static class General
            {
                public static class Meta
                {
                    public static string Picture = $"{dMeta}/Picture.json";
                    public static string Username = $"{dMeta}/Username.json";
                }
                public static class Setting
                {
                    public static string Theme = $"{dSetting}/Theme.json";
                }
            }
        }
    }

    public static class GeneralProgram
    {
        static List<string> FilePaths = new List<string>
        {
            Resource.User.General.Meta.Picture,
            Resource.User.General.Meta.Username,
            Resource.User.General.Setting.Theme,
        };

        static List<string> DirPaths = new List<string>
        {
            Resource.dResource,
            Resource.dChat,
            Resource.Chat.GroupsChats,
            Resource.Chat.PrivateChats,
            Resource.dUser,
            Resource.dGeneral,
            Resource.dMeta,
            Resource.dSetting,
        };

        static async Task Main()
        {
            //var instance = new Json.JsonWrapper.NetworkProperties();
            //Console.WriteLine(Json.JsonWrapper.SerializeObject(instance));
            var response = Json.JsonWrapper.DeserializeString(await File.ReadAllTextAsync(Resource.dNetProp));
            Console.WriteLine(response.Target.Address);
            Console.ReadLine();
            //..
            Util.Print.Logo();
            Util.Print.WaterMark();
            // ----------------------------------
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
            Console.Clear();
            // ----------------------------------
            Util.Print.Logo();
            Util.Print.WaterMark();
            // ----------------------------------
            await DirsPathsCheck();
            await FilePathsCheck();
            // ----------------------------------

            //await Network.Network.(response);
            //await Network.Http.Ser();
            Console.ReadLine();
        }

        static async Task DirsPathsCheck()
        {
            foreach (var str in DirPaths)
            {
                if (!Directory.Exists(str))
                {
                    Util.Debug($"Directory {str} did not exist, attempting to create a new one.", 2);
                    try
                    {
                        Directory.CreateDirectory(str);
                        Util.Debug($"Successfully created directory {str}.");
                    }
                    catch (Exception ex)
                    {
                        Util.Debug($"Couldn't create {str} directory.", 4);
                        await File.WriteAllTextAsync($"DumpLog{Util.CurrentUnixTime()}.txt", $"DATE: \"{DateTime.Now}\" | EX: {ex.Message}");
                        Thread.Sleep(5000);
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Util.Debug($"Directory {str} exists.", 1);
                }
            }
            return;
        }

        static async Task FilePathsCheck()
        {
            foreach (var str in FilePaths)
            {
                if (!File.Exists(str))
                {
                    Util.Debug($"File {str} did not exist, attempting to create a new one.", 2);
                    try
                    {
                        File.Create(str);
                        Util.Debug($"Successfully created file {str}.");
                    }
                    catch (Exception ex)
                    {
                        Util.Debug($"Couldn't create {str} directory.", 4);
                        await File.WriteAllTextAsync($"DumpLog{Util.CurrentUnixTime()}.txt", $"DATE: \"{DateTime.Now}\" | EX: {ex.Message}");
                        Thread.Sleep(5000);
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Util.Debug($"File {str} exists.", 1);
                }
            }
        }
    }
}
