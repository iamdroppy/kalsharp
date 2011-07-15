using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void PlayersInSight(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_PlayersInSight",packet);
		}
	}
}
