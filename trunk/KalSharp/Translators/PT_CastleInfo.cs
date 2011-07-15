using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void CastleInfo(Client client, PacketIn packet)
		{
            Utilities.DumpUnusedPacket("PT_CastleInfo", packet);
		}
	}
}
