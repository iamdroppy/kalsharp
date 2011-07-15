using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void RequestTrade(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_RequestTrade",packet);
		}

		public static void OnTradeRequest(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_OnTradeRequest",packet);
		}
		
		public static void Trade(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_Trade",packet);
		}
		
		public static void CancelTrade(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_CancelTrade",packet);
		}
		
		public static void AcceptTrade(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_AcceptTrade",packet);
		}
	}
}
