using System;
using KalSharp.Worlds.Items;
using KalSharp.Worlds.Characters;
using KalSharp.Configs.InitItems.ItemCodes;
using KalSharp.Configs.InitItems.ItemCodes.Handlers;
using KalSharp.Worlds.Drops;
using KalSharp.Worlds;

namespace KalSharp.Translators
{
    public partial class PacketTranslator
    {
        public static void EquipItem(Client client, PacketIn packet)
        {
            int IID = (int)packet.ReadUInt32();

            Item item = Item.GetItem(IID);

            //check if the item exists
            if (item == null)
            {
                Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
                return;
            }

            //check if player owns the item
            if (item.PID != client.Character.Player.PID)
            {
                Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
                return;
            }

            CodeHandler handler = CodeManager.GetHandler(item.InitItem.Code);

            handler.Equip(item, client.Character, client);
        }

        public static void UnequipItem(Client client, PacketIn packet)
        {
            int IID = (int)packet.ReadUInt32();

            Item item = Item.GetItem(IID);

            //check if the item exists
            if (item == null)
            {
                Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
                return;
            }

            //check if player owns the item
            if (item.PID != client.Character.Player.PID)
            {
                Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
                return;
            }

            CodeHandler handler = CodeManager.GetHandler(item.InitItem.Code);

            handler.Unequip(item, client.Character, client);
 
        }

        public static void UseItem(Client client, PacketIn packet)
        {
            Utilities.DumpUnusedPacket("PT_UseItem", packet);
        }

        public static void DropItem(Client client, PacketIn packet)
        {
            int IID = (int)packet.ReadUInt32();
            Item item = Item.GetItem(IID);

            int quantity = (int)packet.ReadUInt32();

            //check if the item exists
            if (item == null)
            {
                Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
                return;
            }

            //check if player owns the item
            if (item.PID != client.Character.Player.PID)
            {
                Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
                return;
            }

            CodeHandler handler = CodeManager.GetHandler(item.InitItem.Code);

            handler.Drop(item, quantity, client.Character, client);
        }

        public static void PickupDrop(Client client, PacketIn packet)
        {
            UInt32 worldId = packet.ReadUInt32();
            Drop drop;

            //check if the drop exists
            if (ServerWorld.Entities.ContainsKey(worldId))
            {
                drop = ServerWorld.Entities[worldId] as Drop;
            }
            else
            {
                return;
            }

            CodeHandler handler = CodeManager.GetHandler(drop.Item.InitItem.Code);

            handler.Pickup(drop, client.Character, client);
            
        }

        public static void DestroyItem(Client client, PacketIn packet)
        {
            Utilities.DumpUnusedPacket("PT_DestroyItem", packet);
        }

        public static void UpgradeItem(Client client, PacketIn packet)
        {
            Utilities.DumpUnusedPacket("PT_UpgradeItem", packet);
        }

        public static void MixItem(Client client, PacketIn packet)
        {
            Utilities.DumpUnusedPacket("PT_MixItem", packet);
        }
    }
}
