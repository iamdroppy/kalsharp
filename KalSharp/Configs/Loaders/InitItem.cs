using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs;
using Kml;
using KalSharp.Configs.ConfigPropertyTypes;
using KalSharp.Configs.Quests;
using KalSharp.Configs.InitItems;
using KalSharp.Configs.InitItems.ItemCodes;
using KalSharp.Configs.InitItems.Specialties;

namespace KalSharp.Configs.Loaders
{
    class InitItem : ConfigLoader
    {
        public override ConfigType Load(KmlNode Node)
        {
            InitItems.InitItem item = new InitItems.InitItem();

            foreach (KmlNode childNode in Node.ChildNodes)
            {
                try
                {
                    switch (childNode.FirstValue.ToLower())
                    {
                        case "name":
                            item.Name = childNode.Values[1].ValueAsInt;
                            break;
                        case "index":
                            item.Index = childNode.Values[1].ValueAsInt;
                            break;
                        case "buy":
                            item.Buy = childNode.Values[1].ValueAsInt;
                            break;
                        case "class":
                            item.Class = new Class(childNode.Values[1].Value, childNode.Values[2].Value);
                            break;
                        case "code":
                            item.Code = new Code(childNode.Values[1].ValueAsInt, childNode.Values[2].ValueAsInt, childNode.Values[3].ValueAsInt, childNode.Values[4].ValueAsInt);
                            break;
                        case "cooltime":
                            item.Cooltime = childNode.Values[1].ValueAsInt;
                            break;
                        case "country":
                            bool International = false;
                            bool Korea = false;
                            bool China = false;
                            foreach (KmlValue value in childNode.Values)
                            {
                                if (value.Value == "1")
                                {
                                    Korea = true;
                                }
                                if (value.Value == "2")
                                {
                                    International = true;
                                }
                                if (value.Value == "3")
                                {
                                    China = true;
                                }
                            }
                            item.Country = new Country(Korea, International, China);
                            break;
                        case "effect":
                            item.Effect = childNode.Values[1].ValueAsInt;
                            break;
                        case "endurance":
                            item.Endurance = childNode.Values[1].ValueAsInt;
                            break;
                        case "level":
                            item.Level = childNode.Values[1].ValueAsInt;
                            break;
                        case "limit":
                            int classLimit = 0;
                            if (childNode.Values[1].Value.ToLower() == "knight")
                            {
                                classLimit = 0;
                            }
                            if (childNode.Values[1].Value.ToLower() == "mage")
                            {
                                classLimit = 1;
                            }
                            if (childNode.Values[1].Value.ToLower() == "archer")
                            {
                                classLimit = 2;
                            }
                            item.Limit = new Limit(classLimit, childNode.Values[2].ValueAsInt);
                            break;
                        case "maxprotect":
                            item.MaxProtect = childNode.Values[1].ValueAsInt;
                            break;
                        case "pay":
                            item.Pay = childNode.Values[1].ValueAsInt;
                            break;
                        case "plural":
                            item.Plural = childNode.Values[1].ValueAsInt;
                            break;
                        case "race":
                            item.Race = childNode.Values[1].ValueAsInt;
                            break;
                        case "range":
                            item.Range = childNode.Values[1].ValueAsInt;
                            break;
                        case "sell":
                            item.Sell = childNode.Values[1].ValueAsInt;
                            break;
                        case "use":
                            item.Use = childNode.Values[1].ValueAsInt;
                            break;
                        case "warrelation":
                            item.WarRelation = childNode.Values[1].ValueAsInt;
                            break;
                        case "specialty":
                            item.Specialty = LoadSpecialty(childNode);
                            break;


                    }
                }
                catch (Exception ex)
                {
                    ServerConsole.WriteLine("Error in {0} as error {1}", MessageLevel.Error, childNode.FirstValue, ex);
                }
            }

            return item;
        }

        public Specialty LoadSpecialty(KmlNode Node)
        {
            Specialty spec = new Specialty();
            foreach (KmlNode childNode in Node.ChildNodes)
            {
                try
                {
                switch (childNode.FirstValue.ToLower())
                {
                    case "attack":
                        if (childNode.Values.Count == 3)
                        {
                            spec.Attack = new Attack((ushort)childNode.Values[1].ValueAsInt, (ushort)childNode.Values[2].ValueAsInt);
                        }
                        else
                        {
                            spec.Attack = new Attack((ushort)childNode.Values[1].ValueAsInt, (ushort)childNode.Values[2].ValueAsInt, (ushort)childNode.Values[3].ValueAsInt);
                        }
                        break;
                    case "magic":
                        if (childNode.Values.Count == 3)
                        {
                            spec.Magic = new Magic((ushort)childNode.Values[1].ValueAsInt, (ushort)childNode.Values[2].ValueAsInt);
                        }
                        else
                        {
                            spec.Magic = new Magic((ushort)childNode.Values[1].ValueAsInt, (ushort)childNode.Values[2].ValueAsInt, (ushort)childNode.Values[3].ValueAsInt);
                        }
                        break;
                    case "changeprefix":
                        spec.ChangePrefix = new ChangePrefix(childNode.Values[1].Value,childNode.Values[2].ValueAsInt,childNode.Values[3].ValueAsInt,childNode.Values[4].ValueAsInt,childNode.Values[5].ValueAsInt);
                        break;
                    case "dex":
                        spec.Dexterity = (byte)childNode.Values[1].ValueAsInt;
                        break;
                    case "hth":
                        spec.Health = (byte)childNode.Values[1].ValueAsInt;
                        break;
                    case "int":
                        spec.Intelligence = (byte)childNode.Values[1].ValueAsInt;
                        break;
                    case "str":
                        spec.Strength = (byte)childNode.Values[1].ValueAsInt;
                        break;
                    case "wis":
                        spec.Wisdom = (byte)childNode.Values[1].ValueAsInt;
                        break;
                    case "absorb":
                        spec.Absorb = (byte)childNode.Values[1].ValueAsInt;
                        break;
                    case "aspeed":
                        spec.AttackSpeed = (ushort)childNode.Values[1].ValueAsInt;
                        break;
                    case "buff":
                        if (childNode.Values.Count == 4)
                        {
                            spec.Buff = new Buff(childNode.Values[1].ValueAsInt, childNode.Values[2].ValueAsInt, childNode.Values[3].ValueAsInt);
                        }
                        if (childNode.Values.Count == 3)
                        {
                            spec.Buff = new Buff(childNode.Values[1].ValueAsInt, childNode.Values[2].ValueAsInt);
                        }
                        break;
                    case "charming":
                        spec.Charming = new Charming(childNode.Values[1].Value);
                        break;
                    case "defense":
                        spec.Defense = (ushort)childNode.Values[1].ValueAsInt;
                        break;
                    case "dodge":
                        spec.Dodge = (ushort)childNode.Values[1].ValueAsInt;
                        break;
                    case "gstate":
                        spec.GState = new GState((GStateValue)childNode.Values[1].ValueAsInt);
                        break;
                    case "hit":
                        spec.Hit = (ushort)childNode.Values[1].ValueAsInt;
                        break;
                    case "hp":
                        spec.HealthPoints = (ushort)childNode.Values[1].ValueAsInt;
                        break;
                    case "mp":
                        spec.MagicPoints = (ushort)childNode.Values[1].ValueAsInt;
                        break;
                    case "mspeed":
                        spec.MoveSpeed = new MoveSpeed(childNode.Values[1].ValueAsInt, childNode.Values[2].ValueAsInt);
                        break;
                    case "protect":
                        spec.Protect = true;
                        break;
                    case "repair":
                        spec.Repair = childNode.Values[1].ValueAsInt;
                        break;
                    case "resistcurse":
                        spec.ResistCurse = (ushort)childNode.Values[1].ValueAsInt;
                        break;
                    case "resistfire":
                        spec.ResistFire = (ushort)childNode.Values[1].ValueAsInt;
                        break;
                    case "resistice":
                        spec.ResistIce = (ushort)childNode.Values[1].ValueAsInt;
                        break;
                    case "resistlitning":
                        spec.ResistLightning = (ushort)childNode.Values[1].ValueAsInt;
                        break;
                    case "resistpalsy":
                        spec.ResistParalysis = (ushort)childNode.Values[1].ValueAsInt;
                        break;
                    case "refresh":
                        spec.Refresh = new Refresh(childNode.Values[1].Value, childNode.Values[2].ValueAsInt);
                        break;
                    case "revival":
                        spec.Revival = (ushort)childNode.Values[1].ValueAsInt;
                        break;
                    case "teleport":
                        spec.Teleport = new Teleport((TeleportType)childNode.Values[1].ValueAsInt, (TeleportLocation)childNode.Values[2].ValueAsInt);
                        break;
                    default:
                        ServerConsole.WriteLine("No property set for specialty {0}", MessageLevel.Warning, childNode.FirstValue.ToLower());
                        break;
                }
                }
                catch (Exception ex)
                {
                    ServerConsole.WriteLine("Error in {0} as error {1}", MessageLevel.Error, childNode.FirstValue, ex);
                }
            }

            return spec;
        }

    }
}
