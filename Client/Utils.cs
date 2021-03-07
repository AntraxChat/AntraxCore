using System;

namespace AntraxClient.Utils
{
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
                Console.Write(bar + "\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static string CurrentUnixTime()
        {
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