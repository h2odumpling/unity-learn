using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        public static List<ClientController> clientControllerList = new List<ClientController>();

        static void Main(string[] args)
        {
            //定义socket
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定端口
            IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            Console.WriteLine("开始绑定端口");
            serverSocket.Bind(ipendpoint);
            Console.WriteLine("端口绑定完成，开启服务器");
            serverSocket.Listen(100);
            Console.WriteLine("服务器启动成功");
            while (true)
            {
                Console.WriteLine("等待连接");
                Socket clientSocket = serverSocket.Accept();
                Console.WriteLine("客户端{0}连接成功", clientSocket.RemoteEndPoint.ToString());
                ClientController controller = new ClientController(clientSocket); 
                //添加至列表
                clientControllerList.Add(controller);
                Console.WriteLine("当前{0}个用户",clientControllerList.Count);
            }
        }
    }
}