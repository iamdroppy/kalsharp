using System;

namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void Exit(Client client, PacketIn packet)
		{
		    client.Send(new Packets.Exit(),"Client Exit");
		}
	}
}
