using System;
using System.Collections.Generic;
using System.Text;
using KalSharp.Worlds;

namespace KalSharp.Translators 
{
    public partial class PacketTranslator 
    {
		public static void SpawnPlayer(Client Client, PacketIn packet)
        {
            if(Client.Authenticated) 
            {
                ServerWorld.AddEntity(Client.Character);
                Client.Send(new Packets.SendSkills(Client.Character.Player));
			    if(Client.Character.Inventory.Items.Count > 0)
                {
                    Client.Send(new Packets.SendInventory(Client.Character.Inventory));
			    }
                else
                {
                    Client.Send(new Packets.LoginAccepted());
                }
                Client.Send(new Packets.SpawnPlayer(Client.Character, true));
            }
		}
    }
}
