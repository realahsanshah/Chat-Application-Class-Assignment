using System;
using System.Net;
using System.Net.Sockets;

namespace Chat_System_Server
{
    public class Program
    {
        public static TcpListener tcpListener;

        public static void Main(string[] args)
        {
            tcpListener = new TcpListener(IPAddress.Parse(GetIpAddress()), 2048);
            tcpListener.Start();
            Console.WriteLine("Server listening on " + tcpListener.LocalEndpoint);


            while (true)
            {
                Socket socket = tcpListener.AcceptSocket();

                Byte[] byteMessage=new Byte[250];
                int res=socket.Receive(byteMessage);

                for (int i = 0; i <= res; i++)
                {
                    // Print each character to the console window
                    Console.Write(Convert.ToChar(byteMessage[i]));
                }

                Console.WriteLine(byteMessage.ToString());
            }

         

        }

        public static string GetIpAddress()
        {
            IPHostEntry localhost;
            string localAddress = "";
            // Get the hostname of the local machine
            localhost = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress address in localhost.AddressList)
            {
                // Look for the IPv4 address of the local machine
                if (address.AddressFamily.ToString() == "InterNetwork")
                {
                    // Convert the IP address to a string and return it
                    localAddress = address.ToString();
                }
            }
            return localAddress;
        }
    }
}
