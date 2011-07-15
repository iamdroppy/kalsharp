using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Characters;
using KalSharp.Worlds.Items;
using KalSharp.Configs.InitItems;

namespace KalSharp.Chat.ChatCommands
{
    class NormalChat : IChatCommand
    {
        public void Execute(Character Character, string Message)
        {
            Character.Chat(Message);
        }
    }
}
