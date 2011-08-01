using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs.Maps;
using KalSharp.Worlds.Npcs;

namespace KalSharp.Worlds
{
    public static class ServerWorld
    {
        /// <summary>
        /// Pool of available world IDs
        /// </summary>
        private static Stack<UInt32> IdentPool;

        /// <summary>
        /// Loaded maps.
        /// </summary>
        private static Map[,] Maps;

        /// <summary>
        /// Thinker for this world.
        /// </summary>
        public static Thinker Thinker;

        /// <summary>
        /// List of entities.
        /// </summary>
        public static Dictionary<UInt32, WorldEntity> Entities;

        public const int ENTITY_VIEW_DISTANCE = 1000;


        /// <summary>
        /// Server country;
        /// </summary>
        public static int Country;

        public static void Load(int Country)
        {
            ServerConsole.WriteLine("Loading world.", MessageLevel.Message);

            ServerWorld.Country = Country;

            Entities = new Dictionary<UInt32, WorldEntity>();

            //populate identpool
            IdentPool = new Stack<UInt32>();
            for (ushort i = ushort.MaxValue; i > 0; i--)
            {
                IdentPool.Push(i);
            }

            //begin loading object
            LoadMaps();
            LoadNPCs();
            LoadEvents();

            ServerConsole.WriteLine("World prepared", MessageLevel.Message);
        }

        /// <summary>
        /// Load all NPCs.
        /// </summary>
        private static void LoadNPCs()
        {
            ServerConsole.WriteLine("Loading NPCs", MessageLevel.Message);

            foreach(Configs.GenNpc.GenNpc genNpc in Configs.ConfigManager.GenNpc)
            {
                //check if its available to this country
                if (genNpc.Countries.Contains(ServerWorld.Country))
                {
                    //Npcs.Add(genNpc.Index, new Npc());
                }
            }
        }

        /// <summary>
        /// Load all maps.
        /// </summary>
        private static void LoadMaps()
        {
            ServerConsole.WriteLine("Loading Maps", MessageLevel.Message);
        }

        /// <summary>
        /// Loads timed events.
        /// </summary>
        private static void LoadEvents()
        {
            ServerConsole.WriteLine("Loading Events", MessageLevel.Message);

            Thinker = new Thinker();
            Thinker.Start();

            //entities in view
            Thinker.Add(1, new DelegateThought.ThoughtCallback(UpdateEntitiesInView));
        }

        /// <summary>
        /// Recalculates entities in view for each entitie.
        /// </summary>
        /// <param name="thought"></param>
        /// <param name="Params"></param>
        public static void UpdateEntitiesInView(Thought thought, object[] Params)
        {
            lock (typeof(ServerWorld))
            {
                foreach (WorldEntity entity in Entities.Values)
                {
                    entity.UpdateEntitiesInView(false);
                }
            }

            //requeue
            Thinker.Requeue(1, thought);
        }

        private static uint NewId()
        {
            return IdentPool.Pop();
        }

        private static void FreeId(uint ID)
        {
            IdentPool.Push(ID);
        }

        public static void AddEntity(WorldEntity Entity)
        {
            Entity.WorldId = NewId();
            Entities.Add(Entity.WorldId, Entity);
            Entity.UpdateEntitiesInView(true);
        }

        public static void RemoveEntity(WorldEntity Entity)
        {
            Entities.Remove(Entity.WorldId);
            FreeId(Entity.WorldId);
        }       

    }
}
