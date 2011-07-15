using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Packets;
using KalSharp.Translators;

namespace KalSharp
{
    public class TranslatorHandler
    {
        public Dictionary<byte, TranslatorMethod> Handlers = new Dictionary<byte, TranslatorMethod>();

        public delegate void TranslatorMethod(Client client, PacketIn packet);

        public void Add(byte packetId, TranslatorMethod translator)
        {
            Handlers[packetId] = translator;
        }

        public void Translate(Client client, byte packetId, PacketIn packet)
        {

            if (!Handlers.ContainsKey(packetId))
            {
                ServerConsole.WriteLine("Unknown Packet Detected.", MessageLevel.Warning);
                PacketTranslator.DumpUnknown(client, packet);
            }
            else
            {
                try
                {
                    Handlers[packetId](client, packet);
                }
                catch (Exception ex)
                {
                    ServerConsole.WriteLine("Translator Error: {0} for packet {1}", MessageLevel.Error, ex.ToString(), packetId);
                }
            }

        }
    }
}
