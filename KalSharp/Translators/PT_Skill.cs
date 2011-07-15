using System;
using System.Collections.Generic;
using System.Text;


using KalSharp.Packets;

namespace KalSharp.Translators 
{
    //public partial class PacketTranslator
    //{
    //    public static void ResetSkills(Client client, PacketIn packet)
    //    {
    //        Utilities.DumpUnusedPacket("PT_ResetSkills",packet);
    //    }
		
    //    public static void SkillExecute(Client client, PacketIn packet)
    //    {
    //        byte skillId  = packet.ReadByte();
    //        byte skillLvl = packet.ReadByte();

    //        client.SkillHandler.Execute(skillId,skillLvl);

    //        if(packet.PacketSize < 9) {
    //            client.Send(new Packets.SkillExecute(client.Player,skillId,skillLvl));
    //            return;
    //        }
    //    }   
		
    //    public static void SkillRequest(Client client,PacketIn packet)
    //    {
    //        byte skillId  = packet.ReadByte();
    //        uint playerId = packet.ReadUInt32();
			
    //        client.SkillHandler.Request(skillId,playerId);
			
    //        client.Send(new Packets.SkillExecute(client.Player,skillId,1));
    //    } 
		
    //    public static void LearnSkill(Client client, PacketIn packet)
    //    {   
    //        byte skillId = packet.ReadByte();
    //        if(client.Player.Player.SkillPoints >= 1)
    //        {
    //            if(!client.Player.Skills.ContainsKey(skillId)) 
    //            {
    //                using(ISession session = Server.Factory.OpenSession())
    //                {
    //                    PlayerSkill skill = new PlayerSkill();
    //                    skill.Level       = 1;
    //                    skill.PlayerId    = client.Player.Player.PlayerId;
    //                    skill.SkillIndex  = (int)skillId;
		                
    //                    client.Player.Skills[skillId] = skill;
    //                    client.Send(new Packets.SkillSet(skillId,(byte)1));

    //                    using(ITransaction transaction = session.BeginTransaction())
    //                    {
    //                        session.Save(skill);
    //                        transaction.Commit();
    //                    }
    //                }
    //                client.Player.Player.SkillPoints--;
    //                client.Send(new Packets.ValueChange(0x18,(byte)client.Player.Player.SkillPoints));
    //            }		        
    //        }
    //    }
		
    //    public static void UpgradeSkill(Client client, PacketIn packet)
    //    {
    //        byte skillId = packet.ReadByte();
    //        if(client.Player.Player.SkillPoints >= 1)
    //        {
    //            if(client.Player.Skills.ContainsKey(skillId)) 
    //            {
    //                client.Player.Skills[skillId].Level += 1;
    //                client.Send(new Packets.SkillSet(skillId,(byte)client.Player.Skills[skillId].Level));
    //                using(ISession session = Server.Factory.OpenSession()) 
    //                using(ITransaction transaction = session.BeginTransaction())
    //                {
    //                    session.SaveOrUpdate(client.Player.Skills[skillId]);
    //                    transaction.Commit();
    //                }

    //                client.Player.Player.SkillPoints--;
    //                client.Send(new Packets.ValueChange(0x18,(byte)client.Player.Player.SkillPoints));
    //            }		        
    //        }
    //    }
    //}
}
