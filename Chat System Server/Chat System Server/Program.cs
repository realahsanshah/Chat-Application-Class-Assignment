using System;
using System.Net.Sockets;

namespace Chat_System_Server
{
    class Program
    {
        public static TcpListener tcpListener;

        public static void Main(string[] args)
        {
            tcpListener = new TcpListener(2048);

            while (true)
            {
                Socket socket = tcpListener.AcceptSocket();

                Byte[] byteMessage=new Byte[250];
                int res=socket.Receive(byteMessage);


                Console.WriteLine(byteMessage.ToString());
            }

        }
    }
}
