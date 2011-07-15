using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void DumpUnknown(Client client, PacketIn packet)
		{
            Utilities.DumpUnknown(packet);
		}
	}
}
