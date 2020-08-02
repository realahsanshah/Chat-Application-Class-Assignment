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
        public static Chat_ApplicationEntities db;

        public static void Main(string[] args)
        {
            tcpListener = new TcpListener(IPAddress.Parse(GetIpAddress()), 2048);
            tcpListener.Start();
            Console.WriteLine("Server listening on " + tcpListener.LocalEndpoint);

            db=new Chat_ApplicationEntities();
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


                for (int i = 0; i < res; i++)
                {
                    instructions += Convert.ToChar(byteMessage[i]);
                }


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
            string username;
            string password;
            string name;
            string email;
            User user;
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
                    string[] values = message.Split(',');
                    username=values[0];
                    password = values[1];
                    name = values[2];
                    email = values[3];

                    user = new User();
                    user.email = email;
                    user.name = name;
                    user.password = password;
                    user.username = username;
                    db.Users.Add(user);
                    int result = db.SaveChanges();
                    
                    sendMessage = Encoding.ASCII.GetBytes("Sign Up Request Received");
                    socket.Send(sendMessage);
                    break;

                case checkUsername:
                    Console.WriteLine($"ActionType: {actionType}");

                    username = message;
                    bool isAvailable = !db.Users.Any(x => x.username.Equals(username));
                    Console.WriteLine(isAvailable);
                    if (isAvailable)
                    {
                        sendMessage = Encoding.ASCII.GetBytes("true");
                    }
                    else
                    {
                        sendMessage = Encoding.ASCII.GetBytes("false");
                    }
                    
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
