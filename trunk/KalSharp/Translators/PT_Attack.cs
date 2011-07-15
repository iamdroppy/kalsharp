using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void Attack(Client client, PacketIn packet)
		{
            Utilities.DumpUnusedPacket("PT_Attack", packet);
		}
	}
}
