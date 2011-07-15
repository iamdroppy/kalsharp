using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void OpenSpecialItem(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_OpenSpecialItem",packet);
		}
		
		public static void CancelOpenSpecialItem(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_CancelOpenSpecialItem",packet);
		}
	}
}
