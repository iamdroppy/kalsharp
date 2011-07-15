using System;
using System.Collections;
using KalSharp.Worlds.Items;

namespace KalSharp.Packets
{
	public class SendInventory : PacketOut
	{
		public SendInventory(Inventory inventory) : base(0x04)
		{
            ushort packetsize = 1;

            foreach (Item item in inventory.Items)
            {
                if (item.InitItem.Plural == 1)
                {
                    packetsize += 15;
                }
                else
                {
                    packetsize += 26;
                }
            }

            SetCapacity(packetsize);

            writer.Write((byte)inventory.Items.Count);

            foreach(Item item in inventory.Items)
            {
                writer.Write((int)item.IID);
                writer.Write((ushort)item.Index);
                writer.Write((byte)item.Prefix);
                writer.Write((int)item.Info);
                writer.Write((int)item.Num);
                if (item.InitItem.Plural != 1)
                {
                    ServerConsole.WriteLine("No plural");
                    writer.Write((byte)item.MaxEnd);
                    writer.Write((byte)item.CurEnd);
                    writer.Write((byte)item.SetGem); // SetGem            
                    writer.Write((byte)item.XAttack);
                    writer.Write((byte)item.XMagic);
                    writer.Write((byte)item.XDefense);
                    writer.Write((byte)item.XHit);
                    writer.Write((byte)item.XDodge);
                    writer.Write((byte)item.Protect);
                    writer.Write((byte)item.UpgrLevel);
                    writer.Write((byte)item.UpgrRate);
                }
                else
                {
                    ServerConsole.WriteLine("Plural");
                }
            }

		}
	}
}
