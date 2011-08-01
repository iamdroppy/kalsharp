using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using KalSharp.Configs;
using KalSharp.Worlds;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace KalSharp
{
    public class Server
    {

        /// <summary>
        /// Active Clients 
        /// </summary>
        public static List<Client> Clients = new List<Client>();

        /// <summary>
        /// Connection Processing Thread
        /// </summary>
        public static Thread ProcessConnectionsThread;

        /// <summary>
        /// Thread Communicator, handles event waiting
        /// </summary>
        public static ManualResetEvent ResetEvent = new ManualResetEvent(false);

        /// <summary>
        /// Server Queue Timer
        /// </summary>
        public static Thinker Thinker = new Thinker();

        /// <summary>
        /// Random seed generator used for Attacks and similiar events
        /// </summary>
        public Random ServerRandom = new Random();

        /// <summary>
        /// Sets about the server is running, and should listen for clients
        /// </summary>
        public static bool Running = true;

        public void Start()
        {
            //database
            Database.Connect();
            //hackshiedl
            Hackshield.Load();
            //get path to config files
            string configPath = Path.Combine(Environment.CurrentDirectory, Settings.Default.ConfigPath);
            //load config files
            ConfigManager.LoadConfigFiles(configPath);
            //read config files
            ConfigManager.ReadConfig();
            //load item codes
            Configs.Items.ItemCodes.CodeManager.Load();
            //load chat manager
            Chat.ChatManager.Load();
            //prepare a new world
            ServerWorld.Load(2);

            //start server
            ProcessConnectionsThread = new Thread(
                new ThreadStart(Server.ProcessConnections)
            );
            ProcessConnectionsThread.Start();
            Thinker.Start();
            ServerConsole.WriteLine("Server started on port {0}", MessageLevel.Message, Settings.Default.Port);
            
        }
        /// <summary>
        /// Process Client connections, and calls a Async Callback
        /// </summary>
        private static void ProcessConnections()
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, Settings.Default.Port);
            Socket listener = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
            );

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(5);

                while (Running)
                {
                    ResetEvent.Reset();
                    listener.BeginAccept(new AsyncCallback(CallbackAccept), listener);
                    ResetEvent.WaitOne();
                }
            }
            catch (Exception e)
            {
                
                ServerConsole.WriteLine("Socket error: {0} at {1}", MessageLevel.Error, e.Message, e.TargetSite.Name);
            }
        }

        /// <summary>
        /// Callback that handles client connections
        /// </summary>
        /// <param name="ar"></param>
        private static void CallbackAccept(IAsyncResult ar)
        {
            ResetEvent.Set();

            ///
            /// Listen for connections
            /// 
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            ///
            /// Client connected ! Creating client object.
            /// 
            Client client = new Client(handler);
            Clients.Add(client);

            Thinker.Add(5, new DelegateThought.ThoughtCallback(Test), client);

            ServerConsole.WriteLine("Client #{0} connected from {1}",MessageLevel.Warning, Clients.Count, client.IP);

            ///
            /// Starts to listen for client input
            /// 
            handler.BeginReceive(
                client.Buffer, 0,
                Client.BUFFERSIZE, 0,
                new AsyncCallback(client.OnReceive),
                null
            );
        }

        /// <summary>
        /// Remove the client from the clients list on disconnect
        /// </summary>
        /// <param name="client"></param>
        public static void RemoveClient(Client Client)
        {
            if (Clients.Contains(Client))
            {
                Clients.Remove(Client);
            }
        }

        public static void Test(Thought thought, params object[] Params)
        {
            //Client client = Params[0] as Client;
            //ServerConsole.WriteLine("Sent unk 4");
            //client.Send(new Packets.UnknownError2(Packets.UNKNOWN_ERROR2.NINE));

            //Thinker.Requeue(5, thought);
        }

        /// <summary>
        /// Closes the server, and disconnects all clients
        /// </summary>
        public void Close()
        {
            try
            {
                foreach (Client client in Clients)
                {
                    client.Disconnect();
                }
            }
            catch (Exception) { }
            Running = false;
            ProcessConnectionsThread.Abort();
            Thinker.Stop();
        }

        public static bool IsIdLoggedIn(string ID)
        {
            foreach (Client client in Clients)
            {
                if (client.Authenticated)
                {
                    if (client.Account.ID == ID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
