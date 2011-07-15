using System;
using KalSharp.Worlds.Drops;

namespace KalSharp.Packets
{
    public enum DISCONNECT_MESSAGE
    {
        NULL = 0x00,
        EXPELLED = 0x01,
        SAME_ACCOUNT_LOGIN = 0x02,
        SAME_ACCOUNT_LOGIN2 = 0x03,
        TIME_SYNCHRONISATION = 0x04,
        TERMS_OF_VALIDITY = 0x05,
        SERVER_FULL = 0x06,
        TIME_SYNCHRONISATION2 = 0x07,
        LOADING_CHARACTER_COMPLETED = 0x08,
        RESTORING_CHARACTER_COMPLETED = 0x09,
    }
	public class DisconnectMessage : PacketOut
	{
        public DisconnectMessage(DISCONNECT_MESSAGE Message)
            : base(0x2d, 1)
		{
            writer.Write((byte)Message);
		}
	}
}