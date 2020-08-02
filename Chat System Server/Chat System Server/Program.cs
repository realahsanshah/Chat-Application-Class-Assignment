using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Chat_System_Server
{
    public class Program
    {
        public static string signUp = "SIGNUP";
        public static string signIn = "SIGNIN";
        public static TcpListener tcpListener;

        public static void Main(string[] args)
        {
            tcpListener = new TcpListener(IPAddress.Parse(GetIpAddress()), 2048);
            tcpListener.Start();
            Console.WriteLine("Server listening on " + tcpListener.LocalEndpoint);


            while (true)
            {
                Socket socket = tcpListener.AcceptSocket();
                Console.WriteLine("Connected");
                HandleUser(socket);
               
            }

         

        }

        public static void HandleUser(Socket socket)
        {
            string instructions="";
            string actionType,message;
            while (true)
            {
                
                byte[] byteMessage = new byte[1500];
                
                
                int res = socket.Receive(byteMessage);

                for (int i = 0; i <= res; i++)
                {
                    // Print each character to the console window
                    instructions+=Convert.ToChar(byteMessage[i]);
                }
                //actionType = instructions.Split(':')[0];
                //message = instructions.Split(':')[1];
                //Console.WriteLine($"ActionType: {actionType}");
                //Console.WriteLine($"Message: {message}");
                Console.WriteLine(instructions);
                byte[] sendMessage =Encoding.ASCII.GetBytes("Received");
                socket.Send(sendMessage);
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
