using System;

namespace KalSharp.Translators
{
    public partial class PacketTranslator
    {
        public static void EndPlayerMove(Client client, PacketIn packet)
        {
            sbyte dx = packet.ReadSByte();
            sbyte dy = packet.ReadSByte();
            sbyte dz = packet.ReadSByte();
            client.Character.MoveEnd(dx, dy, dz);
            
        }
        
        public static void PlayerMove(Client client, PacketIn packet)
        {
            sbyte dx = packet.ReadSByte();
            sbyte dy = packet.ReadSByte();
            sbyte dz = packet.ReadSByte();
            client.Character.Move(dx, dy, dz);
            
        }
    }
}
