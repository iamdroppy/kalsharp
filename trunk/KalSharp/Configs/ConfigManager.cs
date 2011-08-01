using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using KalSharp.Configs;
using System.Collections;
using Kml;

namespace KalSharp.Configs
{
    public static class ConfigManager
    {
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
                try
                {
                    switch (configName)
                    {
                        case "genmonster":
                            GenMonsterList.Add(GenMonster.GenMonsterLoader.Load(kNode));
                            break;
                        case "quest":
                            //Quest.Add((Quests.Quest)ConfigType);
                            break;
                        case "initmap":
                            //InitMap.Add((Configs.InitMap)ConfigType);
                            break;
                        case "gennpc":
                            //GenNpc.Add((Configs.GenNpc)ConfigType);
                            break;
                        case "item":
                            ItemList.Add(Items.ItemLoader.Load(kNode));
                            break;
                        default:
                            ServerConsole.WriteLine("Unable to find config loader for node {0} on line {1}", MessageLevel.Warning, kNode.FirstValue, kNode.StartPosition.Row);
                            break;
                    }

                }
                catch (Exception ex)
                {
                    ServerConsole.WriteLine("Error loading config {0} on line {1}", MessageLevel.Warning, configName, kNode.StartPosition.Row);
                    ServerConsole.WriteLine("{0}", MessageLevel.Warning, ex.Message);
                }
            }

        }

        public static List<GenMonster.GenMonster> GenMonsterList = new List<GenMonster.GenMonster>();
        public static List<Quests.Quest> Quest = new List<Quests.Quest>();
        public static List<Maps.Map> InitMapList = new List<Maps.Map>();
        public static List<GenNpc.GenNpc> GenNpc = new List<GenNpc.GenNpc>();
        public static List<Items.Item> ItemList = new List<Items.Item>();
    }
}
