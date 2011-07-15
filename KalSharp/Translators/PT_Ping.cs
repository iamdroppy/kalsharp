using System;

namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void Ping(Client client, PacketIn packet)
		{
            ServerConsole.WriteLine("Recieved Ping");
            //there seems to be a bug with ping, an incorrect packet length is specified.
		}
	}
}
