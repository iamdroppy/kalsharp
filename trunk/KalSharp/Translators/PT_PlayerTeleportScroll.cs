using System;


namespace KalSharp.Translators
{
	public partial class PacketTranslator
	{
	    /// <summary>
	    /// Using a Saving/Moving scroll.
	    /// </summary>
	    /// <param name="client"></param>
	    /// <param name="packet"></param>
		public static void SetPlayerTeleport(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_Method",packet);
		}
	}
}
