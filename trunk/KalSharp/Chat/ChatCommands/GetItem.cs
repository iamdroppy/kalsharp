using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Characters;
using KalSharp.Worlds.Items;
using KalSharp.Configs.Items;

namespace KalSharp.Chat.ChatCommands
{
    class GetItem : IChatCommand
    {
        public void Execute(Character Character, string Message)
        {
            string[] args = Message.Split(' ');
            int index = Convert.ToInt32(args[1]);

            //check if the item exists
            if (Item.FindByIndex(index) != null)
            {
                PlayerItem pItem = new PlayerItem();
                pItem.Index = index;
                pItem.MaxEnd = (byte)pItem.Item.Endurance;
                pItem.CurEnd = pItem.MaxEnd;
                pItem.Num = 1;
                Character.Inventory.AddItem(pItem);
            }
            else
            {
                ServerConsole.WriteLine("Index {0} does not exist", MessageLevel.Error, index);
            }
        }
    }
}
