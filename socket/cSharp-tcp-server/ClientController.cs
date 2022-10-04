using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    internal class ClientController
    {
        private Socket clientSocket;

        //接收线程
        Thread reciveThread;
        //昵称
        public string nickName;

        public ClientController(Socket socket)
        {
            clientSocket = socket;
            //启动接收方法
            //创建线程
            reciveThread = new Thread(reciveFromClient);
            //启动线程
            reciveThread.Start();
        }

        //监听客户端
        void reciveFromClient()
        {
            while (true)
            {
                byte[] buffer = new byte[1024];
                int lenght = clientSocket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                string json = System.Text.Encoding.UTF8.GetString(buffer, 0, lenght);
                json.TrimEnd();
                if (json.Length > 0)
                {
                    Console.WriteLine("服务器接收内容：{0}", json);
                    MessageData data = LitJson.JsonMapper.ToObject<MessageData>(json);

                    switch (data.msgType)
                    {
                        case MessageType.Login:
                            nickName = data.msg;
                            //通知客户端登录成功
                            MessageData backData = new MessageData();
                            backData.msgType = MessageType.Login;
                            backData.msg = "";
                            SendToClient(backData);
                            //通知所有客户端，***加入房间
                            MessageData chatData = new MessageData();
                            chatData.msgType = MessageType.Chat;
                            chatData.msg = nickName + "加入了房间";
                            SendMessageToAllWithout(chatData);
                            break;
                        case MessageType.Chat:
                            MessageData chatMessageData = new MessageData();
                            chatMessageData.msgType = MessageType.Chat;
                            chatMessageData.msg = "nickname" + ":" + data.msg;
                            SendMessageToAllWithout(chatMessageData);
                            break ;
                        case MessageType.LogOut:
                            //通知客户端退出
                            MessageData logOutData = new MessageData();
                            logOutData.msgType = MessageType.LogOut;
                            SendToClient(logOutData);
                            //通知其他客户端
                            MessageData logOutChatData = new MessageData();
                            logOutChatData.msgType = MessageType.Chat;
                            logOutChatData.msg = nickName + "退出了房间";
                            SendMessageToAllWithout(logOutChatData);
                            break;
                        default:
                            break;
                    }
                }

            }
        }

        void SendToClient(MessageData data)
        {
            //把对象转为Json字符串
            string msg = LitJson.JsonMapper.ToJson(data);
            //把json对象转为byte数组
            byte[] msgBytes = System.Text.Encoding.UTF8.GetBytes(msg);
            //发送消息
            int sendLength = clientSocket.Send(msgBytes);
            Console.WriteLine("服务器发送信息成功，发送信息内容：{0}，长度{1}", msg, sendLength);
            Thread.Sleep(50);
        }

        void SendMessageToAllWithout(MessageData data)
        {
            for (int i =0; i < Program.clientControllerList.Count; i++)
            {
                if (Program.clientControllerList[i] != this)
                {
                    Program.clientControllerList[i].SendToClient(data);
                }
            }
        }
    }
}
