using System;
using KalSharp.Chat;

namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void PlayerChat(Client Client, PacketIn packet)
		{
		    string message = packet.ReadString();
            ChatManager.Chat(Client.Character, message);
		}
	}
}
