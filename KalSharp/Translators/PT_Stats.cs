using System;
using System.Collections;
using System.Collections.Generic;


namespace KalSharp.Translators
{
    public partial class PacketTranslator
    {
        private static void _UpdateStats(Client Client,int Start, int Value)
        {
            if(Value < Start) {
                Client.Character.Player.StatPoints -= 1; 
            } else if(Value >= Start && Value < (Start+20)) {
                Client.Character.Player.StatPoints -= 2;        
            } else if(Value >= (Start+20) && Value < (Start+40)) {
                Client.Character.Player.StatPoints -= 3; 
            } else if(Value >= (Start+40) && Value < (Start+60)) {
                Client.Character.Player.StatPoints -= 4; 
            } else if(Value >= (Start+60) && Value < (Start+80)) {
                Client.Character.Player.StatPoints -= 5; 
            } else if(Value >= (Start+80) && Value < (Start+100)) {
                Client.Character.Player.StatPoints -= 6; 
            } else if(Value >= (Start+100) && Value < (Start+120)) {
                Client.Character.Player.StatPoints -= 7; 
            } else {
                Client.Character.Player.StatPoints -= 8; 
            }
            
            Client.Send(new Packets.ValueChange(0x17,(ushort)Client.Character.Player.StatPoints));
        }
        
        public static void ResetStats(Client Client, PacketIn packet)
		{
		    Utilities.DumpUnusedPacket("PT_ResetStats",packet);
		}
        
        public static void SetStats(Client Client, PacketIn packet)
        {
            int Start;
            int Value;
            
            switch(packet.ReadByte()) 
            {
                // Strength
                case 0:	
				{
                    Start = (Client.Character.Player.Class == 0) ? 60 : 50;
                    Value = Client.Character.Stats.BaseStats.Strength;
                    
                    _UpdateStats(Client,Start,Value);

                    Client.Character.Stats.BaseStats.Strength += 1;
                    Client.Send(new Packets.StatPacket.Strength(Client.Character));

                    break;
                }
                // Health
                case 1:	
				{
                    Start = 50;
                    Value = Client.Character.Stats.Health;
                    
                    _UpdateStats(Client,Start,Value);

                    Client.Character.Stats.BaseStats.Health += 1;
                    Client.Send(new Packets.StatPacket.Health(Client.Character));
    
                    break;
                }
                // Intelligence
                case 2:	
				{
                    Start = (Client.Character.Player.Class == 1) ? 60 : 50;
                    Value = Client.Character.Stats.Intelligence;
                    
                    _UpdateStats(Client,Start,Value);

                    Client.Character.Stats.BaseStats.Intelligence += 1;
                    Client.Send(new Packets.StatPacket.Intelligence(Client.Character));
                    
                    break;
                }
                // Wisdom
                case 3:	
				{
                    Start = 50;
                    Value = Client.Character.Stats.Wisdom;
                    
                    _UpdateStats(Client,Start,Value);

                    Client.Character.Stats.BaseStats.Wisdom += 1;
                    Client.Send(new Packets.StatPacket.Wisdom(Client.Character));
                    
                    break;
                }
                // Agility
                case 4:
				{
                    Start = (Client.Character.Player.Class == 2) ? 60 : 50;
                    Value = Client.Character.Stats.Dexterity;
                    
                    _UpdateStats(Client,Start,Value);

                    Client.Character.Stats.BaseStats.Dexterity += 1;
                    Client.Send(new Packets.StatPacket.Agility(Client.Character));
                    
                    break;
                }
            }
        }
    }
}
