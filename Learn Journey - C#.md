# 数据类型
不同数据用不同内存大小存储以减少内存损耗，C#中有值类型和引用类型

## 值类型
bool,byte,char,decimal,double,float,int,sbyte,short,uint,ulong,ushort
值类型可以看成一个1|0数组（点阵列），不同的位置存储不同的信息
其中数字相关类型，以下格式为 名称(位数,符号[1|0],小数位数)
直接存放在栈中
继承system.ValueType

### 整型
可存储的值为2的位数次方，若有符号则符号占1位，存储的正数永远比负数少1，因为0需要占据一个位置
整形命名规则上u开头一般都无符号，s开头一般都有符号
*byte(8,0)
*sbyte(8,1)
*ushort(16,0)
int(32,1)
uint(32,0)
ulong(64,0)

### 浮点型
使用科学计数法存储，1位存储符号，1位存储指数符号，一部分存储指数，剩余部分存储精度
指数负数永远比正数少1，即0划归指数负数部分
精度范围是浮动的，以float为例精度23位最大可存储8388608，若实际精度首位是9，则只有6位精度
double(64,1,[15-16])    10位指数 52位精度
float(32,1,[6-7])     7位指数 23位精度
//decimal的存储方法暂不明确，按mysql的存储方式，则是整数部分小数部分分开存储，每9位十进制数存于4字节（32）位中
//decimal(128,1,?)

### n.toString("format")
C   货币
D[n]   十进制，n为小数位数，默认0
E   科学型 25000 -> 	2.500000E+005 实际转为一个浮点数的表现形式
F[n]   固定小数位，默认2
G   常规
N   带有逗号和小数点的数字
X   十六进制

## 引用类型
在栈中存放值的地址，在堆中存放值
继承system.Object
较值类型存储较慢
变更引用类型会影响所有引用了这个值的对象，下面举两例
Vector3 pos = transform.position;
pos = Vecotr3.zero; //由于Vector3是值类型，所以transform.position 不会改变
Material mat = transform.GetComponent<MeshRender>().material;
mat.color = Color.red;//此时MeshRender的颜色也被改变
 
  
  
# 装箱|拆箱
装箱就是把值类型转为引用类型的操作，下面代码就是i的装箱操作
int i = 0;
System.Object obj = i;
拆箱就是把引用类型转为值类型的操作，下面代码就是obj的拆箱操作
int i = 0;
System.Object obj = i;
int j = (int)obj;



# break
C#没有break all



# = 和 ++|--
c = [++|--]a 先自增或自减再赋值
c = a[++|--] 先赋值再自增或自减



# 全等和不全等
C#变量类型是明确规定的，不同的变量类型直接不可以使用逻辑运算符



# 左移且赋值及右移且赋值
是2进制位数的左移或右移
a = 4;
a <<= 2; 即 00100 -> 10000 -> a = 16
a = 4;
a >> 2; 即 00100 -> 00001 -> a = 1



# 数组
dateType[] name
C#中数组是单一类型数据且长度固定的"集合"（非集合）
数组是引用类型，声明数组时不创建堆
为赋值的数组无法隐式转换为bool类型或被调用
数组有定义的长度，访问超出定义长度的键时会报错
在秩中加入逗号可以定义数组维度，int[,] n 即为一个二维数组
>> 深入学习 指针数组、结构数组



# 集合
集合较之数组，长度可变，且可存储引用类型，更为灵活，但开销也变得更大

## 泛型和非泛型
非泛型集合的value是object，所以在存储|读取值类型时会发生大量装箱|拆箱操作，且无法验证数据类型，所以在涉及值类型存储时推荐使用泛型集合

### 常见非泛型集合如下
ArrayList   根据索引获取数据
HashTable   根据键获取数据
SortedList    即可使用键访问数据，也可使用索引访问数据
Query   队列，先进先出
Stack   堆栈，后进先出

### 常见泛型集合如下
SortedList<TKey,TValue>   SortedList的泛型等效类
List<T>   ArrayList的泛型等效类
Stack<T>    Stack的泛型等效类
Queue<T>    Queue的泛型等效类
Dictionary<TKey,TValue>   字典
BitArray    点阵列，存储[1|0]这样二进制数据的集合，使用索引访问元素
>>  深入学习：各类型的底层实现

#### 值的获取修改等
使用索引取值的，当无索引会报错
使用索引存值的，当索引重复会报错
Count   集合中包含的元素个数
void Clear()    清除集合中所有元素
bool Contains(T)    判断集合中是否存在T
T[] ToArray()   复制集合中的元素到一个新数组中
void TrimToSize()   只能在非泛式集合中使用，设置集合容量为当前元素的个数，即释放空项的内存占用，手动回收内存
void TrimExcess()   只能在泛式集合中使用，功能同上
void Remove()   键值时匹配键，索引时匹配值，删除第1个匹配的元素，不存在时不报错
void RemoveAt()   索引时匹配索引，不存在时报错
void Add(TKey,TValue)   索引时不存在TKey，键值时若重复TKey会报错
>> 深入学习：其他内容

#### 哈希表Hashtable
IsFixedSize   是否固定大小
IsReadOnly    是否只读
Item    
Keys    获取哈希表中键的集合
Value   获取哈希表中值的集合
void Add(object key,object value)
bool ContainsKey(object key)
bool ContainsValue(object value)
排序类似堆栈，后添加的在表最前

#### 队列[Query|Query[T]]方法汇总
void Enqueue(T)   T入队
T Dequeue()   T出队，返回T

#### 堆栈[Stack|Stack[T]]
T Peek()    返回Stack顶部对象，不删除
T Pop()   返回并删除Stack顶部对象（弹出元素）
void Push(T)    推入元素

#### 字典 Dictionary<TKey,TValue>
在索引号并非int类型时使用
键值
使用索引获取值，索引值先通过散列函数寻找哈希桶中的值，然后根据哈希桶对应的值在单链表中寻找索引中对应的元素
>> 深入学习：哈希函数构建及解决哈希冲突的其他方法



# String
引用类型，但通过值传递，a = "1"; b = a; a="c"; 此时a引用"c"，b引用"1"
"1" 的类型是string '1'的类型是char
实际是一个char的数组，通过String[n]的索引形式获取对应的char，string == char[]
通过new string(char[] array)构造
通过string.join("分隔符",string[] array)构造
>> 深入学习 通过String.Format()构造

## 比较字符串
int Compare   String.Compare(str1,str2,true|false)|String.Compare(str1,index1,str2,index2,length,true|false)，true|false是否区分大小写，index及length可比较相应位数
int CompareTo   str1.CompareTo(str2)，区分大小写
int CompareOrdinal    String.CompareOrdinal(str1,str2)，str1的char总值 - str2的char总值，String.CompareOrdinal("ab","cd") -> -4
bool Equals    String.Equals(str1,str2)|str1.Equals(str2)，区分大小写

## 字符串检索
bool StartsWith   str1.StartsWith(string)
bool EndsWith   str1.EndsWith(string)
int IndexOf   str1.IndexOf(string,index1,length)
int LastIndexOf   str1.LastIndexOf(string,index1,length)，从后往前检索，index不变
int IndexOfAny    str1.IndexOfAny(char[],index1,length)
int LastIndexOfAny    str1.LastIndexOfAny(char[],index1,length)，从后往前检索，index不变

## 字符串格式化
string.Format("{0[ ,m ][ :[C|D|E|F|G|N|P|R|X][0-9]*? ] }")
C|c   货币
D|d   十进制
E|e   指数 如1.23456E+005
F|f   固定小数位，精度最高15位（使用双精度，单精度只有7位）
G|g   常用格式
N|n   逗号分隔千分位
P|p   百分号形式
R|r   圆整，无视有效数字，精度最高17位（使用双精度，单精度只有9位）
X|x   十六进制
当string时间，如System.DateTime.now
D   *年*月*日
d   */*/*
T   *:*:*
t   *:*
Y|y   *年*月
M|m   *月*日

## 字符串连接
string Contact    string.Contact([string[]|string|char[]|char],*)
string Join   string.Join("delimiter",[string[]|string|char[]|char],*)

## 字符分隔
string[] splite

## 字符串插入
string insert   str1.Insert(index,string)

## 字符串删除
string Remove   str1.Remove(index,length)
string Trim   str1.Trim([char[]|char],*)
string TrimStart
string TrimEnd

## 字符串替换
srting Replace    str1.Replace(char,char)|str1.Replace(string,string)

## 更改大小写
string ToUpper
string ToLower

>> 深入学习：StringBuilder类



# 文件及文件夹操作

## 文件夹操作
Directory和DirectroyInfo类都可以操作文件夹且有类似方法，区别是Directory类是静态方法，每次都需要调用目录，而DirectoryInfo类则在创建类时完成了定义
文件夹创建  
Directory.Create(@"path")|new DirectoryInfo(@"path").Create()
文件夹删除，无目标文件会报错
Directory.Delete(@"path")|new DirectoryInfo(@"path").Delete()
文件夹是否存在
Directory.Exists(@"path")|new DirectoryInfo(@"path").Exists
剪切文件夹，目标文件夹已经存在会报错
Directory.Move(@"pathFrom",@"pathTo")|new DirectoryInfo(@"path").MoveTor(@"pathTo")
设置文件夹
Directory.Create(@"path").Attributes = FileAttributes.[ReadOnly|Hidden|Temporary(临时)|Encrypted(加密)]

## 文件操作
File类及FileInfo类同上
复制，源文件不存在时报错
File.Copy(@"pathFrom",@"pathTo")|new FileInfo(@"path").CopyTo(@"pathTo")
>> 深入学习：复制目标文件存在时会报错么？

## 文件读写操作
FlieStream
推荐在using内使用FileStream，using等效于try{}finally{}，并在finally内调用的Dispose方法清理资源
using( FileStream fs = File.Open(path,FileMode,FileAccess,FileShare) ){}

### FileMode
Append    打开并追加，需要与FileMode = Write，一起使用
Create    创建新并覆盖
CreateNew   创建新，如果已存在则报错
Open    打开，不存在会报错
OpenOrCreate    不存在时创建新，存在时打开
Truncate    打开并清空文件，不存在会报错

### FileAccess
Read    读
Write   写
ReadWrite   读写

### FileShare   文件共享方式
None    不允许操作
Read    允许读
Write   允许写
ReadWrite   允许读写

Read    fs.Read(byte[], startIndex, endIndex)
Write   fs.White(byte[], startIndex, endIndex)
Close   fs.Close() 关闭文件

>> 深入学习：测试文件流读写



# 正则表达式
@"正则表达式"可表示这是一个正则表达式，否则\n需写成\\n
参考微软文档：https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/regular-expressions

## Regex类
Match Match   返回第一个匹配的Match对象，Match继承自Group，Group继承自Capture，可通过match.Groups返回所有匹配的分组，可访问Capture的Index,Length,Value属性，直接调用则返回Value
MatchCollection Matches   返回所以匹配的match的集合
bool isMatch    是否匹配
string Replace    替换
string[] Split    分隔
Regex.[Match|Matches|isMatch|Replace|Split](str,partten,Regex.RegexOptions|*)

### RegexOptions
Complied    对表达式进行编译，原会直接进行解释操作，而编译会先将正则表达式由正则表达式引擎缓存，因此在多次调用时可以提高性能，但会提高初次调用的成本
CultureInvariant    忽略文化差异，比如土耳其地区I并非i的大写选项
ECMAScript    符合ECMAScript规则，只能和IgnoreCase、Multiline、Complied连用
ExplicitCapture   仅捕获显式命名组，内联组元素(?n)可禁止自动捕获也可达到类似效果 b(a) 会捕获ba及a，使用显示捕获则只返回 ba
IgnoreCase    无视大小写
IgnorePattenWhitespace    去除正则表达式中的非转义空白符号，且#开始至\n都会被认为是该正则表达式的注释，可用内联(?x)达到同样效果
Multiline   ^$可用来匹配换行符n，^s 匹配 aaa\nsss 是无符号匹配的，Muliline后可以获得匹配
None    默认，无意义
RightToLeft   从右往左
Singleline    .可以匹配任意字符，原.只能匹配除换行符\n外的任意字符
>> 深入学习：ECMAScript

### 转义字符
\a    匹配响铃字符
\b    匹配单词边界
\B    匹配非单词边界
\t    匹配制表符
\r    匹配回车
\v    匹配垂直制表符
\f    匹配换页符
\n    匹配换行符
\e    匹配转义
\[nnn]    匹配ASCII字符，nnn表示八进制字符的2或3位数
\x[nn]    匹配ASCII字符，nn表示十六进制字符的2位数
\c[n]    匹配ASCII的控制字符，n位控制字符首字母，例如\cC为CTRL-C
\u[nnnn]    匹配UTF-16，nnnn是十六进制

### 字符
\w    匹配任何单词字符
\W    匹配任何非单词字符
\s    匹配空白字符
\S    匹配任何非空白字符
\d    匹配十进制数字
\D    匹配任何非十进制数字的字符

### 定位点
^   字符串开头或行开头
$   字符串结尾或行结尾或\n前
\A    字符串开头
\Z    字符串结尾或\n前
\z    字符串结尾
\G    上一个匹配结束的地方
>> 深入学习：\G

### 限定符
*   0或多
?   0或1
+   1或多
{n}   n次
{n1,n2}   n1-n2次

>> 深入学习：正则表达式的数学算法
