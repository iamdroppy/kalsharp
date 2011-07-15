using System;

namespace KalSharp.Packets
{
	public enum CHARACTER_CREATION_ERROR
	{
		NA_WRONGJOBNUMBER = 0x02,
		MAX_CHARS_EXCEEDED = 0x03,
		NAME_TAKEN = 0x04,
		SHARING_POINTS_ERROR = 0x05,
		ID_NOT_SUPPORTED = 0x06,
        EIGHT = 0x08,
	}

	public class CharacterCreationError : PacketOut
	{
        public CharacterCreationError(CHARACTER_CREATION_ERROR Type)
            : base(0x2c, 1)
		{
			writer.Write((byte)Type);
		}
	}
}
