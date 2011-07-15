using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void FriendsList(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_FriendsList",packet);
		}
	}
}
