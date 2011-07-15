using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
		public static void Transform(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_Transform",packet);
		}
		
		public static void ExecuteTransform(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_ExecuteTransform",packet);
		}
	}
}
