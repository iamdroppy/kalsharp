using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void Mail(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_Mail",packet);
		}
	}
}
