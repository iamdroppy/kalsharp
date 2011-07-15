using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using KalSharp.Packets;
using KalSharp.Translators;
using KalSharp.Worlds.Skills;
using KalSharp.Worlds;
using KalSharp.Worlds.Npcs;
using System.Data;
using NHibernate;
using NHibernate.Cfg;
using KalSharp.Worlds.Characters;

namespace KalSharp
{
    public partial class Client
    {

        /// <summary>
        /// Packet Buffersize
        /// </summary>
        public const int BUFFERSIZE = 1024;

        /// <summary>
        /// Owner of client.
        /// </summary>
        public Account Account;

        /// <summary>
        /// Current player logged in.
        /// </summary>
        public Character Character;

        /// <summary>
        /// Socket used for sending data
        /// </summary>
        private Socket Socket;

        /// <summary>
        /// NHibernate ISession
        /// </summary>
        private ISession session;

        /// <summary>
        /// Packet Buffer
        /// </summary>
        private byte[] _buffer = new byte[BUFFERSIZE];

        /// <summary>
        /// Temp Buffer Size
        /// </summary>
        private int tempSize = 0;

        /// <summary>
        /// Temporary Buffer
        /// </summary>
        private byte[] tempBuffer = new byte[BUFFERSIZE];

        /// <summary>
        /// Client Packet Key
        /// </summary>
        private uint packetKey = 56;

        /// <summary>
        /// Translators
        /// </summary>
        private TranslatorHandler handler = new TranslatorHandler();

        /// <summary>
        /// Skills
        /// </summary>
        private SkillHandler skills = new SkillHandler();

        /// <summary>
        /// How suspicious the hackshield is of the client.
        /// </summary>
        public int Suspicion = 0;

        public bool Disconnected = false;

        private bool authenticated;

        /// <summary>
        /// Returns about a user is autenticated or not
        /// </summary>
        public bool Spawned
        {
            get
            {
                if (Character != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Authenticated
        {
            get
            {
                return authenticated;
            }
        }

        /// <summary>
        /// Returns the current Packet Buffer
        /// </summary>
        public byte[] Buffer
        {
            get { return _buffer; }
        }

        /// <summary>
        /// Return the client IP
        /// </summary>
        public IPAddress IP
        {
            get
            {
                return IPAddress.Parse(
                    ((IPEndPoint)Socket.RemoteEndPoint).Address.ToString()
                );
            }
        }

        public SkillHandler SkillHandler
        {
            get { return skills; }
        }

        /// <summary>
        /// Starts the client, using the Server socket
        /// </summary>
        /// <param name="socket"></param>
        public Client(Socket socket)
        {
            RegisterPacketTranslators();
            RegisterSkills();
            Socket = socket;
        }

        /// <summary>
        /// Register Skills
        /// </summary>
        protected void RegisterSkills()
        {
            //skills.Add(0x08,new Skills.Heal());
        }

        /// <summary>
        /// Register Packet Translators
        /// </summary>
        protected void RegisterPacketTranslators()
        {
            handler.Add(0xA3, PacketTranslator.Init);
            handler.Add(0x00, PacketTranslator.RestorePlayer);
            //handler.Add(0x01,PacketTranslator.AntiCP);
            handler.Add(0x02, PacketTranslator.Login);
            //handler.Add(0x03,PacketTranslator.CheckCRC);
            handler.Add(0x04, PacketTranslator.CreatePlayer);
            //handler.Add(0x05,PacketTranslator.Ping);
            //handler.Add(0x06,PacketTranslator.DublicatePlayer);
            handler.Add(0x07, PacketTranslator.DeletePlayer);
            //handler.Add(0x08,PacketTranslator.RandomConnectInfo);
            handler.Add(0x09, PacketTranslator.ClientVersion);
            handler.Add(0x0A, PacketTranslator.PlayerSelect);
            handler.Add(0x0B, PacketTranslator.SpawnPlayer);
            handler.Add(0x0C, PacketTranslator.Dummy);
            handler.Add(0x0D, PacketTranslator.Dummy);
            handler.Add(0x0E, PacketTranslator.Dummy);
            handler.Add(0x0F, PacketTranslator.Attack);
           // handler.Add(0x10, PacketTranslator.SkillExecute);
            handler.Add(0x11, PacketTranslator.PlayerChat);
            handler.Add(0x12, PacketTranslator.Teleport);
            handler.Add(0x13, PacketTranslator.PlayerChange);
            handler.Add(0x14, PacketTranslator.PlayerMove);
            handler.Add(0x15, PacketTranslator.EndPlayerMove);
            //handler.Add(0x16, PacketTranslator.NpcTalk);
            handler.Add(0x17, PacketTranslator.CastleInfo);
            //handler.Add(0x18, PacketTranslator.BuyNpcItem);
            //handler.Add(0x19, PacketTranslator.SellNpcItem);
            handler.Add(0x1A, PacketTranslator.DropItem);
            handler.Add(0x1B, PacketTranslator.Exit);
            handler.Add(0x1C, PacketTranslator.Trade);
            handler.Add(0x1D, PacketTranslator.PlayersInSight);
            handler.Add(0x1E, PacketTranslator.SetStats);
            handler.Add(0x1F, PacketTranslator.Rest);
            handler.Add(0x20, PacketTranslator.PickupDrop);
           // handler.Add(0x21, PacketTranslator.UseItem);
            handler.Add(0x22, PacketTranslator.RequestTrade);
            handler.Add(0x23, PacketTranslator.OnTradeRequest);
            handler.Add(0x24, PacketTranslator.CancelTrade);
            handler.Add(0x25, PacketTranslator.Revive);
            handler.Add(0x26, PacketTranslator.SiegeGunDisable);
            handler.Add(0x27, PacketTranslator.SiegeGunEnable);
            handler.Add(0x28, PacketTranslator.SiegeGunControl);
            //handler.Add(0x29, PacketTranslator.LearnSkill);
           // handler.Add(0x2A, PacketTranslator.UpgradeSkill);
           // handler.Add(0x2B, PacketTranslator.SkillRequest);
            handler.Add(0x2C, PacketTranslator.RequestParty);
          //  handler.Add(0x2E, PacketTranslator.GuildAction);
            handler.Add(0x2D, PacketTranslator.OnPartyRequest);
            handler.Add(0x2F, PacketTranslator.LeaveParty);
           // handler.Add(0x30, PacketTranslator.KickPartyPlayer);
            handler.Add(0x31, PacketTranslator.BankAdd);
            handler.Add(0x32, PacketTranslator.BankRetrieve);
            handler.Add(0x33, PacketTranslator.CallProcess);
            handler.Add(0x34, PacketTranslator.BankInfo);
            handler.Add(0x35, PacketTranslator.Dummy);
            handler.Add(0x36, PacketTranslator.Dummy);
            handler.Add(0x37, PacketTranslator.Dummy);
            handler.Add(0x38, PacketTranslator.SetRevivalPoint);
            handler.Add(0x39, PacketTranslator.EnchantItem);
            handler.Add(0x3A, PacketTranslator.CreateShop);
            handler.Add(0x3B, PacketTranslator.Dummy);
            handler.Add(0x3C, PacketTranslator.Dummy);
            handler.Add(0x3D, PacketTranslator.Dance);
            handler.Add(0x3E, PacketTranslator.AcceptTrade);
          //  handler.Add(0x3F, PacketTranslator.DestroyItem);
            handler.Add(0x40, PacketTranslator.FriendsList);
            handler.Add(0x41, PacketTranslator.EquipItem);
            handler.Add(0x42, PacketTranslator.UnequipItem);
            handler.Add(0x43, PacketTranslator.ToggleShop);
            handler.Add(0x44, PacketTranslator.DiceSystem);
            handler.Add(0x45, PacketTranslator.StopCrafting);
            handler.Add(0x46, PacketTranslator.ViewShop);
            handler.Add(0x47, PacketTranslator.BuyShopItem);
            handler.Add(0x48, PacketTranslator.MasterOfPRS);
            handler.Add(0x49, PacketTranslator.IsCrafting);
            handler.Add(0x4A, PacketTranslator.MageRevival);
            //handler.Add(0x4B, PacketTranslator.ResetSkills);
            handler.Add(0x4C, PacketTranslator.GoldenLuckyPouch);
            handler.Add(0x4D, PacketTranslator.GoldenPotion);
            handler.Add(0x4E, PacketTranslator.ResetStats);
            handler.Add(0x4F, PacketTranslator.ViewAssassinList);
            handler.Add(0x50, PacketTranslator.RequestPvP);
            handler.Add(0x51, PacketTranslator.OnRequestPvP);
            handler.Add(0x52, PacketTranslator.Transform);
            handler.Add(0x53, PacketTranslator.Buff);
            handler.Add(0x54, PacketTranslator.ExecuteTransform);
            handler.Add(0x55, PacketTranslator.TeacherStudentSystem);
            handler.Add(0x56, PacketTranslator.Dummy);
            handler.Add(0x57, PacketTranslator.Dummy);
            handler.Add(0x58, PacketTranslator.Dummy);
            handler.Add(0x59, PacketTranslator.SessionRequest);
            //handler.Add(0x5A, PacketTranslator.SetPlayerTeleport);
            //handler.Add(0x5B, PacketTranslator.UpgradeItem);
            handler.Add(0x5C, PacketTranslator.Mail);
            handler.Add(0x5D, PacketTranslator.CancelOpenSpecialItem);
            handler.Add(0x5E, PacketTranslator.OpenSpecialItem);
           // handler.Add(0x5F, PacketTranslator.ChangeGuildName);
            handler.Add(0x60, PacketTranslator.ChangePlayerName);
           // handler.Add(0x61, PacketTranslator.NpcSpecial);
           // handler.Add(0x62, PacketTranslator.MixItem);
            handler.Add(0x63, PacketTranslator.BeadOfFire);
        }

        /// <summary>
        /// Process a packet input
        /// </summary>
        /// <param name="buffer"></param>
        public void Process(byte[] buffer)
        {
            try
            {
                PacketIn packet = new PacketIn(buffer, packetKey);
                handler.Translate(this, packet.PacketType, packet);

                if (packet.PacketType == 0xA3)
                {
                    ServerConsole.WriteLine("0xa3 packet type");
                    return;
                }

                if (packetKey == 63)
                {
                    packetKey = 0;
                }
                else
                {
                    packetKey++;
                }
            }
            catch (Exception ex)
            {
                ServerConsole.WriteLine("Packet Error: {0}", MessageLevel.Error, ex.Message, ex.TargetSite.Name);
            }
        }

        /// <summary>
        /// Send a Command (Packet) asyncron
        /// </summary>
        /// <param name="packet"></param>
        public void Send(PacketOut packet)
        {
            byte[] buffer = packet.Compile();
            int length = buffer.Length;

            Utilities.ServerDump(buffer, length);

            Socket.BeginSend(
                buffer, 0,
                length, 0,
                new AsyncCallback(CallbackSend),
                Socket
            );
        }

        public void Send(PacketOut packet, string title)
        {
            ServerConsole.WriteLine("Sending [{0}]",MessageLevel.Message, title);
            this.Send(packet);
        }

        /// <summary>
        /// Asyncron command sender callback
        /// </summary>
        /// <param name="result"></param>
        private void CallbackSend(IAsyncResult result)
        {
            Socket socket = (Socket)result.AsyncState;
            socket.EndSend(result);
        }

        /// <summary>
        /// Handles packet receiving
        /// </summary>
        /// <param name="result"></param>
        public void OnReceive(IAsyncResult result)
        {
            try
            {
                int bytesRead = Socket.EndReceive(result);
                if (bytesRead > 0)
                {
                    Array.Copy(_buffer, 0, tempBuffer, tempSize, bytesRead);
                    tempSize += bytesRead;
                }
                else
                {
                    Close();
                    return;
                }
            }
            catch (SocketException e)
            {
                if (e.ErrorCode == 10054)
                {
                    Close();
                    return;
                }
                ServerConsole.WriteLine("Socket Error: {0}",MessageLevel.Error, e.Message);
                return;
            }
            catch (ObjectDisposedException e )
            {
                ServerConsole.WriteLine("Object Disposed Error: {0}", MessageLevel.Error, e.Message);
            }
            catch (NullReferenceException e)
            {
                ServerConsole.WriteLine("Null Error: {0}", MessageLevel.Error, e.Message);
            }

            while (tempSize >= 2 && tempSize >= ((int)tempBuffer[0] + (((int)tempBuffer[1]) << 8)))
            {
                int chunkSize = (int)tempBuffer[0] + (((int)tempBuffer[1]) << 8);

                Process(tempBuffer);

                Array.Copy(tempBuffer, chunkSize, tempBuffer, 0, tempSize - chunkSize);
                tempSize -= chunkSize;
            }

            try
            {
                Socket.BeginReceive(_buffer, 0, BUFFERSIZE, 0, new AsyncCallback(OnReceive), null);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Selects a Player
        /// </summary>
        /// <param name="playerId"></param>
        public void PlayerSelect(int PID)
        {
            if (Authenticated)
            {
                Player player = Player.GetPlayer(PID);
                Character = new Character(player, this);

                Send(new Packets.LoginAccepted());
                Send(new Packets.PlayerInfo(Character));
                Send(new Packets.SetCamera(Character, 0));
                Send(new Packets.CameraUpdate());
            }
        }


        /// <summary>
        /// Attempt a user login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void UserLogin(string Id, string Password)
        {
            //check for invalid chars
            if (Utilities.IsAlnum(Id) && Utilities.IsAlnum(Password))
            {
                Account account;
                using (session = Database.KalAuth.OpenSession())
                {
                    IQuery q = session.CreateQuery("FROM Account WHERE ID = :id");
                    q.SetParameter("id", Id);
                    account = (Account)q.UniqueResult();
                }
                //check if account exists
                if (account != null)
                {
                    //check password
                    if (account.DecodedPassword == Password)
                    {
                        if (!account.IsBlocked)
                        {
                            if (!Server.IsIdLoggedIn(Password))
                            {
                                authenticated = true;
                                Account = account;
                                account.Client = this;
                                SendPlayerList();
                            }
                            else
                            {
                                Send(new Packets.LoginError(Packets.LOGIN_ERROR.CONNECT_LATER));
                            }
                        }
                        else
                        {
                            Send(new Packets.LoginError(Packets.LOGIN_ERROR.BLOCKED));
                        }
                    }
                    else
                    {
                        Send(new Packets.LoginError(Packets.LOGIN_ERROR.WRONG_PASS));
                    }
                }
                else
                {
                    Send(new Packets.LoginError(Packets.LOGIN_ERROR.WRONGID));
                }
            }
            else
            {
                Send(new Packets.LoginError(Packets.LOGIN_ERROR.WRONGID));
            }

        }

        /// <summary>
        /// Sends the list of players to the client
        /// </summary>
        public void SendPlayerList()
        {
            Send(new Packets.PlayerList(Account.Players));
            Send(new Packets.DeletedPlayerList(Account.DeletedPlayerList));
        }

        /// <summary>
        /// Unspawn a player
        /// </summary>
        public void UnspawnPlayer()
        {
            Database.Update(Database.KalDB, Character.Player);
            ServerWorld.RemoveEntity(Character);
            Character = null;
        }

        /// <summary>
        /// Sends Initialization packet when the user selects the server
        /// </summary>
        public void SendInit()
        {
            if (Authenticated)
            {
                packetKey = 29;
            }
            else
            {
                packetKey = 56;
                Send(new Packets.Init((byte)packetKey, 0x00,Settings.Default.CharacterLimit));
            }
        }

        public void Disconnect()
        {
            //send disconnect to client
            try
            {
                Send(new Packets.Disconnect());
            }
            catch (Exception) 
            {
                Close();
            }

        }

        /// <summary>
        /// Handles client disconnecting
        /// </summary>
        public void Close()
        {
            
            if (Account != null)
            {
                ServerConsole.WriteLine("Connection for client #{0} terminated.", MessageLevel.Message, Account.ID);
            }
            else
            {
                ServerConsole.WriteLine("Unknown client disconnected");
            }

            if (Character != null)
            {
                UnspawnPlayer();
            }

            if (Socket.Connected)
            {
                Socket.Shutdown(SocketShutdown.Both);
            }

            Socket.Close();
            Socket = null;

            //free world id
            try
            {
                UnspawnPlayer();
            }
            catch (Exception) { }

            Server.RemoveClient(this);
        }

    }
}
