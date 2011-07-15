using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void Teleport(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_Teleport",packet);
		}
	}
}
