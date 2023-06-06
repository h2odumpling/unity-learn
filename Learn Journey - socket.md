# 计算机网络
一般分为5层。
* 物理层    为数据端设备提供传送数据通路、传输数据，确保原始的数据可在各种物理媒体上传输        架空明线|平衡电缆|光纤|无线信道等
* 数据链路层    定义单个链路上的数据传输，对物理层传输原始比特流的功能的加强，将物理层提供的可能出错的物理连接改造成为逻辑上无差错的数据链路    点对点协议|以太网高级数据链路协议|帧中继|异步传输模式
* 网络层    解决网络路由和寻址问题      IP协议
* 传输层    解决对应网络层进行可靠的传递数据包      TCP|UDP等协议
相当于数据传输的通道\
* 应用层    如HTTP协议、RPC协议
相当于数据传输的格式，有head、body等\

>> 深入学习：相关内容

## 带宽
指每秒钟内能通过的比特（BIT）数

# Socket
Socket继承自UNIX一切都是文件的原理，即是 打开->读|写->关闭 的模式

## Socket(AddressFamily,SocketType,ProtocolType)   Socket基本函数
AddressFamily,SocketType,ProtocolType 有些互相匹配，当不匹配的参数用于创建socket时，会报错
参考资料：https://learn.microsoft.com/zh-cn/dotnet/api/system.net.sockets.sockettype

### AddressFamily   协议族，规定通信中的地址，在Socket创建时设置的只读属性，在c#中是继承自AddressFamily的枚举
协议族
* InterNetWork    IPv4
* InterNetWork6   IPv6
* AppleTalk   AppleTalk
* Atm   本机ATM服务
* Banyan    Banyan
* Ccitt   CCITT协议
* Chaos   MIT CHAOS协议
* Cluster   Microsoft群集产品
* ControllerAreaNetwork   控制器区域网络
* DataKit   Datakit协议
* DataLink    直接数据连接接口
* DecNet    DECnet
* Ecma    欧洲计算机制造商协会（ECMA）
* FireFox   FireFox
* HyperChannel    NSC Hyperchannel
* Ieee12844   IEEE 1284.4工作组
* ImpLink   ARPANET IMP
* *Ipx   IPX或SPX
* Irda    IrDA
* Iso   ISO协议
* Lat   LAT
* Max   MAX
* NetBios   NetBios
* NetworkDssigners    支持网络设计器 OSI网关的协议
* NS    Xerox NS协议
* Osi   OSI协议
* Packet    低级别数据包
* Pup   PUP协议
* Sna   IBM SNA
* Unix    Unix本地到主机地址
* Unkonwn   未知的地址族
* Unspecified   未指定的地址族
* VoiceView   VoiceView
>> 深入学习：其他协议族

### ScoketType    Socket类型，在c#中是继承自ScoketType的枚举
类型
#### 无需建立连接，且可通信多个主机
* Dgram   需ProtocolType.Udp和AddressFamily.InterNetWork，支持数据报，即最大长度固定（通常很小）的无连接、不可靠消息。消息可能会丢失或重复，并且在数据到达时不按顺序排列。
* Rdm   支持无连接、面向消息及以可靠方式发送的消息，并保留数据中的消息边界。RDM消息会依次到达且不会重复，消息丢失时会通知发送方。
#### 需要建立连接，只可通信单个
* Seqpacket   提供可靠、排序、双向、面向连接的字节流，数据不重复，且在数据流中保留边界
* Stream    提供可靠、双向、基于连接的字节流，数据不重复，不保留边界
#### 其他
* Raw   可以使用ProtocolType.Icmp及ProtocolType.Igmp，支持对基础传输协议的访问，在发送时必须提供完整的IP头，接收数据在返回时也会保持IP头及选项不变。
* Unknown   未知的Socket类型

### ProtocoType   指定协议，在c#中是继承自ProtocolType的枚举
#### 常见协议
* Tcp   传输控制
* Udp   用户数据报
#### 其他协议
* Ggp   网关到网关
* Icmp    网际消息控制
* IcmpV6   用于IPv6的Internet控制消息 
* Idp   Internet数据报
* Igmp    网际组管理
* IP    网际
* IPSecAuthenticationHeader   IPv6身份验证头
* IPSecEncapsulatingSecurityPayload   IPv6封装式安全措施负载头
* IPv4    IPv4
* IPv6    IPv6
* IPv6DestinationOptions    IPv6目标选项头
* IPv6FragmentHeader    IPv6片段头
* IPv6HopByHopOptions   IPv6逐帧选项头
* IPv6NoNextHeader   IPv6 No Next头
* IPv6RoutingHeader   IPv6路由头
* Ipx   Internet数据包交换
* ND    网络磁盘协议（非正式）
* Pup   PARC通用数据包
* Raw   原始IP数据包
* Spx   顺序包交换
* Spxll   顺序表交换第二版
* Unknown   未知
* Unspecified   未指定

## Bind    用于给Socket对象绑定地址及端口（仅服务端）
## Listen|Connect    服务端用Listen监听对象，客户端用Connect发出连接请求
## Accept    当服务端监听到请求后就会调用，表示连接成功建立

## Send|Recive
Recive函数负责内容读取，返回读取实际字节数，读取到文件结尾时返回0，出错时返回负值，常见的有EINTR表示中断，ECONNREST表示连接问题
Send函数负责内容发送，返回发送字节数（有可能发送了部分或全部），失败时返回负值，常见的有EPIPE表示连接问题

## Close   完成连接，关闭Socket对象



# TCP
Transmission Control Protocol/Intternet Protocol    传输控制协议
HTTP协议运用的就是TCP协议

## TCP三次握手
* 客户端 SYN=1 seq=(random)J   SYN 1表示客户端想要建立连接
* 服务端 SYN=1 ACK=J+1 seq=(random)K   服务的接收后返回ACK供客户端验证
* 客户端 ACK=K+1   客户端验证ACK值为J+1后发送ACK供服务端验证

### SYN攻击
客户端发送SYN=1给服务端后，服务端会处于半连接状态并一直发送接受请求SYN=1 ACK=J+1 seq=K至超时，因为只要模拟不同IP大量发送SYN给服务端，就能大量占用未连接队列，导致正常连接无法接入
TCP握手中断，会一直发送相应信息至超时

## TCP四次挥手
* 客户端 FIN=M   表示客户端想要主动中止连接
* 服务端 ACK=M+1   表示接收到客户端的中止请求，并提供ACK用以验证
* 服务端 FIN=N   表示服务端同意中止连接
* 客户端 ACK=N+1   表示客户端同意服务端中止，并提供ACK用以验证
>> 深入学习：M和N是如何生成的
>> 深入学习：通过计时器解决socket的recive堵塞问题

## TCP保持连接的方法
一般通过发送心跳包确认连接存活状态\

## HTTP|RPC
RPC(Remote Procedure Call、远程过程调用)，主要实现像调用本地服务一样去调用远程服务\
RPC实际过程是将数据序列化传输和反序列化的过程，在同种编程语言下使用，需要用统一的RPC框架\
Http则只是规定了数据传输的格式，无关编程语言\
RPC性能更强，但实现更复杂，Http则相对简单\
Http通用性更强，但信息量较大比较臃肿，RPC通用性很差，但信息量较小\

### HTTP 长轮询|短轮询
在需要实时展示一个数据的情况下，客户端死循环获取展示数据\
长轮询是短轮询的优化，服务端接到请求后不立即返回，而是在数据改变前阻塞到超时再返回数据\



# UDP
用户数据报协议



# TCP|UDP

* 可靠性：TCP可靠，可自动重传；UDP不可靠，易丢包。TCP在传输数据前会检查连接状态，UDP直接进行投递
* 传输：TCP效率较低，UDP传输结构简单，效率高
* 连接数：TCP有限制，UDP无限制
* 性能：TCP性能较好，UDP性能较差

## 常见游戏
主要按对网络延迟的要求及不同同步算法选择不同协议

### TCP
常用于对网络延迟要求不高的游戏
* 炉石传说，斗地主，梦幻西游等回合制
* 魔兽世界

### UDP
常用于对网络延迟较高的游戏
* DOTA2，LOL等MOBA
* PUBG，COD等FPS

