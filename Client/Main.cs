using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace awesomeProject
{
    public static class Resource
    {
        // Root Directories
        public static string dResource     = @"Resource";
        public static string dChat         = $"{dResource}/Chat";
        public static string dUser         = $"{dResource}/User";
        public static string dGeneral      = $"{dUser}/General";
        public static string dMeta         = $"{dGeneral}/Meta";
        public static string dSetting      = $"{dGeneral}/Setting";

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

        static List<string> FilePaths = new List<string>
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
            Util.Print.Logo();
            Util.Print.WaterMark();
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
            Console.Clear();
            Util.Print.Logo();
            Util.Print.WaterMark();
            await DirsPathsCheck();
            await FilePathsCheck();
        }

        static async Task DirsPathsCheck()
        {
            foreach (var str in RootPaths)
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

        }
    }


    class Util
    {
        public static class Print
        {
            public static void Logo()
            {
                var n = Environment.NewLine;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "████████████████████████████████████████████████████████████████" + n +
                    " ███████     ██   ████  █        █      ███     ██  ███  ██████ " + n +
                    "  █████  ███  █    ███  ████  ████  ███  █  ███  ██  █  ██████  " + n +
                    "   ████       █  █  ██  ████  ████      ██       ███   ██████   " + n +
                    "  █████  ███  █  ██  █  ████  ████  ███  █  ███  ██  █  ██████   " + n +
                    " ██████  ███  █  ███    ████  ████  ███  █  ███  █  ███  ██████ " + n +
                    "████████████████████████████████████████████████████████████████"
                    );
            }

            public static void WaterMark()
            {
                var bar = "█████████████████████████████";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(bar);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write("Antrax");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(bar+"\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static string CurrentUnixTime() {
            return DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        }

        public static void Debug(string content, int severity = 0)
        {
            string prefix = null;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[");
            if (severity == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                prefix = "SUCCESS";
            }
            else if (severity == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                prefix = "INFO";
            }
            else if (severity == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                prefix = "WARNING";
            }
            else if (severity == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                prefix = "ERROR";
            }
            else if (severity == 4)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                prefix = "CRITICAL";
            }
            else prefix = "no prefix";
            Console.Write(prefix);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($"] {content}\n");
        }
    }
}