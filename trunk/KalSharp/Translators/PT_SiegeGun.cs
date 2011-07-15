using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void SiegeGunDisable(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_SigeGunDisable",packet);
		}

		public static void SiegeGunEnable(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_SigeGunEnable",packet);
		}

		public static void SiegeGunControl(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_SigeGunControl",packet);
		}
	}
}
