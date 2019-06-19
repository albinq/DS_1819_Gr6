using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace UDPServerLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            int recv;
            byte[] data = new byte[1024];
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, 904);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Bind(endpoint);

            Console.WriteLine("Waiting for client...");

            IPEndPoint sender = new IPEndPoint(IPAddress.Loopback, 904);
            EndPoint tmpRemote = (EndPoint)sender;

            recv = socket.ReceiveFrom(data, ref tmpRemote);

            Console.WriteLine("Message received from (0)", tmpRemote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

            string welcome = "welcome to my server!";
            data = Encoding.ASCII.GetBytes(welcome);

            if (socket.Connected)
            {
                Console.WriteLine("Client connected");
                socket.Send(data);
            }
            while (true)
            {
                if (!socket.Connected)
                {
                    Console.WriteLine("client disconnected.");
                }
                data = new byte[1024];
                recv = socket.ReceiveFrom(data, ref tmpRemote);
                string decryptedM = Class1.Decrypt(System.Text.Encoding.ASCII.GetString(data, 0, recv));

                if (recv == 0)
                {
                    break;
                }

                Console.WriteLine(decryptedM);
            }
            socket.Close();
            System.Threading.Thread.Sleep(5000);
        }
    }
}
