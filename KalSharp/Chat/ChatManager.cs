using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Chat.ChatCommands;
using KalSharp.Worlds.Characters;

namespace KalSharp.Chat
{
    public static class ChatManager
    {
        private static Dictionary<string, IChatCommand> ChatCommands;

        public static void Load()
        {
            ServerConsole.WriteLine("Loading Chat Manager");
            ChatCommands = new Dictionary<string, IChatCommand>();
            ChatCommands.Add("", new NormalChat());
            ChatCommands.Add("/get", new GetItem());
        }

        public static void Chat(Character Character, string Message)
        {
            foreach (string Key in ChatCommands.Keys)
            {
                if (Message.StartsWith(Key))
                {
                    try
                    {
                        ChatCommands[Key].Execute(Character, Message);
                    }
                    catch (Exception ex)
                    {
                        ServerConsole.WriteLine("Chat command error: {0}", MessageLevel.Error, ex);
                    }
                }
            }
            Character.Chat(Message);
        }
    }
}
