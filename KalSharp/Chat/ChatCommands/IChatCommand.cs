using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Characters;

namespace KalSharp.Chat.ChatCommands
{
    public interface IChatCommand
    {
        void Execute(Character Character, string Message);
    }
}
