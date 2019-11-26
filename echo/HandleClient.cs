using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace echo
{
    public class HandleClient
    {
        TcpClient clientSocket;
        public void StartClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(new ThreadStart(DoChat));
            ctThread.Start();
        }
        private void DoChat()
        {
            byte[] bytesFrom = new byte[100];

            try
            {
                NetworkStream networkStream = clientSocket.GetStream();
                byte[] broadcastBytes = null;

                broadcastBytes = Encoding.ASCII.GetBytes("This is the text you should type!");
                networkStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                networkStream.Flush();
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to read data");
            }
        }
    }
}
