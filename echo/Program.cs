using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace echo
{
    class Program
    {
        static void Main()
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ip, 123);
            TcpClient client = default;

            try
            {
                server.Start();
                Console.WriteLine("Server starting...");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            while(true)
            {
                client = server.AcceptTcpClient();
                HandleClient cl = new HandleClient();
                cl.StartClient(client);
            }
        }
  
    }
}
