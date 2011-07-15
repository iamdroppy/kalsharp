using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KalSharp
{
    /// <summary>
    /// Emulator Utilities
    /// </summary>
    public class Utilities
    {

        /// <summary>
        /// Dump a packet to a decimal output 		
        /// </summary> 		
        /// <param name="buffer"></param> 		
        /// <param name="length"></param>
        public static void ServerDump(byte[] buffer, int length)
        {
            byte serverKey = 56;
            buffer = Crypter.DecodeString(buffer, serverKey);
            if (buffer[2] == 0x2a)
            {
                serverKey = buffer[7];
            }
            int dlength = buffer[0] + (buffer[1] << 8) - 3;
            byte type = buffer[2];

            //if(Utils.ServerFilter(type))
            //{
            //    ServerConsole.WriteLine("--[ SERVER:  Id: {0:x2}  Length: {1} ]--", type, length);
            //    ServerConsole.Write("Decimal: ");
            //    for(int i=0;i<length;i++) {
            //        ServerConsole.Write("{0} ", buffer[i]);
            //    }
            //    ServerConsole.WriteLine(System.Environment.NewLine);
            //}
        }

        /// <summary>
        /// Check about the byte is a server sent byte
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool ServerFilter(byte type)
        {
            switch (type)
            {
                case 0x24:
                case 0x25:
                case 0x33:
                case 0x34:
                case 0x38:
                case 0x39:
                    return false;
            }
            return true;
        }


        public static void DumpUnknown(PacketIn packet)
        {
            ServerConsole.WriteLine("Dumping unknown packet with Id {0:X2}: ",MessageLevel.Warning, packet.PacketType);

            for (int i = 0; i < (packet.PacketSize - 3); i++)
            {
                ServerConsole.WriteLine("{0} ", MessageLevel.Warning, packet.ReadByte());
            }

            ServerConsole.WriteLine("");
        }

        public static void DumpUnusedPacket(string name, PacketIn packet)
        {
            ServerConsole.WriteLine("Dumping unused packet #{0} with Id {1:X2}: ",MessageLevel.Warning, name, packet.PacketType);

            for (int i = 0; i < (packet.PacketSize - 3); i++)
            {
                ServerConsole.WriteLine("{0} ",MessageLevel.Warning, packet.ReadByte());
            }

            ServerConsole.WriteLine("");
        }

        public static bool IsAlnum(string String)
        {
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            if (r.IsMatch(String))
            {
                return true;
            }
            return false;

        }

        public static string DecodePassword(byte[] Password)
        {
            string decoded = "";
            int i = 0;
            while (i < Password.Length)
            {
                decoded += (char)DecodeTable[Password[i]];
                i++;
            }
            Console.WriteLine(decoded);
            return decoded;
        }

        public static Dictionary<byte, char> DecodeTable
        {
            get
            {
                Dictionary<byte, char> table = new Dictionary<byte, char>();
                table.Add(0x95, '!');
                table.Add(0x88, '"');
                table.Add(0x9D, '#');
                table.Add(0x4C, '$');
                table.Add(0xF2, '%');
                table.Add(0x3E, '&');
                table.Add(0xBB, '\'');
                table.Add(0xC0, '(');
                table.Add(0x7F, ')');
                table.Add(0x18, '*');
                table.Add(0x70, '+');
                table.Add(0xA6, ',');
                table.Add(0xE2, '-');
                table.Add(0xEC, '.');
                table.Add(0x77, '/');
                table.Add(0x2C, '0');
                table.Add(0x3A, '1');
                table.Add(0x4A, '2');
                table.Add(0x91, '3');
                table.Add(0x5D, '4');
                table.Add(0x7A, '5');
                table.Add(0x29, '6');
                table.Add(0xBC, '7');
                table.Add(0x6E, '8');
                table.Add(0xD4, '9');
                table.Add(0x40, ':');
                table.Add(0x17, ';');
                table.Add(0x2E, '<');
                table.Add(0xCB, '=');
                table.Add(0x72, '>');
                table.Add(0x9C, '?');
                table.Add(0xA1, '@');
                table.Add(0xFF, 'A');
                table.Add(0xF3, 'B');
                table.Add(0xF8, 'C');
                table.Add(0x9B, 'D');
                table.Add(0x50, 'E');
                table.Add(0x51, 'F');
                table.Add(0x6D, 'G');
                table.Add(0xE9, 'H');
                table.Add(0x9A, 'I');
                table.Add(0xB8, 'J');
                table.Add(0x84, 'K');
                table.Add(0xA8, 'L');
                table.Add(0x14, 'M');
                table.Add(0x38, 'N');
                table.Add(0xCE, 'O');
                table.Add(0x92, 'P');
                table.Add(0x5C, 'Q');
                table.Add(0xF5, 'R');
                table.Add(0xEE, 'S');
                table.Add(0xB3, 'T');
                table.Add(0x89, 'U');
                table.Add(0x7B, 'V');
                table.Add(0xA2, 'W');
                table.Add(0xAD, 'X');
                table.Add(0x71, 'Y');
                table.Add(0xE3, 'Z');
                table.Add(0xD5, '[');
                table.Add(0xBF, '\\');
                table.Add(0x53, ']');
                table.Add(0x28, '^');
                table.Add(0x44, '_');
                table.Add(0x33, '`');
                table.Add(0x48, 'a');
                table.Add(0xDB, 'b');
                table.Add(0xFC, 'c');
                table.Add(0x09, 'd');
                table.Add(0x1F, 'e');
                table.Add(0x94, 'f');
                table.Add(0x12, 'g');
                table.Add(0x73, 'h');
                table.Add(0x37, 'i');
                table.Add(0x82, 'j');
                table.Add(0x81, 'k');
                table.Add(0x39, 'l');
                table.Add(0xC2, 'm');
                table.Add(0x8D, 'n');
                table.Add(0x7D, 'o');
                table.Add(0x08, 'p');
                table.Add(0x4F, 'q');
                table.Add(0xB0, 'r');
                table.Add(0xFE, 's');
                table.Add(0x79, 't');
                table.Add(0x0B, 'u');
                table.Add(0xD6, 'v');
                table.Add(0x23, 'w');
                table.Add(0x7C, 'x');
                table.Add(0x4B, 'y');
                table.Add(0x8E, 'z');
                table.Add(0x06, '{');
                table.Add(0x5A, '|');
                table.Add(0xCC, '}');
                table.Add(0x62, '~');
                return table;
            }
        }
    }
}
