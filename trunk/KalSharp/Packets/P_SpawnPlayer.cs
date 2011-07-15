using System;
using KalSharp.Worlds.Items;
using KalSharp.Worlds.Characters;

namespace KalSharp.Packets
{
	public class SpawnPlayer : PacketOut
	{
        public SpawnPlayer(Character Character, bool isPlayerPlayer)
            : base(0x32)
		{
            SetCapacity((ushort)(59 + Character.Player.Name.Length));

            writer.Write(Character.WorldId);
            writer.Write(Character.Player.Name.ToCharArray());
			writer.Write((byte)0);

			if(isPlayerPlayer)
            {
                writer.Write((byte)((byte)0x80 | (byte)Character.Player.Class));
			}
            else
            {
                writer.Write((byte)Character.Player.Class);
            }
		
			//Coordinates
            writer.Write(Character.Position.X);
            writer.Write(Character.Position.Y);
            writer.Write(Character.Position.Z);
			
			writer.Write((short)1);

            if (Character.IsAlive)
            {
			    writer.Write((byte)0); // Alive
			} else {
			    writer.Write((byte)2); // Dead
			}
			
			writer.Write((short)0);
            writer.Write((byte)0);

            /// 
            /// Gear
            /// 
            PlayerGear gear = Character.Gear as PlayerGear;

            writer.Write(gear.Slots[1]);
            writer.Write(gear.Slots[2]);
            writer.Write(gear.Slots[3]);
            writer.Write(gear.Slots[4]);
            writer.Write(gear.Slots[5]);
            writer.Write(gear.Slots[6]);
            writer.Write(gear.Slots[7]);
            
            ///
            /// Look
            /// 
            writer.Write((byte)Character.Player.Face);
            writer.Write((byte)Character.Player.Hair);

			for(int i=0;i<19;i++) {
			    writer.Write((byte)0);
			}
		}
	}
}
