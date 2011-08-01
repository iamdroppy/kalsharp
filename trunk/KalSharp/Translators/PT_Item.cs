using System;
using KalSharp.Worlds.Items;
using KalSharp.Worlds.Characters;
using KalSharp.Configs.Items.ItemCodes;
using KalSharp.Configs.Items.ItemCodes.Handlers;
using KalSharp.Worlds.Drops;
using KalSharp.Worlds;

namespace KalSharp.Translators
{
    public partial class PacketTranslator
    {
        public static void EquipItem(Client client, PacketIn packet)
        {
            int IID = (int)packet.ReadUInt32();

            PlayerItem pItem = PlayerItem.GetItem(IID);

            //check if the item exists
            if (pItem == null)
            {
                Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
                return;
            }

            //check if player owns the item
            if (pItem.PID != client.Character.Player.PID)
            {
                Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
                return;
            }

            CodeHandler handler = CodeManager.GetHandler(pItem.Item.Code);

            handler.Equip(pItem, client.Character, client);
        }

        public static void UnequipItem(Client client, PacketIn packet)
        {
            int IID = (int)packet.ReadUInt32();

            PlayerItem pItem = PlayerItem.GetItem(IID);

            //check if the item exists
            if (pItem == null)
            {
                Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
                return;
            }

            //check if player owns the item
            if (pItem.PID != client.Character.Player.PID)
            {
                Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
                return;
            }

            CodeHandler handler = CodeManager.GetHandler(pItem.Item.Code);

            handler.Unequip(pItem, client.Character, client);
 
        }

        public static void UseItem(Client client, PacketIn packet)
        {
            Utilities.DumpUnusedPacket("PT_UseItem", packet);
        }

        public static void DropItem(Client client, PacketIn packet)
        {
            int IID = (int)packet.ReadUInt32();
            PlayerItem pItem = PlayerItem.GetItem(IID);

            int quantity = (int)packet.ReadUInt32();

            //check if the item exists
            if (pItem == null)
            {
                Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
                return;
            }

            //check if player owns the item
            if (pItem.PID != client.Character.Player.PID)
            {
                Hackshield.AddOffense(client, OffenseSeverity.IncorrectPacketDetails);
                return;
            }

            CodeHandler handler = CodeManager.GetHandler(pItem.Item.Code);

            handler.Drop(pItem, quantity, client.Character, client);
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

            CodeHandler handler = CodeManager.GetHandler(drop.PlayerItem.Item.Code);

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
