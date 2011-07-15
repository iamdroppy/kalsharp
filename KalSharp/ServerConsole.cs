using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace KalSharp
{
    public enum MessageLevel
    {
        Message = 0,
        Warning = 1,
        Error = 2,
        ODBC = 3,
        Chat = 4,
        World = 5,
        ODBCError = 6,
        Fatal = 7,
        Hackshield = 8,
    }
    public static class ServerConsole
    {
        private static Log ChatLog = new Log(@"Logs\Chat.txt");
        private static Log ODBCLog = new Log(@"Logs\ODBC.txt");
        private static Log ServerLog = new Log(@"Logs\Server.txt");
        private static Log WorldLog = new Log(@"Logs\World.txt");
        private static Log HackshieldLog = new Log(@"Logs\Hackshield.txt");

        /// <summary>
        /// Writes a line to the server console.
        /// </summary>
        /// <param name="Message">The message to be displayed.</param>
        /// <param name="Level">The level of the message.</param>
        /// <param name="Params">Parameters to format the message with.</param>
        public static void WriteLine(string Message, MessageLevel Level, params object[] Params)
        {
            OutputLine(string.Format(Message, Params), Level);
        }

        public static void WriteLine(string Message, MessageLevel Level)
        {
            OutputLine(Message, Level);
        }

        public static void WriteLine(string Message)
        {
            OutputLine(Message, MessageLevel.Message);
        }

        private static void OutputLine(string Message, MessageLevel Level)
        {
            //set console color
            SetConsoleColor(Level);
            Message = AddPrefix(Message, Level);
            
            //log
            LogMessage(Message, Level);
            //output to console
            if (Level != MessageLevel.World && Level != MessageLevel.Chat)
            {
                Console.WriteLine(Message);
            }
        }

        private static void LogMessage(string Message, MessageLevel Level)
        {
            switch (Level)
            {
                case MessageLevel.Chat:
                    ChatLog.LogMessage(Message);
                    break;
                case MessageLevel.Error:
                    ServerLog.LogMessage(Message);
                    break;
                case MessageLevel.Message:
                    ServerLog.LogMessage(Message);
                    break;
                case MessageLevel.ODBC:
                    ODBCLog.LogMessage(Message);
                    ServerLog.LogMessage(Message);
                    break;
                case MessageLevel.Warning:
                    ServerLog.LogMessage(Message);
                    break;
                case MessageLevel.World:
                    WorldLog.LogMessage(Message);
                    break;
                case MessageLevel.ODBCError:
                    ODBCLog.LogMessage(Message);
                    ServerLog.LogMessage(Message);
                    break;
                case MessageLevel.Fatal:
                    ServerLog.LogMessage(Message);
                    break;
                case MessageLevel.Hackshield:
                    ServerLog.LogMessage(Message);
                    HackshieldLog.LogMessage(Message);
                    break;
            }
        }


        private static void SetConsoleColor(MessageLevel Level)
        {
            ConsoleColor Color = ConsoleColor.Gray;
            switch (Level)
            {
                case MessageLevel.Error:
                    Color = ConsoleColor.Red;
                    break;
                case MessageLevel.Message:
                    Color = ConsoleColor.Gray;
                    break;
                case MessageLevel.ODBC:
                    Color = ConsoleColor.Blue;
                    break;
                case MessageLevel.ODBCError:
                    Color = ConsoleColor.Red;
                    break;
                case MessageLevel.Warning:
                    Color = ConsoleColor.Yellow;
                    break;
                case MessageLevel.Fatal:
                    Color = ConsoleColor.Magenta;
                    break;
                case MessageLevel.Hackshield:
                    Color = ConsoleColor.Green;
                    break;
            }

            //set forground color
            Console.ForegroundColor = Color;
        }

        private static string AddPrefix(string Message, MessageLevel Level)
        {
            return DateTime.Now + " (" + Level.ToString() + ") " + Message;
        }


        public static void PrintLogo()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("KalSharp.logo.txt");
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                Console.WriteLine(result);
            }

            
        }
    }
}
