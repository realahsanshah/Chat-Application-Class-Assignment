using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Application_Client
{
    public static class Program
    {
        public static string signUp = "SIGNUP";
        public static string signIn = "SIGNIN";
        public static IPEndPoint endPoint;
        public static Socket socket;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //string serverIp = "192.168.0.104";
            //int serverPort = 2048;
            //try
            //{
            //    endPoint = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

            //    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //    socket.Connect(endPoint);
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void SignIn(string username,string password)
        {
            string message = string.Format($"{signIn}:{username},{password}");
            Console.WriteLine(message);
            string rMessage = "";
            byte[] receiveMessage = new byte[1500];
            byte[] sendMessage = Encoding.ASCII.GetBytes(message);
            socket.SendTo(sendMessage, endPoint);
            int size = socket.Receive(receiveMessage);


            rMessage = Encoding.ASCII.GetString(receiveMessage);


            MessageBox.Show(rMessage);
        }

        public static void SwitchWindows(Form openingWindow, Form closingWindow, Form MDI)
        {
            closingWindow.Close();

            openingWindow.WindowState = FormWindowState.Maximized;
            openingWindow.MdiParent = MDI;
            openingWindow.Show();
        }



    }
}
