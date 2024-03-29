using System;

namespace KalSharp.Packets
{
	public class Init : PacketOut
	{
		public Init(byte FirstKey, byte BitEvent, int CharacterLimit) : base(0x2a, 24)
		{
			this.Key = 0;
			
			writer.Write((byte)0x47);
			writer.Write((byte)0xa7);
			writer.Write((byte)0xf6);
			writer.Write((byte)0x16);
			writer.Write(FirstKey);
			writer.Write((byte)0xd4);
			writer.Write((byte)0x4c);
			writer.Write((byte)0x7e);
			writer.Write((byte)0x44);
			writer.Write((byte)0x4c);
			writer.Write((byte)0x0d);
			writer.Write((byte)0x2d);
			writer.Write((byte)0x45);
			writer.Write((byte)0x61);
			writer.Write((byte)0x1e);
			writer.Write((byte)0x00);
			writer.Write((byte)0x00);
			writer.Write(BitEvent);
			writer.Write((byte)0x00);
			writer.Write((byte)0x00);
			writer.Write((byte)0x00);
			writer.Write((byte)0x01);
			writer.Write((byte)0x12);
            writer.Write((byte)(CharacterLimit - 1));
		}
	}
}
