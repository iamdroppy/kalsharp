using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void OnPartyRequest(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_OnPartyRequest",packet);
		}

		public static void RequestParty(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_RequestParty",packet);
		}

		public static void LeaveParty(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_LeaveParty",packet);
		}

		public static void KickPartyPlayer(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_KickPartyPlayer",packet);
		}
	}
}
