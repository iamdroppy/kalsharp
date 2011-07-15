using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KalSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServerConsole.PrintLogo();

                int i = 0;
                while (i < 80)
                {
                    Console.Write("-");
                    Thread.Sleep(20);
                    i++;
                }
                ServerConsole.WriteLine("Server Starting", MessageLevel.Message);
                Server server = new Server();
                server.Start();
                Console.Read();
            }
            catch (Exception ex)
            {
                ServerConsole.WriteLine(ex.ToString(), MessageLevel.Fatal);
            }
            Console.ReadKey();
            
        }
    }
}
