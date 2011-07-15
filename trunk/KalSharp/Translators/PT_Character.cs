using System;


namespace KalSharp.Translators
{
    public partial class PacketTranslator
    {
        public static void PlayerChange(Client client, PacketIn packet)
        {
            byte b = packet.ReadByte();
            if(b == 1) {
                client.Send(new Packets.AcceptChange());
                client.UnspawnPlayer();
                client.SendPlayerList();
                return;
            }
        }
        
        public static void PlayerSelect(Client client, PacketIn packet)
		{
			client.PlayerSelect((int)packet.ReadUInt32());
		}
		
		public static void CreatePlayer(Client client, PacketIn packet)
		{
			string name       = packet.ReadString();
			byte type         = packet.ReadByte();
			byte strength     = packet.ReadByte();
			byte health       = packet.ReadByte();
			byte intelligence = packet.ReadByte();
			byte wisdom       = packet.ReadByte();
			byte agility      = packet.ReadByte();
			byte face         = packet.ReadByte();
			byte hair         = packet.ReadByte();

			if((strength + health + intelligence + wisdom + agility) != 5)
            {
                client.Send(new Packets.CharacterCreationError(Packets.CHARACTER_CREATION_ERROR.SHARING_POINTS_ERROR));
				Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
				return;
			}
            
            //check if name is valid
            if (!Utilities.IsAlnum(name))
            {
                client.Send(new Packets.CharacterError(Packets.CHARACTER_ERROR.INVALID_CHARS));
                return;
            }

            //check if player name is taken
            if (Player.GetPlayer(name) != null)
            {
                client.Send(new Packets.CharacterCreationError(Packets.CHARACTER_CREATION_ERROR.NAME_TAKEN));
                return;
            }

			int playerId = client.CreatePlayer(name, type, strength, health, intelligence, wisdom, agility, face, hair);
			client.SendPlayerList();
		}
		
		public static void DeletePlayer(Client client, PacketIn packet)
		{
            int pid = (int)packet.ReadUInt32();
            client.DeletePlayer(pid);
            client.SendPlayerList();
        }
        
        public static void RestorePlayer(Client client, PacketIn packet)
		{
            int pid = (int)packet.ReadUInt32();
            client.RestorePlayer(pid);
            client.Send(new Packets.DisconnectMessage(Packets.DISCONNECT_MESSAGE.RESTORING_CHARACTER_COMPLETED));
		}
		
		public static void SetRevivalPoint(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_SetRevivalPoint",packet);
		}
		
		public static void ChangePlayerName(Client client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_ChangePlayerName",packet);
		}
    }
}