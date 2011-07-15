using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void EnchantItem(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_EnchantItem",packet);
		}
	}
}
