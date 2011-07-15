using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Items;
using KalSharp.Worlds.Stats;

namespace KalSharp.Worlds.Characters
{
    public class Character : WorldEntity
    {
        public Player Player;
        public Client Client;
        public Inventory Inventory;

        public Character(Player Player, Client Client)
        {
            this.Player = Player;
            this.Client = Client;
            this.Stats = new EntityStats(this, new CharacterBaseStats(this));
            this.Position = new CharacterPosition(this);
            Inventory = new Inventory(this);
        }

        public override bool IsAlive
        {
            get
            {
                return Player.Killed != 1;
            }
            set
            {
                if (value)
                {
                    Player.Killed = 0;
                }
                else
                {
                    Player.Killed = 1;
                }
            }
        }

        public override Int16 CurrentHP
        {
            get
            {
                return Player.CurrentHP;
            }
            set
            {
                Player.CurrentMP = value;
            }
        }

        public override Int16 CurrentMP
        {
            get
            {
                return Player.CurrentMP;
            }
            set
            {
                Player.CurrentMP = value;
            }
        }

        public override Gear Gear
        {
            get
            {
                return Player.Gear;
            }
            set
            {
                Player.Gear = (PlayerGear)value;
            }
        }

        /// <summary>
        /// Shows html to the player controlling the player.
        /// </summary>
        /// <param name="HtmlID"></param>
        public void ShowHtml(int HtmlID)
        {
            //show html
        }

        /// <summary>
        /// Sends a message to everyone in view.
        /// </summary>
        public void Chat(string Message)
        {
            lock (EntitiesInView)
            {
                foreach (Character character in EntitiesInView)
                {
                    character.Client.Send(new Packets.Chat(Player.Name, Message, new object[] {}));
                }
            }
        }

        public override void AddEntityInView(WorldEntity Entity)
        {
            Type entType = Entity.GetType();

            if (entType == typeof(Character))
            {
                Client.Send(new Packets.SpawnPlayer(Entity as Character, false));
            }
            if (entType == typeof(Drops.Drop))
            {
                Client.Send(new Packets.SpawnDrop(Entity as Drops.Drop));
            }
            if (entType == typeof(Npcs.Npc))
            {
                Client.Send(new Packets.SpawnNpc(Entity as Npcs.Npc));
            }

            base.AddEntityInView(Entity);
        }

        public override void RemoveEntityInView(WorldEntity Entity)
        {
            Type entType = Entity.GetType();

            if (entType == typeof(Character))
            {
                Client.Send(new Packets.Unspawn(Entity.WorldId));
            }
            if (entType == typeof(Drops.Drop))
            {
                ServerConsole.WriteLine("Unspawning drop");
                Client.Send(new Packets.UnspawnDrop(Entity as Drops.Drop));
            }
            if (entType == typeof(Npcs.Npc))
            {
                Client.Send(new Packets.Unspawn(Entity.WorldId));
            }

            base.RemoveEntityInView(Entity);
        }

        /// <summary>
        /// Sends stat update packets to client.
        /// </summary>
        public void UpdateStats()
        {
            Client.Send(new Packets.StatPacket.Strength(this));
            Client.Send(new Packets.StatPacket.Health(this));
            Client.Send(new Packets.StatPacket.Intelligence(this));
            Client.Send(new Packets.StatPacket.Wisdom(this));
            Client.Send(new Packets.StatPacket.Agility(this));
            Client.Send(new Packets.StatPacket.Absorption(this));
            Client.Send(new Packets.StatPacket.Attack(this));
            Client.Send(new Packets.StatPacket.Magic(this));
            Client.Send(new Packets.StatPacket.AttackSpeed(this));
            Client.Send(new Packets.StatPacket.Contribution(this));
            Client.Send(new Packets.StatPacket.Defense(this));
            Client.Send(new Packets.StatPacket.Evasion(this));
            Client.Send(new Packets.StatPacket.OTP(this));
            Client.Send(new Packets.StatPacket.PUPoint(this));
            Client.Send(new Packets.StatPacket.SUPoint(this));

            Client.Send(new Packets.StatPacket.FireResistance(this));
            Client.Send(new Packets.StatPacket.IceResistance(this));
            Client.Send(new Packets.StatPacket.LightningResistance(this));
            Client.Send(new Packets.StatPacket.CurseResistance(this));
            Client.Send(new Packets.StatPacket.ParalysisResistance(this));
        }
    }
}
