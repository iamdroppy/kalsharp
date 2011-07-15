using System;

namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void Init(Client client, PacketIn packet)
		{
			client.SendInit();
		}
	}
}
