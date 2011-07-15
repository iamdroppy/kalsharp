using System;
using System.Collections.Generic;
using System.Text;
using KalSharp.Worlds.Items;

namespace KalSharp.Packets 
{
    class AddToInventory : PacketOut
    {
        public AddToInventory(Item Item)
            : base(0x07, 26)
        {
            writer.Write((int)Item.IID);
            writer.Write((ushort)Item.Index);
            writer.Write((byte)Item.Prefix);
            writer.Write((int)Item.Info);
            writer.Write((int)Item.Num);
            writer.Write((byte)Item.MaxEnd);
            writer.Write((byte)Item.CurEnd);
            writer.Write((byte)Item.SetGem); // SetGem            
            writer.Write((byte)Item.XAttack);
            writer.Write((byte)Item.XMagic);
            writer.Write((byte)Item.XDefense);
            writer.Write((byte)Item.XHit);
            writer.Write((byte)Item.XDodge);
            writer.Write((byte)Item.Protect);
            writer.Write((byte)Item.UpgrLevel);
            writer.Write((byte)Item.UpgrRate);
            ServerConsole.WriteLine("added {0} to inventory", MessageLevel.Message, Item.Index);
        }
    }

    class RemoveFromInventory : PacketOut
    {
        public RemoveFromInventory(int IID)
            : base(0x08, 5)
        {
            writer.Write(IID);
            writer.Write((byte)0x0b);
            ServerConsole.WriteLine("Removeed {0} from inventory", MessageLevel.Message, IID);
        }
    }

    class SetItemQuantity : PacketOut
    {
        public SetItemQuantity(int IID, int Quantity)
            : base(0x09, 9)
        {
            writer.Write(IID);
            writer.Write(Quantity);
            writer.Write((byte)0x0c);
            ServerConsole.WriteLine("Set quantity of {0} to {1}", MessageLevel.Message, IID, Quantity);
        }
    }
}
