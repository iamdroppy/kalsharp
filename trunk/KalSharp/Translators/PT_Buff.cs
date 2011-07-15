using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void Buff(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_Buff",packet);
		}
	}
}
