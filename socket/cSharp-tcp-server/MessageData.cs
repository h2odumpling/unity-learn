using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MessageData
    {
        //消息类型
        public MessageType msgType;

        //消息内容
        public string msg;
    }

    public enum MessageType
    {
        Chat = 0,
        Login = 1,
        LogOut = 2,
    }
}
