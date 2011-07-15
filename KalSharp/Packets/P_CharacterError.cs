using System;

namespace KalSharp.Packets
{
	public enum CHARACTER_ERROR
	{
		INVALID_CHARS = 0x04,
		MSG_SAMEPLAYERONGAME = 0x05,
		ID_BLOCKED = 0x06,
        CHARACTER_INFORMATION_PROBLEM = 0x07,
        CHARACTER_DOES_NOT_EXIST = 0x08,
	}

	public class CharacterError : PacketOut
	{
        public CharacterError(CHARACTER_ERROR Type)
            : base(0x43, 1)
		{
			writer.Write((byte)Type);
		}
	}
}
