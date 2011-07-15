using System;
using System.Collections.Generic;
using System.Text;

namespace KalSharp.Packets 
{
    class DeletedPlayerList : PacketOut
    {
        const int STORE_DAYS = 14;

        public DeletedPlayerList(IList<PlayerDeleted> DeletedPlayerList)
            : base(0x19)
        {
            ushort packetSize = 1;



            foreach (PlayerDeleted dPlayer in DeletedPlayerList)
            {
                if (dPlayer.Player == null)
                {
                    continue;
                }
                packetSize += 8;
                packetSize += (ushort)dPlayer.Player.Name.Length;
            }

            this.SetCapacity(packetSize);

            writer.Write((byte)DeletedPlayerList.Count);
            foreach (PlayerDeleted dPlayer in DeletedPlayerList)
            {
                if (dPlayer.Player == null)
                {
                    continue;
                }
                writer.Write(dPlayer.Player.PID);
                writer.Write(dPlayer.Player.Name.ToCharArray());
                writer.Write((byte)0);
                writer.Write((byte)dPlayer.Player.Level);
                writer.Write((byte)dPlayer.Player.Class);

                TimeSpan diff = DateTime.Today - dPlayer.DeletedTime;
                byte daysLeft = (byte)(STORE_DAYS - diff.Days);

                writer.Write(daysLeft);
            }
        }
    }
}
