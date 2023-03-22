# 命名空间
避免类的重名，指示CLR在寻找类时会逐一寻找

```
using System.IO;
using System.Text;

public sealed class Program{
    public static void Main(){
        FileStream fs = new FileStream(..);
        StringBuilder sb = new StringBuilder();
    }
}
```

上例中，StringBuilder类型若同时存在于System.IO及System.Text，则会触发不明确引用的错误\
```
using TextStringBuilder = System.Text.StringBuilder     //可以通过定义一个新的别名来消除歧义
```



# 访问修饰符
按需求扩大访问范围
* public  对外可见
* private  只有类中函数可以访问   是指类的私有而非对象的私有，所以同一个对象的2个实例可以互相访问对方的私有数据
* internal  在一个程序集内可以访问  在一个程序集内可以有多个namespace，调用时可以using namespace
* pretected  只有自己的继承类可以访问
* internal protected  即可在继承类可见，又可在程序集可见



# static
类中的静态数据由所有类的实例共享

## const
常量字段，是一种特殊的静态字段，值永远不变



# null
引用类型

## 可空类型
* hasValue  是否包含非空值
* Value  返回非空值



# 代码块
代码块内定义的变量在代码块结束时消失



# struct
用于打包封装比较小的数据集，可完成class的大部分内容，是值类型
```
struct student
{
    public int id;
    public string name;

    public student(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
```
```
student a = new student(1,"ss");
student b = new student(2, "dd");
a = b;  //struct类型是值类型，所以a = b 相当于 重新创建了a中的数据而非更改了引用
a.id = 10;
a.name = "zz";
Console.WriteLine(b.name);  //dd
Console.WriteLine(b.id);    //2
```



# enum  枚举类型
为了限制变量的可能性
默认是整数类型，也可以更改
```
enum Days : byte {Monday = 1, Tuesday, Wensday} //默认从0开始，也可以设置值
```

## foreach 的实现
* foreach只能遍历可枚举集合(实现了System.Collections.IEnumerable接口的集合)
* foreach实际调用集合元素的Current属性获取元素的值，然后调用MoveNext方法判断指针是否可以下移



# method
当需要返回多个值时可以用元组的方式实现
```
public static (int, int) doubleReturn()
{
    return (1, 2);
}
```
```
int x,y;
(x, y) = doubleReturn();
```
可选参数与重载歧义
```
public static void doubleReturn(int x, string y="", int z=1)
{
}
public static void doubleReturn(int x, string y="", int z=1, string j="j")
{
}
```
```
doubleReturn(1,"y",1)       //实行第一个方法
doubleReturn(1,"y")         //无法编译，因为无法为任何一个方法提供全部实参
```



# 二进制操作
* ~ NOT     按位求补  ~10010 == 01101
* << >>     左位移|右位移   首先要注意位数，若移动超出位数则超出部分直接舍弃  8位 10001000 << 2 == 00100000
* | OR      按位OR    相同位有1个为1则为1   10010 | 11011 == 11011
* & AND     按位AND   相同位都为1则为1      10010 & 11011 == 10010
* ^ XOR     按位异或    相同位不同为1     10010 ^ 11011 == 01001

## 二进制操作应用
判断一个二进制数bit的n位是否为1
```
(bit & (1 << n)) != 0
```
将n位设置为1
```
bit |= (1 << n)
```



# 数据类型
不同数据用不同内存大小存储以减少内存损耗，C#中有值类型和引用类型
C#中所有数据类型都继承自object，因此所有数据类型都可以使用toString方法

## 值类型
bool,byte,char,decimal,double,float,int,sbyte,short,uint,ulong,ushort
值类型可以看成一个1|0数组（点阵列），不同的位置存储不同的信息
其中数字相关类型，以下格式为 名称(位数,符号[1|0],小数位数)
直接存放在栈中
继承system.ValueType

### 整型
可存储的值为2的位数次方，若有符号则符号占1位，存储的正数永远比负数少1，因为0需要占据一个位置
整形命名规则上u开头一般都无符号，s开头一般都有符号
* byte(8,0)
* sbyte(8,1)
* ushort(16,0)
* int(32,1)
* uint(32,0)
* ulong(64,0)
当整形相除时，结果向下取整，例如 5/2 = 2
当整形和浮点型相除时，会将整形隐式转换为浮点型

#### 字符串转为整型的几种方法
```
int some = Convert.ToInt32("1000"); //当str无法转换为整形时会报错

int some2 = Int32.Parse("1000");    //当str无法转化为整形时会报错

int some3;
bool isPrase = Int32.TryParse("aaa", out some3);    //尝试转换str并给out后的参数赋值
```

### 货币值
比浮点型有更大的精度及更小的范围
* decimal(128,1,28)

### 浮点型
使用科学计数法存储，1位存储符号，1位存储指数符号，一部分存储指数，剩余部分存储精度
指数负数永远比正数少1，即0划归指数负数部分
精度范围是浮动的，以float为例精度23位最大可存储8388608，若实际精度首位是9，则只有6位小数精度
* double(64,1,[15-16])    10位指数 52位精度
* float(32,1,[6-7])     7位指数 23位精度
浮点型也可使用%，7%2.2 = 0.4

### Infinity 及 NaN
* Infinty 无穷大
* NaN 非数字
皆出现在浮点型运算中
* 浮点型非0值除以0 为 Infinty
* 浮点型0值除以0 为 NaN
* Infinty*0 =0 除此之外任何操作仍是Infinty
* NaN的任何操作仍然是NaN
* 整形及demical在除以0时会报错

### n.toString("format")
* C   货币
* D[n]   十进制，n为小数位数，默认0
* E   科学型 25000 -> 	2.500000E+005 实际转为一个浮点数的表现形式
* F[n]   固定小数位，默认2
* G   常规
* N   带有逗号和小数点的数字
* X   十六进制

## 引用类型
在栈中存放值的地址，在堆中存放值
较值类型存储较慢
变更引用类型会影响所有引用了这个值的对象，下面举两例
```
Vector3 pos = transform.position;
pos = Vecotr3.zero; //由于Vector3是值类型，所以transform.position 不会改变
```
```
Material mat = transform.GetComponent<MeshRender>().material;
mat.color = Color.red;//此时MeshRender的颜色也被改变
```
### class
相较于interface可多包含字段、成员、变量、抽象方法
只能继承一个类，可继承多个接口
```
public class Person    //默认为internal
 {
     int a = 1;  //字段，无访问修饰默认为private
     
     public int c { get; set; }  //属性，默认get，set是public方法
     
     public int b
     {
         get
         {
             return b + 10;
         }
         set
         {
             a = value;
         }
     }//属性，get或set其中一个改为方法，其他一个也需要改为方法，属性的本质是方法
     
     public Person(int vv) //class 的构造函数，当没有构造函数时，默认有一个空的构造函数
     {
         a = vv;
     }

     public void Deconstruct(out int x, out int y)  //class 的解构函数，使用(int x, int y) = person 调用
        {
            x = this.a;
            y = this.c;
        }

     public int getA()  //方法，无访问修饰默认为private
     {
         return a;
     }

     public static int getB()  //静态方法相当于存储于类，因此只能通过类访问，不能通过实例化对象访问
     {
         return 1;
     }

     ~ Person(){    //class 的析构器，在clr垃圾回收时调用，

     }
 }
```

#### 属性
* 本质是方法
* 用以访问类中的私有变量
* 可以为get/set分配不同的访问修饰，但访问器的可访问性要等于其中访问性较大的访问修饰
* 自动属性的本质是为属性X创建了一个隐藏的_x的私有变量，因此自动属性必须要设置get

#### 抽象类
一个不完整的类，相当于类的模板，因此不能被实例化
```
abstract public class Person    //默认为internal
{
    abstract public void Zzz();
    virtual public int zzzz()   //virtual (虚方法) 子类可以直接继承，也可以使用override重写
    {
        return 1;
    }
}

public class FromPerson : Person
{
    public override void Zzz()  //抽象类中的抽象方法必须在继承类中实现
    {
        Console.WriteLine("做点什么");
    }
    
    public sealed override int zzzz(){   //sealed 用在方法上时必须用于override方法上，表示改方法无法被重写，即假设有类继承了FromPerson类，也不能再重写zzzz方法
        return 2;
    }
}
```

#### 密封类
```
sealed class Selfme  //sealed 无法被继承
{

}
```

#### 匿名类
匿名类的字段、属性是只读的无法被修改
```
var a = new {fistrname = "ss",lastname = "bb"};
```


#### 静态类
* 类中的所有内容都是静态的，包括构造函数、字段、变量、函数
* 静态类不能创建实例，因为静态类的实例没有意义
* using static className 可以将类中的静态方法引入作用域，可以直接使用方法名调用方法


#### 类的复制
* 浅复制  只复制引用
* 深复制  复制引用的对象
类可以通过提供方法来提供自己的新实例
```
public Circle Clone()
{
    Circle clone = new Circle();
    clone.x = this.x;
    return clone;
}
```


#### 继承
类继承的实例化的顺序，会先调用父类的构造函数，后调用子类的构造函数
一个类可以拥有多个构造函数
继承类时叫实现继承
```
public class Person    //默认为internal
{
    public Person()
    {
    }

    public Person(int a)
    {
    }
}

public class FromPerson : Person
{
    public FromPerson()  //未指定默认继承默认的构造函数
    {
    }

    public FromPerson(int a) : base(a)  //指定继承父类的构造函数
    {
    }

    public FromPerson(string a): this()  //指定继承自己的构造函数
    {
    }
}
```

#### new 和 override的区别
```
public class Person    //默认为internal
{
    virtual public void DoA()
    {
        Console.WriteLine("DoA");
    }

    virtual public void DoB()
    {
        Console.WriteLine("DoB");
    }
}

public class FromPerson : Person
{
    public override void DoA()
    {
        Console.WriteLine("ReDoA");
    }

    new public void DoB()  //new 声明隐藏方法
    {
        Console.WriteLine("ReDoB");
    }
}
```
```
Person newPerson = new FromPerson();

newPerson.DoA();    //调用子方法DoA，因为已经被重写
newPerson.DoB();    //调用父方法DoB，因为DoB没有被重写，只是被隐藏

((FromPerson)newPerson).DoB();    //调用子方法DoB，显示转换后相当于又隐藏了父的DoB类
```

### interface
相当于规则，只能包含方法Method、属性、索引Index、事件Event，不能拥有成员、变量、字段，不能声明成员的修饰符，继承接口的类需要实现接口中的所有要求

* 无法在接口中定义字段
* 无法在接口中定义构造器
* 无法在接口中定义析构器
* 无法在接口方法中指定修饰符，必须为public
* 无法在接口中嵌套枚举、结构、类或其它接口
```
interface IPerson   //一般interface用大写I开头
{
    public int a();
}

interface IPerson2:IPerson   //接口之间相互继承时，子接口不需要实现父接口中的要求
{
    public int b();
}

public class FromInterface : IPerson
{
    public int a()
    {
        return 1;
    }
}
```

#### 接口的显式实现
用于解决继承多个接口时方法冲突的问题
```
interface IAir{
    public int eat();
}
interface ISea{
    public int eat();
}
```
```
Class Animal : IAir, ISea{
    public int eat(){   //如果这样定义，则eat实际同时实现了2个接口中的要求
        return 1;
    }

    public int IAir.eat(){    //这样定义只实现了IAir中要求的方法
        return 1;
    }
}
```
##### 调用
```
Animal animal = new Animal();
IAir air = animal;
ISea sea = animal;
air.eat()   //调用指定接口的方法
```

### this/base
* this 用于访问当前类的属性和方法
* base 可以访问父类的属性和方法

### 索引器
为了使一个类实现类似数组的操作方式
```
public class Person    //默认为internal
{
    private string[] arr;
    
    public Person(string[] arr)
    {
        this.arr = arr;
    }

    public string this[int index]
    {
        get
        {
            string temp;
            if (index >= 0 && index< arr.Length)
            {
                temp = arr[index];
            }
            else
            {
                temp = "";
            }
            return temp;
        }
        set
        {
            if(index >= 0 && index < arr.Length)
            {
                arr[index] = value;
            }
        }
    }
    
    public int this[string name]  //索引的重载
    {
        get
        {
            int index = 0;
            while(index < arr.Length)
            {
                if (arr[index] == name)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }
    }
}
```
```
Person person = new Person();

person[0] = "ss";
person[1] = "ss";

Console.WriteLine(person[0]);
Console.WriteLine(person[1]);

console.WriteLine(person["ss"]);
```

#### 数组和索引器对比
* 索引器可以使用非数值下标
* 索引器可以重载
* 索引器不能作为ref或out参数使用，数组元素可以，大概是因为索引器本质是方法

### 泛型在Class内的实现
极大提高代码重用性，且数据类型是安全的，且提高性能，有助于减少程序体积
```
class MyClass<T>
{
    public T[] array;

    public MyClass(int size)
    {
        array = new T[size];
    }

    public T getValue(int index)
    {
        return array[index];
    }

    public void setValue(int index,T value)
    {
        array[index] = value;
    }
}
```
```
MyClass<int> myClassInt = new MyClass<int>(5);

for (i = 0; i < myClassInt.Size; i++)
{
    myClassInt.setValue(i, 20 * i);
}

for (i = 0; i < myClassInt.Size; i++)
{
    myClassInt.getValue(i);
}

MyClass<string> myClassString = new MyClass<string>(5);

for (i = 0; i <  myClassString.Size; i++)
{
    myClassString.setValue(i, "ss");
}

for(i = 0; i < myClassString.Size; i++)
{
    myClassString.getValue(i);
}
```
* 多重泛型类
```
class MyClass<T,K> where T : struct where K : class  //可通过where 限制泛型的类型，struct 限制只能是值类型，class 限定只能是class 或子类
{
}
```
* 泛型类的继承
```
class MyClass<T,K> where T : struct where K : class
{
}

class MyClassChild<K> : MyClass<int,K> where K : class  //可直接指定父类泛型中的类型，也可以继续继承
{
}
```
* 泛型方法的实现
```
class MyClass<T,K>
{
    public void Action(T value)    //T继承类的泛型，在类创建时已经确定
    {
    }

    public static void Action2<Z>()       //泛型方法，调用时才确定泛型的类型
    {
    }
    
    public void Action<T>(ref T p1,ref T p2)        //使用方法的引用传递ref，实现泛型方法
    {
    }
}
```
```
MyClass<int, string>.Action2<int>();

string a = "v";
string b = "d";
MyClass<int, int>.Action<string> (ref a,ref b);        //使用引用传递时，必须带ref一起进行变量的引用传递
```
* 通过反射，使用变量的类型创建泛型方法
```
class Program
{
    static void Main()
    {
        int z = 0;
        var re = Method.genu(z);
        Console.WriteLine(re);
    }

}

class Method
{
    public static string meth<T>(string str)
    {
        Type t = typeof(T);
        return t.ToString()+"-"+str;
    }
    
    public static object genu(object c)
    {
        string className = c.GetType().FullName;   //获取类的包括命名空间的全名
        Type t = Type.GetType(className);   //获取传入参数的对应类型
        var method = Type.GetType("Test.Method").GetMethod("meth").MakeGenericMethod(new Type[] { t });   //以Type[] 中的类型代替泛型参数T返回构造方法的methodInfo对象
        return method.Invoke(null, new object[] { "hello" });   //委托运行方法
    }
}
```



# switch
控制表达式只能是int|long|char|string...



# 隐式转换和显式转换
## 隐式转换
一般用于小的向大的转换，例如int向long，子类向基类转换等
```
int i = 0;
long l = i; //int向long隐式转换

FromPerson fp = new FromPerson();
Person p = fp;  //FromPerson向Person隐式转换
```
## 显式转换
一般用于大的向小的转换
显式转换一般伴随着数据丢失
```
double n = 1.1;
int m = (int)n; //double向int显式转换，转换完后m为10，丢失了小数点后的精度

Person p2 = new Person();
try
{
    FromPerson fp2 = (FromPerson)p2;    //Person向FromPerson显式转换，显示转换经常报错，因此最好进行trycatch
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}
```
### as
只能用于引用类型或非空类型
对于显式转换，try catch是比较消耗资源的方法，因此一般会用as代替，当无法转换时返回null
```
FromPerson fp3 = p2 as FromPerson;
```



# Nullable
声明变量时可以声明其可能为空，这样在赋值其他可能为空也可能为值类型时就不会报错
```
object obj = null;

int? nullableValue = (int)obj;
System.Nullable<int> nullableValue2 = (int)obj;     //与int?等价

Console.WriteLine( nullableValue.Value ); //当nullableValue为null时会出错
Console.WriteLine(nullableValue.HasValue); //可以获取当前值是否有值，null时返回false
Console.WriteLine( nullableValue.GetValueOrDefault() ); //当nullableValue为null时会返回对应类型的默认值，如int为0
```



# 多态
## 静态多态
在编译时已经实现的多态功能

* 方法多态
```
public class Person    //默认为internal
{
    public static void DoA()    //根据参数不同实现多态
    {
    }

    public static void DoA(int n)    
    {
    }
}
```
```
Person.DoA();

Person.DoA(1);
```

* 运算符多态
```
public class Person    //默认为internal
{
    public int Value { get; set; }

    public static Person operator +(Person d1, Person d2)  //重载运算符，Person类相加时会返回运算后的Person类
    {
        Person a = new Person();
        a.Value = d1.Value + d2.Value;
        return a;
    }
}
```
```
Person newPerson1 = new Person();
Person newPerson2 = new Person();

newPerson1.Value = 1;
newPerson2.Value = 2;
Person ss = newPerson1 + newPerson2;
```

运算符多态时应注意，==和!=，<=和>=，必须一起成对定义

* 转换符多态
```
class Example{
    private int value;

    public static implicit operator  int (Hour from){   //转换符多态
        return from.value;
    }
}
```

* 自定义转换符时需要声明是隐式转换(implicit)还是显式转换(explicit)
## 动态多态
通过override实现
toString方法可以被重写



# 参数数组
解决传多个参数时的方法重载问题
```
public static Min(params int[] parmList){

}
```
```
int min = Min(int1, int2, int3);
```
* 只能使用一维数组
* 不能使用ref或out修饰符
* params必须是最后一个参数，且每个方法只能有一个参数数组
* 如有符合条件的非参数数组方法（即使是可选参数），会优先使用非参数数组的方法
* 当参数类型不一时，可以使用object[] 的参数数组

  
  
# 装箱|拆箱
装箱就是把值类型转为引用类型的操作，下面代码就是i的装箱操作
```
int i = 0;
System.Object obj = i;
```
拆箱就是把引用类型转为值类型的操作，下面代码就是obj的拆箱操作
```
int i = 0;
System.Object obj = i;
int j = (int)obj;
```



# break
C#没有break all



# = 和 ++|--
c = [++|--]a 先自增或自减再赋值
c = a[++|--] 先赋值再自增或自减



# 全等和不全等
C#变量类型是明确规定的，不同的变量类型之间不可以使用逻辑运算符



# 左移且赋值及右移且赋值
是2进制位数的左移或右移
a = 4;
a <<= 2; 即 00100 -> 10000 -> a = 16
a = 4;
a >> 2; 即 00100 -> 00001 -> a = 1



# 数组
dateType[] name
* C#中数组是单一类型数据且长度固定的"集合"（非集合）
* 数组是引用类型，声明数组时不创建堆
* 未赋值的数组无法隐式转换为bool类型或被调用
* 数组有定义的长度，访问超出定义长度的键时会报错
* 在秩中加入逗号可以定义数组维度，int[,] n 即为一个二维数组
>> 深入学习 指针数组、结构数组
* Array.Copy|array.copyto|array.clone  均为浅拷贝



# 集合
集合较之数组，长度可变，且可存储引用类型，更为灵活，但开销也变得更大

* 集合的循环中不能使用add|remove|insert等方法，不然会抛出InvalidOperationException

## 泛型和非泛型
非泛型集合的value是object，所以在存储|读取值类型时会发生大量装箱|拆箱操作，且无法验证数据类型，所以在涉及值类型存储时推荐使用泛型集合

### 常见非泛型集合如下
* ArrayList   根据索引获取数据
* HashTable   根据键获取数据
* SortedList    即可使用键访问数据，也可使用索引访问数据
* Query   队列，先进先出
* Stack   堆栈，后进先出

### 常见泛型集合如下
* SortedList<TKey,TValue>   SortedList的泛型等效类
* List<T>   ArrayList的泛型等效类
* Stack<T>    Stack的泛型等效类
* Queue<T>    Queue的泛型等效类
* Dictionary<TKey,TValue>   字典
* BitArray    点阵列，存储[1|0]这样二进制数据的集合，使用索引访问元素
* HashSet<T>    哈希集合
>>  深入学习：各类型的底层实现

#### 值的获取修改等
使用索引取值的，当无索引会报错
使用索引存值的，当索引重复会报错
Count   集合中包含的元素个数
* void Clear()    清除集合中所有元素
* bool Contains(T)    判断集合中是否存在T
* T[] ToArray()   复制集合中的元素到一个新数组中
* void TrimToSize()   只能在非泛式集合中使用，设置集合容量为当前元素的个数，即释放空项的内存占用，手动回收内存
* void TrimExcess()   只能在泛式集合中使用，功能同上
* void Remove()   键值时匹配键，索引时匹配值，删除第1个匹配的元素，不存在时不报错
* void RemoveAt()   索引时匹配索引，不存在时报错
* void Add(TKey,TValue)   索引时不存在TKey，键值时若重复TKey会报错
>> 深入学习：其他内容
 
#### list[T]
所有list，包括ArrayList,SortList等
* 初始容量为0，当添加元素时容量扩为4，当添加第5个元素时容量扩为8，以后每次容量不够都会2倍扩大
* 扩容过程为创建一个数组，将数据复制到新数组中，因此如果能事先知道容量就可先设置 集合<T>(n)(n为容量)，可以有效避免扩容数组导致的性能损耗
* 当指定容量n不能满足集合长度需求时，容量会扩展为2n
 
* void Add   添加单个元素
* void AddRange  添加多个元素
* void Insert  向指定位置插入数据
* int Capacity  获取容量和设置容量
* int IndexOf|LastIndexOf  返回指定元素的index，不存在返回-1
* void Sort  对列表从小到大排序

#### 哈希表Hashtable
* IsFixedSize   是否固定大小
* IsReadOnly    是否只读
* Item    
* Keys    获取哈希表中键的集合
* Value   获取哈希表中值的集合
* void Add(object key,object value)
* bool ContainsKey(object key)
* bool ContainsValue(object value)
排序类似堆栈，后添加的在表最前

#### 队列[Query|Query[T]]方法汇总
* void Enqueue(T)   T入队
* T Dequeue()   T出队，返回T

#### 堆栈[Stack|Stack[T]]
* T Peek()    返回Stack顶部对象，不删除
* T Pop()   返回并删除Stack顶部对象（弹出元素）
* void Push(T)    推入元素

#### 字典 Dictionary<TKey,TValue>
* 在索引号并非int类型时使用
* 键值
* 使用索引获取值，索引值先通过散列函数寻找哈希桶中的值，然后根据哈希桶对应的值在单链表中寻找索引中对应的元素
* 在大量内存可用时高效，随着元素插入可能会消耗大量内存
* foreach 字典返回的是类型为KeyValuePair<TKey,TValue>的只读元素
>> 深入学习：哈希函数构建及解决哈希冲突的其他方法

#### SortList<TKey,TValue>
* SortList 与Dictionary、SortedDictionary类似
* 永远是排好序的

#### 哈希集合 HashSet<T>
* 提供集合的优化操作，判断集合是否为另一个集合的子集或超集，或生成交集、并集、差集
* HashSet<T> IntersectWith  交集
* HashSet<T> UnionWith  并集
* HashSet<T> ExceptWith  差集
* SortSet<T> 和 HashSet<T> 可以互相操作



# String
* 引用类型，但通过值传递，a = "1"; b = a; a="c"; 此时a引用"c"，b引用"1"，因此每次修改字符串都会在内存中新建一个新字符串并更改引用，在需多次修改字符串时，推荐使用StringBulider
* "1" 的类型是string '1'的类型是char
* 像一个char的数组，通过String[n]的索引形式获取对应的char
* 通过new string(char[] array)构造
* 通过string.join("分隔符",string[] array)构造
* 字符串是一个不可变的数据类型，一旦创建就不可以再改变内容了
 
### 在string前加@可防止其转为Unicode编码
 ```
 string str1 = @"C:\path\file";
 string str2 = "C:\\path\\file";
 ```
>> 深入学习 通过String.Format()构造

## 比较字符串
按从左往右顺序依次比较，-1为右边字符串对应位置的char值大，相等返回0，
* int Compare   String.Compare(str1,str2,true|false)|String.Compare(str1,index1,str2,index2,length,true|false)，true|false是否区分大小写，index及length可比较相应位数
* int CompareTo   str1.CompareTo(str2)，区分大小写
* int CompareOrdinal    String.CompareOrdinal(str1,str2)，str1的char总值 - str2的char总值，String.CompareOrdinal("ab","cd") -> -4
* bool Equals    String.Equals(str1,str2)|str1.Equals(str2)，区分大小写

## 字符串检索
* bool StartsWith   str1.StartsWith(string)
* bool EndsWith   str1.EndsWith(string)
* int IndexOf   str1.IndexOf(string,index1,length)    不包含返回-1，包含返回第一个字符的索引
* int LastIndexOf   str1.LastIndexOf(string,index1,length)，从后往前检索，index不变
* int IndexOfAny    str1.IndexOfAny(char[],index1,length)
* int LastIndexOfAny    str1.LastIndexOfAny(char[],index1,length)，从后往前检索，index不变

## 字符串格式化
string.Format("{0[ ,m ][ :[C|D|E|F|G|N|P|R|X][0-9]*? ] }")
* C|c   货币
* D|d   十进制
* E|e   指数 如1.23456E+005
* F|f   固定小数位，精度最高15位（使用双精度，单精度只有7位）
* G|g   常用格式
* N|n   逗号分隔千分位
* P|p   百分号形式
* R|r   圆整，无视有效数字，精度最高17位（使用双精度，单精度只有9位）
* X|x   十六进制

### 当string时间，如System.DateTime.now
* D   *年*月*日
* d   */*/*
* T   *:*:*
* t   *:*
* Y|y   *年*月
* M|m   *月*日

### 字符串插值
比+高效，是string.format的语法糖
```
string ssss = "sss";
$"ddd{ssss}";    //dddsss
```
以上代码相当于
```
object[] args = new object[] { ssss };
string.Format("ddd{0}", args);
```

## 字符串连接
* string Contact    string.Contact([string[]|string|char[]|char],*)
* string Join   string.Join("delimiter",[string[]|string|char[]|char],*)

## 字符分隔
* string[] Splite   string[] = str1.Splite(char)

## 字符串截取
* int Substring  str1.Substring(index,length)

## 字符串插入
* string Insert   str1.Insert(index,string)

## 字符串删除
* string Remove   str1.Remove(index,length)
* string Trim   str1.Trim([char[]|char],..*)
* string TrimStart
* string TrimEnd

## 字符串替换
* srting Replace    str1.Replace(char,char)|str1.Replace(string,string)

## 更改大小写
* string ToUpper
* string ToLower


 
# StringBulider
 * System.Text 命名空间
 * 引用类型
 * 当长度不超过stringBuilder定义长度时，不创建新的内存堆
 * 当长度超过定义长度时，会重新申请一个现长度2倍的空间，然后将值复制到新字符串上，旧字符串空间会被GC回收
 >> 深入学习：当新字符串长度超过现在字符串的2倍时如何申请内存空间
 ## Append | AppendFormat
 ```
 StringBuilder sb = new StringBuilder(20);    //创建一个20字符大小的StringBuilder，避免申请新内存
 StringBuilder sb2 = new StringBuilder("ssss",20);

 StringBuilder builder = new StringBuilder("sss");
 builder.Append("dd"); //sssdd
 builder.AppendFormat("aaa{0}", "bb"); //sssddaaabb
 ```
 ## Insert(index,string)
 ```
 sb.Insert(0, "sss");
 ```
 ## Remove(index,length)
 ```
 sb.Remove(0, 3);
 ```
 ## Replace(char, char)|Replace(string,string)


 
# 文件及文件夹操作

## 文件夹操作
Directory和DirectroyInfo类都可以操作文件夹且有类似方法，区别是Directory类是静态方法，每次都需要调用目录，而DirectoryInfo类则在创建类时完成了定义
* 文件夹创建  
Directory.Create(@"path")|new DirectoryInfo(@"path").Create()
* 文件夹删除，无目标文件会报错
Directory.Delete(@"path")|new DirectoryInfo(@"path").Delete()
* 文件夹是否存在
Directory.Exists(@"path")|new DirectoryInfo(@"path").Exists
* 剪切文件夹，目标文件夹已经存在会报错
Directory.Move(@"pathFrom",@"pathTo")|new DirectoryInfo(@"path").MoveTo(@"pathTo")
* 设置文件夹
Directory.Create(@"path").Attributes = FileAttributes.[ReadOnly|Hidden|Temporary(临时)|Encrypted(加密)]
* 搜索文件夹，返回相关的FileInfo实例
Directory.GetFiles(@"path","searchStr");

## 文件操作
File类及FileInfo类同上
* 复制，源文件不存在时报错
File.Copy(@"pathFrom",@"pathTo")|new FileInfo(@"path").CopyTo(@"pathTo")
>> 深入学习：复制目标文件存在时会报错么？

## 文件读写操作
FlieStream
推荐在using内使用FileStream，using等效于try{}finally{}，并在finally内调用的Dispose方法清理资源
using( FileStream fs = File.Open(path,FileMode,FileAccess,FileShare) ){}
或者可按需使用StreamReader或StreamWriter
```
using (FileStream fs = File.Open(@"path", FileMode.Open, FileAccess.Read))
{
    byte[] buffer = new byte[4096];
    int start = 0;
    int length = 10;
    fs.Read(buffer,start,length);
} 
 
using (StreamReader sr = File.OpenText(@"path"))
{
    sr.ReadLine();  //每次执行读一行，当没有数据时返回null
}
```

### FileMode
* Append    打开并追加，需要与FileMode = Write，一起使用
* Create    创建新并覆盖
* CreateNew   创建新，如果已存在则报错
* Open    打开，不存在会报错
* OpenOrCreate    不存在时创建新，存在时打开
* Truncate    打开并清空文件，不存在会报错

### FileAccess
* Read    读
* Write   写
* ReadWrite   读写

### FileShare   文件共享方式
* None    不允许操作
* Read    允许读
* Write   允许写
* ReadWrite   允许读写

Read    fs.Read(byte[], startIndex, endIndex)
Write   fs.White(byte[], startIndex, endIndex)
Close   fs.Close() 关闭文件

>> 深入学习：测试文件流读写



# C#常用数据交互

## xml
xml文件读取与解析
```
<skills>
	<skill
		id ="1"
		name="zzz"
		>
		<demage>2</demage>
	</skill>
</skills>
```
```
class Program
{
    static void Main()
    {
        List<Skill> skills = new List<Skill>();

        XmlDocument doc = new XmlDocument();
        doc.Load("data2.xml");       //按路径获取文档
        XmlNode node = doc.FirstChild;      //获取第一个节点，当有xml版本号等内容时获取不到

        XmlNodeList nodeList = node.ChildNodes;

        foreach (XmlNode skillNode in nodeList)
        {
            Skill newSkill = new Skill();

            XmlAttributeCollection col = skillNode.Attributes;

            newSkill.id = Int32.Parse(col["id"].Value);
            newSkill.name = col["name"].Value;

            XmlElement ele = skillNode["demage"];
            
            newSkill.demage = Int32.Parse(ele.InnerText);
            
            skills.Add(newSkill);
        }

        Console.WriteLine(skills.Count);

        foreach (Skill skill in skills)
        {
            Console.WriteLine(skill);
        }

        Console.ReadKey();
    }
}

class Skill
{
    public int id { get; set; }
    public string name { get; set; }
    public int demage { get; set; }

    public override string ToString()
    {
        return String.Format("id:{0}  name:{1}  demage:{2}", id, name, demage);
    }
}
```

## JSON
* 轻量级文本交换格式
* 独立于语言
* 具有自我描述性，更容易理解

C#解析json一般安装LitJson

### JSON解析
```
{
	"skills": [
		{
			"id": 1,
			"name": "zzz",
			"demage": 2
		}
	]
}
```
```
class Program
{
    static void Main()
    {
        List<Skill> skills = new List<Skill>();

        JsonData data = JsonMapper.ToObject(File.ReadAllText("json.json"));

        JsonData skillsData = data["skills"];

        foreach (JsonData skill in skillsData)
        {
            Skill newSkill = new Skill();
            newSkill.id = Int32.Parse(skill["id"].ToString());
            newSkill.name = skill["name"].ToString();
            newSkill.demage = Int32.Parse(skill["demage"].ToString());

            skills.Add(newSkill);
        }

        foreach (Skill skill in skills)
        {
            Console.WriteLine(skill);
        }

        Console.ReadKey();
    }
}

class Skill
{
    public int id { get; set; }
    public string name { get; set; }
    public int demage { get; set; }

    public override string ToString()
    {
        return String.Format("id:{0}  name:{1}  demage:{2}", id, name, demage);
    }
}
```

### 更简单的解析方法
```
[
	{
		"id": 1,
		"name": "zzz",
		"demage": 2
	}
]
```
```
Skill[] skill_array = JsonMapper.ToObject<Skill[]>(File.ReadAllText("json2.json"));     //转换成数组

skills = JsonMapper.ToObject<List<Skill>>(File.ReadAllText("json2.json"));      //转换成List
```

### 对对象的解析
```
{
	"Name": "h2o",
	"Age": 20,
	"SkillList": [
		{
			"id": 1,
			"name": "zzz",
			"demage": 2
		},
		{
			"id": 2,
			"name": "ddd",
			"demage": 10
		}
	]
}
```
```
class Skill
{
    public int id { get; set; }
    public string name { get; set; }
    public int demage { get; set; }

    public override string ToString()
    {
        return String.Format("id:{0}  name:{1}  demage:{2}", id, name, demage);
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Skill> SkillList { get; set; }

    public override string ToString()
    {
        return String.Format("name:{0}  age:{1}", Name, Age);
    }
}
```
```
Person person = JsonMapper.ToObject<Person>(File.ReadAllText("json3.json"));

Console.WriteLine(person);
```

### 打包JSON对象
```
Player player = new Player();
player.Name = "h2o";
player.Age = 20;
player.Level = 50;

string message = JsonMapper.ToJson(player);

Console.WriteLine(message);
```





# 正则表达式
@"正则表达式"可表示这是一个正则表达式，否则\n需写成\\n
参考微软文档：https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/regular-expressions

## Regex类
#### Match Match   返回第一个匹配的Match对象，Match继承自Group，Group继承自Capture，可通过match.Groups返回所有匹配的分组，可访问Capture的Index,Length,Value属性，直接调用则返回Value
#### MatchCollection Matches   返回所以匹配的match的集合
* bool isMatch    是否匹配
* string Replace    替换
* string[] Split    分隔
 
Regex.[Match|Matches|isMatch|Replace|Split](str,partten,Regex.RegexOptions|..*)

### RegexOptions
* Complied    对表达式进行编译，原会直接进行解释操作，而编译会先将正则表达式由正则表达式引擎缓存，因此在多次调用时可以提高性能，但会提高初次调用的成本
* CultureInvariant    忽略文化差异，比如土耳其地区I并非i的大写选项
* ECMAScript    符合ECMAScript规则，只能和IgnoreCase、Multiline、Complied连用
* ExplicitCapture   仅捕获显式命名组，内联组元素(?n)可禁止自动捕获也可达到类似效果 b(a) 会捕获ba及a，使用显示捕获则只返回 ba
* IgnoreCase    无视大小写
* IgnorePattenWhitespace    去除正则表达式中的非转义空白符号，且#开始至\n都会被认为是该正则表达式的注释，可用内联(?x)达到同样效果
* Multiline   ^$可用来匹配换行符n，^s 匹配 aaa\nsss 是无匹配的，Muliline后可以获得匹配
* None    默认，无意义
* RightToLeft   从右往左
* Singleline    .可以匹配任意字符，原.只能匹配除换行符\n外的任意字符
>> 深入学习：ECMAScript

### 转义字符
* \a    匹配响铃字符
* \b    匹配单词边界
* \B    匹配非单词边界
* \t    匹配制表符
* \r    匹配回车
* \v    匹配垂直制表符
* \f    匹配换页符
* \n    匹配换行符
* \e    匹配转义
* \[nnn]    匹配ASCII字符，nnn表示八进制字符的2或3位数
* \x[nn]    匹配ASCII字符，nn表示十六进制字符的2位数
* \c[n]    匹配ASCII的控制字符，n位控制字符首字母，例如\cC为CTRL-C
* \u[nnnn]    匹配UTF-16，nnnn是十六进制

### 字符
* \w    匹配任何单词字符
* \W    匹配任何非单词字符
* \s    匹配空白字符
* \S    匹配任何非空白字符
* \d    匹配十进制数字
* \D    匹配任何非十进制数字的字符

### 定位点
* ^   字符串开头或行开头
* $   字符串结尾或行结尾或\n前
* \A    字符串开头
* \Z    字符串结尾或\n前
* \z    字符串结尾
* \G    上一个匹配结束的地方
>> 深入学习：\G

### 限定符
* *   0或多
* ?   0或1
* +   1或多
* {n}   n次
* {n1,n2}   n1-n2次

>> 深入学习：正则表达式的数学算法
 
 
 
# delegate、event 委托和事件
 
## delegate 委托
委托是实现事件和回调函数的基础
类似依赖注入
 
### 委托的静态调用
 ```
 delegate int numberChange(int n);
 ```
 ```
 static int num;

 public static int AddNum(int n)
 {
     num +=n;
     return num;

 }
 
 void main
 {
     numberChange nc = new numberChange(AddNum);
     nc(25);
 }
 ```
 
 ### 委托调用实例化方法
  ```
 delegate int numberChange(int n);

 public class Mc
 {
     static int num;
     public int AddNum(int n)
     {
         num += n;
         return num;
     }
 }
 ```
 ```
 Mc mc = new Mc();
 numberChange nc = new numberChange(mc.AddNum);
 nc(25);
 ```
    
### Action|Func
 匿名委托
 
 #### Action  当没有返回参数时使用
 ```
 static void ThreadMethod(object obj)
 {
     Console.WriteLine("做点什么");
 }


 static void main()
 {
     Action<object> a = ThreadMethod; 
 }
 ```
 
 #### Func  当有返回参数时使用
 ```
 static string ThreadMethod(object obj)
 {
     Console.WriteLine("做点什么");
     return "";
 }


 static void main()
 {
     Func<object,string> a = ThreadMethod; 
 }
 ```
    
### 多重委托
多个同类委托可以相加减，会依次执行委托
若有返回值，多重委托只能获得最后一个委托的返回值，因此多重委托一般只用于没有返回值的时候
 ```
 public class Mc
 {
     static int num;
     public static int AddNum(int n)
     {
         num += n;
         return num;
     }

     public static int AddNum2(int n)
     {
         num += n;
         return num;
     }
 }
 ```
 ```
 numberChange nc1 = new numberChange(Mc.AddNum);
 numberChange nc2 = new numberChange(Mc.AddNum2);
 numberChange nc3 = nc1 + nc2;

 nc3(25); //先执行 nc1 后执行 nc2
 
 nc3 += nc1;
 nc3 -= nc1; //委托相减会先减去后添加的委托
 
 nc3(25); //先执行nc1 再执行nc2
 
 nc3 -= nc1;
 nc3 -= nc2;
 
 nc3 -= nc2; //不会报错，相当于没有效果
 
 nc3(25); //当委托列表为空时报错
 ```
 
 ### 泛型在委托上的实现
 ```
 delegate T NumberChange<T>(T obj);
 ```
 ```
 NumberChange<int> nc = new NumberChange<int>(Mc.AddNum);
 nc(25);
 ```
 
 ## event 事件
 一种特殊的委托，只能在类内部触发，为委托提供了一种发布订阅的模式
 ```
 public class Mc
 {
     static int num;
     public delegate int numberChange(int n);
     public event numberChange NC;

     public Mc(int n)
     {
         SetNumber(n);
     }

     protected virtual void OnNumChange()
     {
         if(NC != null)
         {
             NC(25);
         }
         else
         {
             Console.WriteLine("Event havn't been binded");
         }
     }

     public void SetNumber(int n)
     {
         if(num != n)
         {
             num = n;
             OnNumChange();  //触发事件
         }
     }

     public static int AddNum(int n)
     {
         num += n;
         return num;
     }
 }
 ```
 ```
 Mc mc = new Mc(5);  //事件未绑定，输出信息
 mc.NC += new Mc.numberChange(Mc.AddNum);
 mc.SetNumber(10);   //触发事件
 ```
 可参考继承EventHandler
 
 
 
 # 匿名函数
 ```
 delegate(string s){
     Console.WriteLine(s);
 }
 ```
 ```
 (x) => {
     Console.WriteLine(s);
 }
 ```
 
  
 
# lambda
 () => expression
 ```
 Func<string, bool> func = x => x == "ss";

 Console.WriteLine(func("ss"));
 Console.WriteLine(func("dd"));
 ```
 ```
 Func<string, bool> func = (x) => {  //当参数为一个时可以省略()
     return x == "ss";   //当函数只有一行时可以省略{}和return
 };
 ```
 
    
 
 # 异常处理
 catch 异常非常消耗性能，因此一般只捕获对应异常
 
 ## 常见异常类型
 * ArgumentException  参数异常
 * ArgumentNullException  参数为空异常
 * ArgumentOutOfRangeException  参数超出范围异常
 * DirectoryNotFoundException  路径未找到异常
 * FileNotFoundException  文件未找到异常
 * InvalidOperationException  非法运算符异常
 * NotImplementedException  未实现异常
 >> 深入学习：其他异常类型
 
 ## 异常处理
 ```
 int x = 0;
 try
 {
     int y = 100 / x;
 }catch(DirectoryNotFoundException e)
 {
     Console.WriteLine(e.Message);
 }
 catch(DivideByZeroException e)
 {
     Console.WriteLine(e.Message);
 }
 finally
 {

 }
 ```
 >> 深入学习：C#的底层异常处理机制
 
 
 
 # Attribute
 特性，允许我们向程序的程序集增加元数据的语言结构，是用于保存某种程序结构信息的特殊的类
 在源代码中创建特性，通过编译器编译在程序集中，当编译器/CLR/浏览器 访问程序集时会消费特性
 ## 常见内置Attribute
 * Conditional 按宏，如果宏被定义则运行，没用被定义则不运行，常见宏有[DEBUG|PRODUCTION]
 ```
 #define ISTEST

 [Conditional("DEBUG")]
 public static void Message(string msg)   //此方法只在DEBUG模式中才会被调用，其他模式下调用会报错
 {
     Console.WriteLine(msg);
 }
 ```
 * Obsolete 弃用
 ```
 [Obsolete("message",false)]
 public static void Message2(string msg)     //标记此方法已经弃用，message为提示信息，bool为是否报错，为false则是该方法仍可被使用
 {
     Console.WriteLine(msg); 
 }
 ```
 * debugerStepThrough
 ```
 [DebuggerStepThrough]      //当断点调试时，单步运行会直接跳过该方法，不会进入该方法逐一调试
 public void callTest(string str)
 {
     Console.WriteLine(str);
 }
 ```

 ## 调用者信息特性
 * CallerFilePath string    获取调用的文件路径
 * CallerLineNumber int     获取调用的行数
 * CallerMemberName string      获取调用的方法名
 ```
 public void callTest(string str, [CallerFilePath] string callPath = "")    //变量会由系统进行自动传递，需要给一个默认值且放置在其他参数后
 {
     Console.WriteLine(callPath);
 }
 ```
 
 ## 自定义Attribute
 用来表示目标结构的一些状态，一般只定义字段和属性，不定义方法
 可通过继承System.Attribute类创建一个自定义Attribute
 命名必须是自定义部分+Attribute
 一般情况下声明为sealed
 调用时可以通过命名时的自定义部分调用，或者通过全名调用
 可在Attribute内设置的属性类型有限，可以是所有内置的值类型、System.Type、object、enum等
 ```
 [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
 class HelpAttribute: Attribute
 {
     protected string description;
     public HelpAttribute(string description)
     {
         this.description = description;
     }

     public string Description
     {
         get
         {
             return this.description;
         }
     }
 
     public string Name { get; set; }
 }
 ```
 ```
 [Help("ddd",Name = "ssss")]  //可以用Help或HelpAttribute调用，当设置其他参数时，可以用在后面跟随的方式传递
 public static void myFun()
 {
 }
 ```
 
 ### AttributeUsage
 自定义Attribute的使用目标限制
 * AttributeTargets  规定Attribute的使用范围，常见的有All|Class|Method|Interface等
 * AllowMulitiple  规定Attribute在单个类型上的能否被多次使用
 * Inherited  规定Attribute是否能被继承
 
 ## Attribute的信息获取
 通过反射获取Attribute内的信息
 ```
 static void main(string[] arg)
 {
     HelpAttribute help;

     foreach(var attr in typeof(Dosome).GetCustomAttributes(true))  //遍历Dosome类中所有自定义的Attribute，bool参数表示是否搜索继承树
     {
         help = attr as HelpAttribute;  //找到自定义Attribute内是HelpAttribute的Attribute

         if(help != null)
         {
             Console.WriteLine(help.Description);  //找到后获取该Attribute的信息
         }
     }
 }
 ```
 
 
 
# 反射
 一个运行的程序查看本身或其他程序元数据的行为叫做反射。即程序可以观测并修改自己的能力
 
 ##元数据
 程序及类拥有的数据
 
 ## 基于type的反射
 type只存储类的成员，只能获得公有的数据即public定义的成员
 * obj.GetType
 * Type.GetType("type_name", [true|false], [true|false])  第一参数为type命例如stystem.string，第二个参数是是否报错，第三个参数是是否忽略type名大小写
 * typeof(obj)
 ```
 string ss;
 ss.GetType();  //GetType 实际返回的是CLR保存在堆中的类型引用的地址，这里要区别于类型实例的引用地址
 Type.GetType("System.Sting", false, true);
 typeof(ss)
 ```
 
 ## 对于method|field|properrite的反射
 对方法的反射
 * <Type>t.GetMethods("BindFlags.pram")  获取所有方法，可通过Flags标志位缩小结果范围
 * <Type>t.GetMethod("method_name")  获取指定方法
 * <Type>t.GetFields("BindFlags.pram")  获取所有字段
 * <Type>t.GetFields("method_name")  获取指定字段
 * <Type>t.GetProperties("BindFlags.pram")  获取所有属性
 * <Type>t.GetPropertie("method_name")  获取指定属性
 ```
 Type type = typeof(int);
 type.GetMethods();   //获取int类型的所有方法
 type.GetMethods(BindingFlags.Public);   //获取int类型的所有public方法
 ```
 
 ## 基于Assembly(程序集)的反射
 
 ### 动态加载
 可以通过assembly的反射获取其中的type
 * Assembly.Load("assemblyString")  通过程序集名称加载
 * Assembly.LoadFrom("path")  通过程序集路径加载
 * Type.Assembly  通过类的对象获取
 ```
 Assembly assembly;
 assembly = Assembly.Load("assemblyString");
 Type[] types = assembly.GetTypes();
 ```
 
 ### 推迟绑定
 ```
 class Program
 {
     public void main()
     {
         Assembly assembly;
         assembly = Assembly.GetExecutingAssembly();
         Type t = assembly.GetType("Test.myClass", false, true);     //寻找目标类
         object obj = Activator.CreateInstance(t);       //实例化对应Type
         MethodInfo mi = t.GetMethod("isMove");      //判断是否有方法
         var isMove = (bool)mi.Invoke(obj, null);        //<MethodInfo>.Invoke 使用参数二的参数执行参数一中的mi方法

         if (isMove)
         {
             Console.WriteLine("isMove");
         }
     }
 }

 class myClass
 {
     public bool isMove() { return false; }
 }
 ```
 
 ## 运行时创建类
 >> 深入学习：System.Emit
 
 
 
# 预处理指令
 为了让编译器[VS]在编译前预先处理指令
 ```
 #define DEBUG //定义为DEBUG模式
 namespace MyProject;

 class Program{
     void main()
     {
         #region something
         //此处为可折叠区域
         #endregion

         #if (DEBUG) //当模式为DEBUG时 if内代码才有效
         Console.WriteLine("ss");
         #endif
     }
 }
 ```
 
 
 
# LINQ
 Lanuage InterGated Query，语言整合查询，用于操作数据，用于弥补数据库面向数据与C#面向对象之间的差距
 由微软设计的语法
 创建时并不会执行，类似惰性数组
 LINQ 包含5部分，以下用到LINQ to Objects
 * LINQ to Objects
 * LINQ to XML
 * LINQ to SQL
 * LINQ to Dataset
 * LINQ to Entities
 LINQ 语法顺序
 from in => join in on equals => let => orderBy => where => group => select => into
 
 ## query语法
 * Data Source  数据源
 * Query Creation  query语句创建
 * Query excution  query执行
 ```
 int[] numbers = { 1, 2, 3, 8, 6, 10 };

 var numberQuery = from num in numbers   //获取数据源
                   where num%2 == 0 && num%3 == 1   //过滤条件，query不执行，可以有效缩小结果范围，减速内存损耗
                   orderby num descending, num2 ascending   //descending|ascending
                   select num;   //创建LINQ后不会立即执行，如需要立即执行，可在后面调用一些query方法，例如query.Count(),query.ToList(),query.ToArray()

 foreach(var i in numberQuery)   //调用LINQ时，才会执行
 {
     Console.WriteLine(i);
 }
 ```
 ### join、group、into、let
 ```
 public class customer
 {
     public string Name { get; set; }
     public string Place { get; set; }

     public customer(string name,string place)
     {
         Name = name;
         Place = place;
     }
 }

 public class office
 {
     public string Name { get; set; }
     public int Id { get; set; }

     public office(string name, int id)
     {
         Name = name;
         Id = id;
     }
 }
 ```
 ```
 List<customer> customers = new List<customer>();

 customers.Add(new customer("li lei","beijing"));
 customers.Add(new customer("han meimei", "xizang"));
 customers.Add(new customer("wang", "beijing"));

 var queryCustomer = from customer in customers
                     group customer by customer.Place;   //group
 
 foreach (var c in queryCustomer)
 {
     foreach(var d in c)
     {
         Console.WriteLine(d.Name);
         Console.WriteLine(d.Place);
     }
 }
 
 var queryCustomerInto = from customer in customers
                         group customer by customer.Place into intoGroup     //into
                         where intoGroup.Count() >= 2    //可以对结果集进行筛选
                         select {count = intoGroup.Count(), key = intoGroup.Key};  //Key表示分组的依据，此处为customer.Place的值

 foreach (var c in queryCustomerInto)
 {
     foreach (var d in c)
     {
         Console.WriteLine(d.Name);
         Console.WriteLine(d.Place);
     }
 }

 List<office> offices = new List<office>();
 offices.Add(new office("li lei", 50));
 offices.Add(new office("somebody", 60));

 var queryJoin = from c in customers
                 join o in offices on c.Name equals o.Name   //join join只能equal join
                 select new { c.Name, c.Place, o.Id };
 
 foreach (var c in queryCustomerInto)
 {
     Console.WriteLine(c.Name);
     Console.WriteLine(c.Place);
     Console.WriteLine(c.Id);
 }
 
 string[] strs = { "ss ee", "dd ff", "cc" };
 var queryStr = from s in strs
                let wrods = s.Split(' ')   //let相当于创建值以在linq中存储中间变量
                from w in wrods
                let wrod = w.ToUpper()
                select wrod;

 foreach(var d in queryStr)
 {
     Console.WriteLine(d);
 }
 ```
 
 ## method方法
 ```
 int[] numbers = { 1, 2, 3, 8, 6, 10 };

 numbers.Where(x=>x%2 == 0).OrderBy(x => x);   //method方法实现，是在system.Linq定义的string的扩展方法
 
 foreach(var i in numberQuery)
 {
     Console.WriteLine(i);
 }

 bool res_one = numbers.Any(x => x==2);     //判断是否有满足条件的值

 Console.writeLine(res_one);

 bool res_all = numbers.All(x => x==2);     //判断是否都满足条件

 Console.writeLine(res_all);


 customers.Add(new customer("li lei","beijing"));
 customers.Add(new customer("han meimei", "xizang"));
 customers.Add(new customer("wang", "beijing"));

 offices.Add(new office("li lei", 50));
 offices.Add(new office("somebody", 60));

 customers
    .selectMany(x=>office, (x,y) => new {customer = x,office = y}
    .Where(x=>x.customer.Name == x.office.Name)
    .OrderBy(x=>x.office.Id)
    .ThenBy(x=>x.office.Name);      //在前一个相同时按此排序
 ```

 >> 深入学习：集合操作符 分区操作符

 ## PLINQ
 ```
  var queryCustomerInto = from customer in customers.AsParallel()   //指定为ParallelQuery对象 
                         group customer by customer.Place into intoGroup
                         where intoGroup.Count() >= 2
                         select {count = intoGroup.Count(), key = intoGroup.Key};
 ```
 

 
# 扩展方法
* 在不想继承或改变原class的情况下，新增方法
* 将静态类引入作用域即可生效
 
## 在class上实现
 ```
 public static class myStr
 {
     public static int thisCount(this string str)  //需在非继承静态类中定义静态方法，string可替换成其它任意的class
     {
         return str.Split(new char[]{ ' ',',','.'}, StringSplitOptions.RemoveEmptyEntries).Length;
     }
 }
 ```
 ```
 string str = "ss zz dd.bb";
 Console.Write(str.thisCount());
 ```
 
 ## 在枚举类型上实现
 ```
 public enum Grade { F = 0, E, D, C, B, A }

 public static class GradeExtension
 {
     public static Grade pass = Grade.D;

     public static bool passing(this Grade grade)
     {
         return grade >= pass;
     }
 }
 ```
 ```
 Grade[] grades = { Grade.A, Grade.F, Grade.B };

 foreach(Grade g in grades)
 {
     Console.WriteLine(g.passing());
 }
 ```
 
 
 
# C#线程
 当某个方法比较耗时时才考虑开启线程处理

 * 线程过饱和：线程数超过最优线程数，响应能力会变差
 * 线程欠饱和：线程数少于最优线程数，大量处理能力会被浪费
 * 通过将线程加入队列，并使用工作窃取算法，保证线程高效运转
 * 最优线程数是WinRt通过爬山算法动态调节的

 注：\
 工作窃取算法：多个处理器有多个线程池，当一个线程池空闲时会从别的线程池的队列窃取一个工作项进行处理\
 爬山算法：创建线程运行任务，找出添加线程反而导致性能下降的点，将线程保持在这个点以下
 
### 前台线程与后台线程
 一个进程如果有前台线程，即使main线程被关闭，也仍会运行直到所有前台线程结束
 如果一个进程的所有前台进程全部结束，则所有相关后台进程会被强制关闭
 
### 线程的优先级
 优先级高的线程会被优先执行，优先级一样的线程按分配同时执行

 创建线程有4种方式，begingInvoke(委托)、Thread类、ThreadPool(线程池)、Task(任务)

## BeginInvoke  委托开启线程
 ```
static int ThreadMethod(int i)
 {
     Console.WriteLine("做点什么");
     return 100;
 }

 static void Callback(IAsyncResult ar)  //回调函数的参数必须为object
 {
     object obj = ar.AsyncState; //可通过ar获取BeginInvoke时传递给回调函数的参数
 }

 static void main()
 {
     Func<int,int> a = ThreadMethod;
     IAsyncResult ar = a.BeginInvoke(100, Callback, null);  //先传递函数所需参数，后传递回调函数及回调函数的参数，ar可以获取当前委托的状态
 }
 ```
 ### 监听委托结束的方法
 通过 ar.AsyncWaitHandle.WaitOne()等待线程结束
 ```
 Func<int,int> a = ThreadMethod;
 IAsyncResult ar = a.BeginInvoke(100, Callback, null); //ar

 bool isEnded = ar.AsyncWaitHandle.WaitOne(1000); //等待线程执行或等待1000毫秒
 if (isEnded)
 {
     int result = a.EndInvoke(ar); //可以通过EndInvoke方法获取a执行完毕的结果
 }
 ```
 通过回调函数
 ```
 a.BeginInvoke(100,ar => {
     int res = a.EndInvoke(ar); //获取函数处理完成结果
 },null);
 ```
 
 ## Thread类
 通过静态函数创建
 默认创建是前台线程，可设置isBackground = true变为后台进程
 #### Priority  线程优先级
 * Highest
 * AboveNormal
 * Normal
 * BelowNormal
 * Lowest
 ```
 static void ThreadMethod(object obj)
 {
     Console.WriteLine("做点什么");
     int id = Thread.CurrentThread.ManagedThreadId; //可通过Thread.CurrentThread.ManagedThreadId获取当前线程id
 }

 static void main()
 {
     Thread th = new Thread(ThreadMethod);//创建完成时不开启线程
     th.IsBackground = true;//设置后台进程
     th.Priority = ThreadPriority.Normal;//设置优先级
     th.Start("ss");//开启线程，函数参数可以在这里传递，调用后线程是Unstarted状态，要等cpu分配并开始后，才是Running状态
 }
 ```
 通过类方法创建
 ```
 //类
 class MyThread
 {
     private string name;
     private int id;

     public MyThread(string name, int id)
     {
         this.name = name;
         this.id = id;
     }

     public void ThreadMethod()
     {
         Console.WriteLine("做点什么");
     }
 }
 ```
 ```
 //创建Thread
 static void main()
 {
     MyThread my = new MyThread("name",100);

     Thread th = new Thread(my.ThreadMethod);
     th.Start();
 }
 ```
 
 ### Abort()
 终止线程并抛出异常，可以用try catch捕获
 
 ### Join()
 在线程内调用Join会暂停当前线程等待其他线程执行完毕
 ```
 t.Join() //等待t线程执行完毕后，当前线程才会继续执行
 ```
 
 ## ThreadPool  线程池
 全部为后台线程，且不能修改，也无法修改优先级或者名称
 当需要执行很多不同的小任务时，可以通过线程池预先创建线程，当线程需要被调用时，可以直接使用
 双核cpu 默认设置为1023个工作线程和1000个IO线程
 可配置最大线程数
 ```
 static void ThreadMethod(object obj) //必须带有object参数
 {
     Console.WriteLine("做点什么");
 }

 static void main()
 {
     ThreadPool.QueueUserWorkItem(ThreadMethod,34);//可在这里传参
 }
 ```
 
 ## Task 任务
 任务开启
 ```
static void ThreadMethod()
{
    int? id = Task.CurrentId; //可通过Task.CUrrentId获取当前任务id
    Console.WriteLine("做点什么");
}

static void main()
{
    //通过Task类创建
    Task t = new Task(ThreadMethod);

    //通过TaskFactory类创建
    TaskFactory fac = new TaskFactory();
    Task tt = fac.StartNew(ThreadMethod);
}
 ```
 
 ## 连续任务
 当任务1需要等待任务2完成后才能开始时，可以使用连续任务
 ```
 static void ThreadMethod_1()
 {
     Console.WriteLine("做点什么");
 }
 static void ThreadMethod_2(Task t) //此处t为上一个任务
 {
     Console.WriteLine("做点什么");
 }

 static void main()
 {
     Task t1 = new Task(ThreadMethod_1);
     Task t2 = t1.ContinueWith(ThreadMethod_2);
     Task t3 = t1.ContinueWith(ThreadMethod_2);
     Task t4 = t2.ContinueWith(ThreadMethod_2);
 }
 ```
 #### 连续任务的重载
 ```
 static void main()
 {
     Task t1 = new Task(ThreadMethod_1);
     Task t2 = t1.ContinueWith(ThreadMethod_2, TaaskContinuationOptions.NotOnFaulted);  //未抛出异常时才执行
     Task t3 = t1.ContinueWith(ThreadMethod_2);
     Task t4 = t2.ContinueWith(ThreadMethod_2);
 }
 ```
 * NotOnFaulted | OnlyOnFaulted 上个任务执行[未抛出|抛出]异常时才执行
 * NotOnCanceled | OnlyOnCanceled 上个任务执行[未取消|取消]异常时才执行
 * NotOnRanToCompletion | OnlyOnRanToCompletion 上个任务执行[未完成|完成]异常时才执行，NotOnRanToCompletion => NotOnFaulted || NotOnCanceled

 ## 任务的其它控制
 * Task.WaitAll(task1,task2)    等1和2都执行完
 * Task.WaitAny(task1,task2)    等1或2执行完
 
 ## 任务的层次结构
 如果在一个任务中启动新任务，则构建为父子任务，当子任务还没有完成时，父任务即使已经执行完也会处于WaitingForChildrenToComplete状态，当子任务执行完毕，父任务会改为RunToCompletion
 
 ## 线程争用
 当多个线程同时对一个引用类型进行操作时，会出现线程争用情况
 #### 出现原理
 ```
 class MyThread
 {
     private int id = 5;

     public void ThreadMethod()
     {
         id++;
         if (id == 5)
         {
             Console.WriteLine("发生线程争用"); //有一个线程执行id = 5时，另一个线程执行if判断
         }
         id = 5;
     }
 }
 ```
 ```
 static void ChangeState(object obj)
 {
     MyThread m = obj as MyThread;
     while (true)
     {
         m.ThreadMethod();
     }
 }

 static void main()
 {
     MyThread m = new MyThread();
     Thread t = new Thread(ChangeState);
     new Thread(ChangeState).Start(m);
     t.Start(m);
 }
 ```
  #### 解决方案
 添加线程锁
 ```
 static void ChangeState(object obj)
 {
     MyThread m = obj as MyThread;
     while (true)
     {
         lock (m)  //锁定引用类型对象m
         {
             m.ThreadMethod();
         }
     }
 }

 static void main()
 {
     MyThread m = new MyThread();
     Thread t = new Thread(ChangeState);
     new Thread(ChangeState).Start(m);
     t.Start(m);
 }
 ```
 
 ## 死锁
 ```
 //ThreadMethod_1 抢到m1锁，ThreadMethod_2抢到m2锁，导致无人可以继续执行，从而死锁
 static void ThreadMethod_1()
 {
     while (true){
         lock (m1)
         {
             lock (m2)
             {
                 Console.WriteLine("做点什么");
             }
         }
     }
 }
 
 static void ThreadMethod_2(Task t) //此处t为上一个任务
 {
     while (true)
     {
         lock (m2)
         {
             lock (m1)
             {
                 Console.WriteLine("做点什么");
             }
         }
     }
 }

 static void main()
 {
     Thread t1 = new Thread(ThreadMethod_1);
     t1.Start();
     Thread t2 = new Thread(ThreadMethod_2);
     t2.Start();
 }
 ```
 #### 解决方案
 添加锁时，所有锁按同一顺序添加
 
 
 
 # .net framwork
 * 提供一个一致的面向对象的编程环境
 * 提供一个将软件部署和版本控制冲突最小化的执行环境
 * 提供一个可提高代码安全性的执行环境
 * 提供一个可消除脚本环境或解释环境的性能问题的代码执行环境
 * 按照工业标准生成所有通信，以确保与其他代码集成
 
 基于操作系统及硬件，以及通用语言运行时
 ## 托管进程
 * 运行库
 * 类库
 * 自定义对象库
 
 ## 非托管进程
 * 信息服务
 * ASP.NET 运行库
 * 应用程序
 
 ## Common Language Runtime CLR 通用语言运行时（公共语言运行时）
 * 安全性，对不同的组件有不同的访问级别，例如注册表|普通文件
 * 访问安全，访问网络的安全性
 * CTS，常规类型系统，严格的类型验证
 * 消除常见的软件问题，提供自动的内存管理系统，例如内存泄漏
 * 提高开发效率，兼容符合CLR的其他语言开发的代码，并兼容老版程序
 * 增强性能，根据cpu等的硬件优化执行性能
 * 宿主应用，可以宿主在IIS等
 
 基于CLR开发的代码被称为托管代码
 
 ### C#的执行
 * 选择编译器
 * 将代码编译为托管模块，托管模块包括PE32或PE32+头、CLR头，元数据及IL代码
 * 将IL编译为本机代码（本机CPU指令）
 * 运行代码

 注：\
 PE32或PE32+头：标准的Win PE文件头，标识系统版本及文件类型\
 CLR头：包含托管模块的信息，包括模块入口文件、执行方法\
 元数据：元数据表，包含源代码定义的类型和成员或引用的类型或成员\
 IL代码：又称MSIL(Microsoft Intermediate Language)\

 ### 编译过程
 * JIT尝试将IL编译为本机CPU指令
 * 发现引用类型，CLR确定包括这些类型的程序集已经被加载
 * 利用程序集内元数据，将类型有关的信息提取到内存堆中
 * CLR确定引用类型全部创建且编译完成，允许线程执行本机CPU指令
 * 随程序执行，JIT对堆中引用对象的方法、字段等继续进行同步编译
 
 ### 自动内存管理
 * 分配内存
 * 释放内存
 * 级别和性能  内存分为0，1，2代
 * 为非托管资源释放内存
 >> 深入学习：内存管理与GC算法




 # GC
 * 一般在方法结束时执行
 * 异步执行
 * 运行时会暂停其它线程
 * 可能会移动对象并更新引用
 * 可通过调用System.GC.Collect 执行，但不建议使用

 ## 原理
 * 构造可达对象的映射
 * 检查所有不可达对象的析构器，将其推入特殊队列中执行
 * 回收其它不可达对象，将堆中可达对象向下移动并更新引用，施放堆顶的内存
 * 恢复其它线程的运行
 * 在独立线程中执行特殊队列

 ## 析构器
 引用对象在GC时必定会执行的函数
 * 非必要情况下不使用析构器
 * 析构器不互相依赖，尽量不调用其它对象，因为他们可能已经被GC回收，GC回收的顺序是不能保证的

 ## 资源清理方法
 当有些资源希望在使用完毕后清理时可以使用
 
 ### 逻辑上的实现
 继承IDisposable接口并实现Dispose方法
 ```
 class Person : IDisposable{
    public void Dispose(){

    }
 }
 ```
 ```
 Person p = new Person();
 try
 {
     //doSomething
 }catch(Exception e)
 {
     Console.WriteLine(e);
 }
 finally
 {
     p.Dispose();
 }
 ```

 ### 推荐的实现方法
 using() 可以将实现IDisposable的引用对象在作用域结束后释放
 ```
 using(Person p = new Person())
 {
     //doSomething
 }
 ```

 ### 优化Dispose所产生的GC问题
 当清理方法被调用后，GC在启用时仍会重复执行类的清理动作，包括执行析构方法，因此在调用清理方法后可调用GC.SuppressFinalize方法以让GC后续处理之间跳过该对象
 ```
 class Person : IDisposable
 {
     private Boolean disposed = false;

     public void Dispose()
     {
         if (!disposed)
         {
             disposed = true;
             Console.WriteLine("对象已经被清理");
             Console.WriteLine("当GC启动时会绕过此对象");
             GC.SuppressFinalize(this);
         }
     }

     ~Person()
     {
         Console.WriteLine("GC启动析构器");
         this.Dispose();
     }
 }
 ```



 # 版本号管理
 一般由major、minor、build、revision构成
 * major 主版本号
 * minor 次版本号
 * build 内部版本号，随着每次打包程序集递增
 * revision 修订号，如同版本需要修正某些bug时应递增

 # 程序签名

 ## 签名过程
 将公钥嵌入元数据中\
 对PE文件进行哈希处理\
 对PE哈希值使用私钥签名获得RSA签名\
 将RSA签名嵌入CLR头中\

 ## 意义
 程序签名可以防止程序未被篡改

 ## 延时签名（部分签名）
 只使用公钥生成程序集