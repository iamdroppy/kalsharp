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

            foreach (PlayerItem playerItem in inventory.Items)
            {
                if (playerItem.Item.Plural == 1)
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

            foreach(PlayerItem pItem in inventory.Items)
            {
                writer.Write((int)pItem.IID);
                writer.Write((ushort)pItem.Index);
                writer.Write((byte)pItem.Prefix);
                writer.Write((int)pItem.Info);
                writer.Write((int)pItem.Num);
                if (pItem.Item.Plural != 1)
                {
                    writer.Write((byte)pItem.MaxEnd);
                    writer.Write((byte)pItem.CurEnd);
                    writer.Write((byte)pItem.SetGem); // SetGem            
                    writer.Write((byte)pItem.XAttack);
                    writer.Write((byte)pItem.XMagic);
                    writer.Write((byte)pItem.XDefense);
                    writer.Write((byte)pItem.XHit);
                    writer.Write((byte)pItem.XDodge);
                    writer.Write((byte)pItem.Protect);
                    writer.Write((byte)pItem.UpgrLevel);
                    writer.Write((byte)pItem.UpgrRate);
                }
            }

		}
	}
}
