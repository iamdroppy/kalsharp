using System;

namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void Login(Client client, PacketIn packet)
		{
			string user = packet.ReadString();
			string pass = packet.ReadString();
			ServerConsole.WriteLine("Login request from {0} on ip {1}.", MessageLevel.Message, user, client.IP.ToString());
			client.UserLogin(user, pass);
		}
	}
}
