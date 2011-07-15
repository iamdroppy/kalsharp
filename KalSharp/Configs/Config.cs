using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using KalSharp.Configs.Loaders;
using System.Collections;
using Kml;

namespace KalSharp.Configs
{
    public static class Config
    {
        //list of config loaders
        private static Dictionary<string, ConfigLoader> configLoaders = new Dictionary<string, ConfigLoader>();
        //stores our config in kml form
        private static KmlDocument configKml;

        public static void LoadConfigFiles(string Directory)
        {
            configKml = new KmlDocument();

            ServerConsole.WriteLine("Loading config files");

            //get directory info
            DirectoryInfo di = new DirectoryInfo(Directory);
            //cycle each file inside
            foreach (FileInfo fi in di.GetFiles())
            {
                //load into kdoc
                configKml.LoadFromFile(fi.FullName);
                ServerConsole.WriteLine("Loading config: {0}", MessageLevel.Message, fi.Name);
            }
        }

        public static void ReadConfig()
        {
            //cycle each child node of configKml
            foreach (KmlNode kNode in configKml.ChildNodes)
            {
                string configName = kNode.FirstValue.ToLower();
                //check if there is a loader assigned for it
                if (configLoaders.ContainsKey(configName))
                {
                    try
                    {
                        //load the config
                        ConfigType configType = configLoaders[configName].Load(kNode);

                        AssignToDictionary(configName, configType);
                    }
                    catch (Exception ex)
                    {
                        ServerConsole.WriteLine("Error loading config {0} on line {1}", MessageLevel.Warning, configName, kNode.StartPosition.Row);
                        ServerConsole.WriteLine("{0}", MessageLevel.Warning, ex.Message);
                    }

                }
                else
                {
                    ServerConsole.WriteLine("Unable to find config loader for node {0} on line {1}", MessageLevel.Warning, kNode.FirstValue, kNode.StartPosition.Row);
                }
            }

        }

        private static void AssignToDictionary(string ConfigName, ConfigType ConfigType)
        {

            switch (ConfigName)
            {
                case "genmonster":
                    GenMonster.Add((GenMonster)ConfigType);
                    break;
                case "quest":
                    Quest.Add((Quests.Quest)ConfigType);
                    break;
                case "initmap":
                    InitMap.Add((Configs.InitMap)ConfigType);
                    break;
                case "gennpc":
                    GenNpc.Add((Configs.GenNpc)ConfigType);
                    break;
                case "item":
                    InitItem.Add((InitItems.InitItem)ConfigType);
                    break;
            }

        }

        public static void Initialize()
        {
            ServerConsole.WriteLine("Initializing Configs");

            //config loaders
            configLoaders.Add("genmonster", new Loaders.GenMonster());
            configLoaders.Add("quest", new Loaders.Quest());
            configLoaders.Add("initmap", new Loaders.InitMap());
            configLoaders.Add("item", new Loaders.InitItem());
        }

        public static List<Configs.GenMonster> GenMonster = new List<GenMonster>();
        public static List<Quests.Quest> Quest = new List<Quests.Quest>();
        public static List<Configs.InitMap> InitMap = new List<InitMap>();
        public static List<Configs.GenNpc> GenNpc = new List<GenNpc>();
        public static List<InitItems.InitItem> InitItem = new List<InitItems.InitItem>();
    }
}
