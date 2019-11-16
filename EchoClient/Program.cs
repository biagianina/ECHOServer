using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoClient
{
    class Program
    {
        static void Main()
        {
            TcpClient client = new TcpClient("localhost", 123);

            string message = Console.ReadLine();

            byte[] sendData = Encoding.ASCII.GetBytes(message);

            NetworkStream stream = client.GetStream();

            stream.Write(sendData);

            stream.Close();
            client.Close();
        }
    }
}
