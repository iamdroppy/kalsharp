using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void BankAdd(Client client, PacketIn packet)
		{
            Utilities.DumpUnusedPacket("PT_BankAdd", packet);
		}

		public static void BankRetrieve(Client client, PacketIn packet)
		{
            Utilities.DumpUnusedPacket("PT_BankRetrieve", packet);
		}

		public static void BankInfo(Client client, PacketIn packet)
		{
            Utilities.DumpUnusedPacket("PT_BankInfo", packet);
		}
	}
}
