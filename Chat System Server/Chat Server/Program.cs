using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Server
{
    public class Program
    {
        public const string signUp = "SIGNUP";
        public const string signIn = "SIGNIN";
        public const string checkUsername = "CHECKUSERNAME";
        public const string addFriend = "ADDFRIEND";
        public const string sendMessageAction = "SENDMESSAGE";
        public static TcpListener tcpListener;
        public static Socket socket;

        public static void Main(string[] args)
        {
            tcpListener = new TcpListener(IPAddress.Parse(GetIpAddress()), 2048);
            tcpListener.Start();
            Console.WriteLine("Server listening on " + tcpListener.LocalEndpoint);


            while (true)
            {
                socket= tcpListener.AcceptSocket();
                Console.WriteLine("Connected");
                HandleUser(socket);

            }



        }

        public static void HandleUser(Socket socket)
        {
            string instructions = "";
            string actionType, message;
            while (true)
            {

                byte[] byteMessage = new byte[1500];


                int res = socket.Receive(byteMessage);


                instructions = Encoding.ASCII.GetString(byteMessage);


                actionType = instructions.Split(':')[0];
                message = instructions.Split(':')[1];
                HandleAction(actionType, message);
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

        public static void HandleAction(string actionType,string message)
        {
            byte[] sendMessage;
            switch (actionType)
            {
                case signIn:
                    Console.WriteLine($"ActionType: {actionType}");
                    Console.WriteLine($"Message: {message}");
                    sendMessage = Encoding.ASCII.GetBytes("Sign In Request Received");
                    socket.Send(sendMessage);
                    break;

                case signUp:
                    Console.WriteLine($"ActionType: {actionType}");
                    Console.WriteLine($"Message: {message}");
                    sendMessage = Encoding.ASCII.GetBytes("Sign Up Request Received");
                    socket.Send(sendMessage);
                    break;

                case checkUsername:
                    Console.WriteLine($"ActionType: {actionType}");
                    Console.WriteLine($"Message: {message}");
                    sendMessage = Encoding.ASCII.GetBytes("Check Username Request Received");
                    socket.Send(sendMessage);
                    break;

                case addFriend:
                    Console.WriteLine($"ActionType: {actionType}");
                    Console.WriteLine($"Message: {message}");
                    sendMessage = Encoding.ASCII.GetBytes("Friend Request Received");
                    socket.Send(sendMessage);
                    break;

                case sendMessageAction:
                    Console.WriteLine($"ActionType: {actionType}");
                    Console.WriteLine($"Message: {message}");
                    sendMessage = Encoding.ASCII.GetBytes("Message Request Received");
                    socket.Send(sendMessage);
                    break;

                default:
                    sendMessage = Encoding.ASCII.GetBytes("Unknown Request Received");
                    socket.Send(sendMessage);
                    break;
            }
        }
    }
}
