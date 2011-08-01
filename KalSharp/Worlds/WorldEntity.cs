using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Worlds.Stats;
using KalSharp.Worlds.Characters;
using KalSharp.Worlds.Items;
using KalSharp.Translators;
using KalSharp.Packets;
using KalSharp.Configs.Items.Specialties;

namespace KalSharp.Worlds
{
    public abstract class WorldEntity
    {
        public UInt32 WorldId;
        /// <summary>
        /// Entities that this entity can see.
        /// </summary>
        public List<WorldEntity> EntitiesInView = new List<WorldEntity>();
        /// <summary>
        /// Entity stats.
        /// </summary>
        public EntityStats Stats;
        /// <summary>

        protected Gear gear;
        protected bool isAlive;
        protected Int16 currentHP;
        protected Int16 currentMP;
        protected Vector3 position = new Vector3(0,0,0);
        protected Vector2 direction = new Vector2(0,0);

        public virtual bool IsAlive { get { return isAlive; } set { isAlive = value; } }
        public virtual Int16 CurrentHP { get { return currentHP; } set { currentHP = value; } }
        public virtual Int16 CurrentMP { get { return currentMP; } set { currentMP = value; } }
        public virtual Vector3 Position { get { return position; } set { position = value; } }
        public virtual Vector2 Direction { get { return direction; } set { direction = value; } }
        public virtual Gear Gear { get { return gear; } set { gear = value; } }

        /// <summary>
        /// Kills the character
        /// </summary>
        public void Kill()
        {
            if (IsAlive)
            {
                this.CurrentHP = 0;
                this.CurrentMP = 0;
                lock (this)
                {
                    foreach (Character character in EntitiesInView)
                    {
                        //set dead
                        character.Client.Send(new Packets.SetGState(this, GStateValue.Dead));
                        IsAlive = false;
                    }
                }
            }
        }
        /// <summary>
        /// Begins moving the character to the location given.
        /// </summary>
        /// <param name="Dx">Place to move the character to on the X axis.</param>
        /// <param name="Dy">Place to move the character to on the Y axis.</param>
        /// <param name="Dz">Place to move the character to on the Z axis.</param>
        public virtual void Move(sbyte Dx, sbyte Dy, sbyte Dz)
        {
            this.Position.X += Dx;
            this.Position.Y += Dy;
            this.Position.Z += Dz;

            UpdateEntitiesInView(true);

            lock (this)
            {
                foreach (WorldEntity entity in EntitiesInView)
                {
                    if (entity.GetType() == typeof(Character))
                    {
                        ServerConsole.WriteLine((entity as Character).Player.Name);
                        (entity as Character).Client.Send(new Packets.EntityMove(WorldId, Dx, Dy, Dz));
                    }
                }
            }
        }

        /// <summary>
        /// Ends movement at the location given.
        /// </summary>
        /// <param name="Dx">Place to move the character to on the X axis.</param>
        /// <param name="Dy">Place to move the character to on the Y axis.</param>
        /// <param name="Dz">Place to move the character to on the Z axis.</param>
        public virtual void MoveEnd(sbyte Dx, sbyte Dy, sbyte Dz)
        {
            this.Position.X += Dx;
            this.Position.Y += Dy;
            this.Position.Z += Dz;

            

            lock (this)
            {
                foreach (WorldEntity entity in EntitiesInView)
                {
                    if (entity.GetType() == typeof(Character))
                    {
                        ServerConsole.WriteLine((entity as Character).Player.Name);
                        (entity as Character).Client.Send(new Packets.EntityMove(WorldId, Dx, Dy, Dz));
                    }
                }
            }
        }

        public virtual void AddEntityInView(WorldEntity Entity)
        {
            EntitiesInView.Add(Entity);
        }

        public virtual void RemoveEntityInView(WorldEntity Entity)
        {
            EntitiesInView.Remove(Entity);
        }

        public void UpdateEntitiesInView(bool Ripple)
        {
            lock (typeof(ServerWorld))
            {
                lock (this)
                {
                    //new ents iv to check difference
                    List<WorldEntity> newEntsIV = new List<WorldEntity>();

                    //check if any entities are in view
                    foreach (WorldEntity ent2 in ServerWorld.Entities.Values)
                    {
                            // ServerConsole.WriteLine("{3} Position: {0} Ent2 Position: {1} Distance: {2}", MessageLevel.Message, this.Position, ent2.Position, this.Position.DistanceFrom(ent2.Position), this.GetType());
                            //check if its within view range
                        if (this.Position.DistanceFrom(ent2.Position) <= Settings.Default.EntityViewDistance)
                        {
                            //add it to ents iv
                            newEntsIV.Add(ent2);
                        }

                    }

                    //check for new entities to spawn
                    foreach (WorldEntity entIV in newEntsIV)
                    {
                        //check wether its already in list
                        if (!this.EntitiesInView.Contains(entIV))
                        {
                            //add to entities iv
                            if (entIV.WorldId != this.WorldId)
                            {
                                this.AddEntityInView(entIV);
                                if (Ripple)
                                {
                                    entIV.UpdateEntitiesInView(false);
                                }
                            }
                        }
                    }

                    List<WorldEntity> entitiesToRemove = new List<WorldEntity>();
                    //check for entts to unspawn
                    foreach (WorldEntity oldEntIV in this.EntitiesInView)
                    {
                        if (!newEntsIV.Contains(oldEntIV))
                        {
                            entitiesToRemove.Add(oldEntIV);
                        }
                    }

                    //remove each entitiy
                    foreach (WorldEntity ent in entitiesToRemove)
                    {
                        RemoveEntityInView(ent);
                    }
                    
                }
            }
        }
    }
}
