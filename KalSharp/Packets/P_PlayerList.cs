using System;   
using System.Collections.Generic;
using KalSharp.Worlds;
using KalSharp.Worlds.Items;

namespace KalSharp.Packets
{
	public class PlayerList : PacketOut
	{
		public PlayerList(IList<Player> PlayerList) : base(0x11)
		{
			int packetSize = 10;
            foreach (Player player in PlayerList)
            {
				packetSize += player.Name.Length;
				packetSize += 19;
				packetSize += (player.Gear.EquippedItems.Count * 2);
			}
			SetCapacity((ushort)packetSize);

			writer.Write((int)0x0);
			writer.Write((byte)0x0);
            writer.Write((byte)PlayerList.Count);

            foreach (Player player in PlayerList)
            {
                // id and name
                writer.Write(player.PID);
                writer.Write(player.Name.ToCharArray());
                writer.Write((byte)0);
                // class & level
                writer.Write(player.Class);
                writer.Write((int)player.Level);
                writer.Write((byte)0);                
                // stats
                writer.Write(player.Strength);
                writer.Write(player.Health);
                writer.Write(player.Intelligence);
                writer.Write(player.Wisdom);
                writer.Write(player.Dexterity);
                // look
                writer.Write(player.Face);
                writer.Write(player.Hair);
                // inventory
                writer.Write((byte)player.Gear.EquippedItems.Count);
                foreach(Item item in player.Gear.EquippedItems)
                {
                    writer.Write((ushort)item.Index);
                }                
            }
            writer.Write((int)0x03);
		}
	}
}
