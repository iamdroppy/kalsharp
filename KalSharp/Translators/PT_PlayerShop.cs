using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void CreateShop(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_CreateShop",packet);
		}
		
		public static void AddShopItem(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_AddShopItem",packet);
		}
		
		public static void RemoveShopItem(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_RemoveShopItem",packet);
		}
		
		public static void ToggleShop(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_ToggleShop",packet);
		}
		
		public static void ViewShop(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_ViewShop",packet);
		}
		
		public static void BuyShopItem(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_BuyShopItem",packet);
		}
	}
}
