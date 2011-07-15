using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void CallProcess(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_CallProcess",packet);
		}
	}
}
