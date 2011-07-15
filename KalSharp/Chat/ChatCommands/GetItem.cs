using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Characters;
using KalSharp.Worlds.Items;
using KalSharp.Configs.InitItems;

namespace KalSharp.Chat.ChatCommands
{
    class GetItem : IChatCommand
    {
        public void Execute(Character Character, string Message)
        {
            string[] args = Message.Split(' ');
            int index = Convert.ToInt32(args[1]);

            //check if the item exists
            if (InitItem.ContainsIndex(index))
            {
                Item item = new Item();
                item.Index = index;
                item.MaxEnd = (byte)item.InitItem.Endurance;
                item.CurEnd = item.MaxEnd;
                item.Num = 1;
                Character.Inventory.AddItem(item);
            }
            else
            {
                ServerConsole.WriteLine("Index {0} does not exist", MessageLevel.Error, index);
            }
        }
    }
}
