using System;
using System.Collections.Generic;
using System.Text;
using KalSharp.Worlds.Items;

namespace KalSharp.Packets 
{
    class AddToInventory : PacketOut
    {
        public AddToInventory(PlayerItem PlayerItem)
            : base(0x07, 26)
        {
            writer.Write((int)PlayerItem.IID);
            writer.Write((ushort)PlayerItem.Index);
            writer.Write((byte)PlayerItem.Prefix);
            writer.Write((int)PlayerItem.Info);
            writer.Write((int)PlayerItem.Num);
            writer.Write((byte)PlayerItem.MaxEnd);
            writer.Write((byte)PlayerItem.CurEnd);
            writer.Write((byte)PlayerItem.SetGem); // SetGem            
            writer.Write((byte)PlayerItem.XAttack);
            writer.Write((byte)PlayerItem.XMagic);
            writer.Write((byte)PlayerItem.XDefense);
            writer.Write((byte)PlayerItem.XHit);
            writer.Write((byte)PlayerItem.XDodge);
            writer.Write((byte)PlayerItem.Protect);
            writer.Write((byte)PlayerItem.UpgrLevel);
            writer.Write((byte)PlayerItem.UpgrRate);
            ServerConsole.WriteLine("added {0} to inventory", MessageLevel.Message, PlayerItem.Index);
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
