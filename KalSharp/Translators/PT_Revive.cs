using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void Revive(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_Revive",packet);
		}
	}
}
