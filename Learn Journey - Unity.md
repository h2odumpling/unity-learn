# Navigation
导航路径因先设置Navigation Static属性，后在Navigation-Object窗口中为其关联对应的区域。
>> 深入学习：导航算法



# Animator
模型（fbx）文件可以包含多个动画切片，可以通过Animator Controller控制各个切片的切换，具体方法为在Animator右侧创建pram，并在右侧Layer窗口中制作关联，连接箭头可以点击并关联相应的pram进行控制。
>> 深入学习：如何改变默认动画
>> 深入学习：尝试自己制作游戏相关的人物动画



# Animation
类似于flash的动画

* Play   不带任何混合的动画
* PlayQueued    在前一个动画播放完成后播放下一个
* CrossFade    淡入淡出有过渡的动画，常用于动物动画



# Camera
* Field of view 摄像机镜头的数值，数值越大镜头越远，常做瞄准镜等视野缩放功能


# UGUI
## 对比GUI的优势
* Rect Transform、Layout Group 提供的布局系统
* 将点击等事件进行封装，统一检测
* 执行效能提高

RaycastTarget   是否可以交互，开启会消耗性能，应只在需要交互的ui上开启
Interatable   是否可用，应该用于可变性调节某些选项，比如多级控制按钮

### Text
### Image
### Toggle    单、复选
### Button
### DropDown

### Slider    滑动条，可做血条、进度条
* Handle    标识滚动条的位置的子物体，做血条进度条时可以隐藏或做成特效

### ScrollView    滚动窗口
* Content   所有物体都在内
* MovementType  Unrestricted不受限（可制作无限滚），Elastic弹性，Clamped无弹性
* Inertia   拖动结束后仍有惯性
* Scroll Sensitivity    滚轮灵敏度
>> 深入学习：测试On Value Changed(Vector2)的具体返回，x|y 0-1

### InputField    输入框
* Content Type  输入内容类型
* Line Type   SingleLine 单行、MultiLineSubmit回车键提交、MultiLineNewLine回车键换行
* Caret Blink Rate    光标闪烁频率
* Caret Width   光标宽度
* Selection Color   选择部分光标颜色设置
* Hide Mobile Input   隐藏移动输入（仅限IOS）

>> 深入学习：TMP text



# GUI
## 特性
* GUI脚本必须定义在脚本文件OnGUI事件函数中
* GUI每一帧都会调用

## 基本控件
* Label   文本、图片
* TextField   单行文本
* TextArea    多行文本
* PassWordField
* Button
* ToolBar   创建工具栏
* ToolTip   显示提示信息
* Toggle
* Box   图形框
* ScrollView
* Color   影响GUI的背景色和字体色
* Slider    创建滚动条，GUI.HorizontalSlider水平滚动条、GUI.VerticalSlider垂直滚动条
* DragWindow    屏幕内可拖拽窗口
* Window    窗口组件，可在其中添加任意组件

## GUILayout
相当于rect一块区域后的自动布局，可以将GUI进行区域划分，简单的使用Layout自动布局节省布局时间
>> 深入学习：多练习GUI布局


# Grid Layout Group   排版布局组件
* Cell Size   子物体大小
* Spacing   子物体间隔



# Unity 脚本
脚本是附加在游戏物体伤用于定义游戏对象行为的指令代码
* 文件名与类名必须一致
* MonoBehaviour 附加到游戏物体上的脚本必须继承，其它脚本无需继承
* 脚本在物体上时会创建一个对象，而物体GameObject实则是存储了这些对象的引用的一个集合，实际通过引用访问和修改对象

## 单帧调试
vs中开启调试->unity中开启场景->vs中设置断点->unity中单帧运行->在vs即时中调试

## 编译过程
源代码-(CLS)->中间语言[DLL]-(Mono Runtime)->机器码
Mono Runtime Unity重写了Common Runtime而变成了自己的公共语言运行时，会把代码编译成不同语言的机器码执行

## Unity脚本和C#普通类的区别
Unity脚本中一般只使用字段和方法
C#普通类一般至少有字段、属性、构造函数和方法
* 为什么不使用属性  在不修改unity底层的情况下，属性无法在编辑器内展示
* 为什么不使用构造方法  GameObject上绑定对象的构造方法实际是在子线程中被调用的，而Unity提供的许多方法都是在其他线程或主线程提供的，不能跨线程调用，一般使用Awake和Start代替

## 修改Unity脚本模板
修改Editor/Data/Resources/ScriptTempletes/81-C# Script-NewBehaviourScript.cs.txt 文件

## 访问修饰符
public 除公开外，在编辑器内可见可改，可通过设置[HideInInspector]特性使其在编译器内不可见
private 只在类中可以访问，且在编辑器内不可见，可通过设置[SerialsizeField]特性使其在编译器内可见

### 访问修饰符相关的特性
[SerialsizeField]
[HideInInspector]
[Range(x,y)]  使一个字段在编译器内被限制上下限

## Unity脚本生命周期|必然事件|消息 Message
* 一个GameObject从开始唤醒到销毁的过程
* 在GameObject的不同时间点被调用
* 如果在GameObject内没有相应方法则不会被调用，因此要删除不使用的方法，避免方法在内存中形成栈针，影响性能

### Reset()
在编辑器内使用reset时调用，在游戏中不会被调用
### Awake()
在游戏物体创建时被调用1次，Unity会先执行所有物体的Awake方法，后执行start方法，一般用于初始化
### Enable()
在游戏物体启用时，若脚本被启用则调用，可调用多次
### Start()
在GameObject被创建后脚本启用时调用1次，永远晚于Awake被调用，一般用于初始化
### OnMouseDown|...
当鼠标对物体进行某些操作时调用
* 需要在鼠标单GUIElement或物体碰撞器时才会执行
### FixedUpdate
物理更新 在每个固定时间后执行，默认为0.02s，一般用于物理动作相关的处理
### Update
渲染更新 在每个渲染帧调用，收到渲染性能的影响
### LaterUpdate
在每个渲染帧和Update之后调用，
>> 深入学习：laterUpdate 是在所有物体的Update之后调用还是在当前物体Update之后调用
...

# 常用API类

## Object
FindObjectOfType<Component>()   根据类型查找对应类型的对象
FindObjectsOfType<Component>()  根据类型查找对应类型的对象数组
Destory(obj,secends)  删除游戏对象或组件或资源，延时x秒
DontDestoryOnload(GameObject)   加载新场景时，使目标对象不会被自动销毁
Instantiate(GameObject,Vector3,rotation)    克隆物体到指定位置指定角度，返回克隆对象

## GameObject
场景内所有物体都是GameObject
* activeSelf  游戏对象的激活状态
* activeInHierarchy   游戏对象在场景的激活状态，在父物体禁用的情况下，子物体已激活但在场景内仍非激活状态
* AddComponent<Component>()   添加组件，添加组件需要在GameObject添加
* GameObject.Find("name")   通过对象名称查找，但很影响性能，因此不建议使用
* FindGameObjectsWithTag("tag")   通过标签获取游戏物体的数组
* FindWithTage("tag")   通过标签获取游戏物体

## Component
getComponent T  按T获取物体的一个组件
getComponents T   按T获取物体的所有组件
getComponentInChildren T | getComponentsInChildren T  按深度获取自身或子物体的组件 
getComponentInParent T 按深度获取自身或父物体的组件

由于挂载在GameObject的组件都继承于Component类，都可以通过GetComponent的方法获取GameObject上的其它组件
子类：
### Transform
循环GameObject的Transform组件，可以得到下一级的子物体的Transform组件
编辑器里显示的全是物体的local属性
```
foreach(Transform child in this.Transform){
    child
}
```
* root 获取根物体Transform组件
* parent 获取父物体Transform组件
* setParent(tf,isWorldSpace) 设置父物体为tf，isWorldSpace表示位置如何根据父物体改变，true时为世界坐标不变而改变自身坐标相对于父物体的坐标值，false时为将现在的坐标视为自身对父物体的坐标值，设置为null则脱离父子关系
* DispatchChildren  解散所有子物体（非删除）
* GetSiblingIndex   获取该对象的同级索引
* SetAsFirstSibling   设置为兄弟索引第一
* SetAsLastSibling   设置为兄弟索引最后
* SetSiblingIndex   按索引设置为兄弟索引的第几个


* position  世界坐标的位置
* localPosition 相对于父物体的坐标位置
* rotation  相对于世界的旋转
* localRotation  相对于父物体的旋转
* localScale  相对于父物体的缩放比例，即父121，子121，子实际为141
* lossyScale  物体与模型的缩放比例，实际即为自身的localScale乘父物体的localScale 只读属性
方法
* forward   自身坐标系向前的单位向量
* right     自身坐标系向右的单位向量
* up    自身坐标系向上的单位向量
* eulerAngles   物体的欧拉角
* localEulerAngles   物体相对父级的欧拉角

默认为朝自身坐标系方法，可添加Space.World参数表示向世界坐标系的运动方法，或传入其他变换组件表示使用根据别的物体移动
* Translate 移动
* Rotate  旋转
* RotateAround (point,Vector3,n°) 围绕某点绕Vector3的轴旋转n°
* LookAt    注视旋转，让物体的向前向量指向target的位置
* TransformPoint(Vector3)   返回从自身轴心点按自身坐标系移动Vector3后的世界坐标系

* Find("name")  通过游戏对象名称查找子对象

### RigidBody
### ParticleSystem
### Behaviour
子类： 
#### MonoBehaviour
* InvokeRepeating(methodName, delayTime, repeatTime)    重复调用方法，延迟多久，每多少时间重复
* cancelInvoke(methodName)  取消调用
* Invoke(methodName, delayTime)     延迟执行方法

MonoBehaviour 相关的特性
* RequireComponent(typeof(monoClassName))   实现在挂载该类时可以依赖挂载其他类

### Collider

## Texture
## Mesh
## Material



# Time
* time 从游戏开始到现在的时间 float类型
* unscaledTime 从游戏开始到现在的时间，不受timeScale的影响
* deltaTime 完成最后一帧消耗的时间
* timeScale 时间的缩放，默认为1，0即表示游戏暂停，时间较小可以表示慢动作，FixedUpdate受到此影响，而Update只在渲染场景时执行，因此不受此影响
* unscaledDeltaTime 完成最后一帧消耗的时间，但不受timeScale的影响



# Input
* GetMouseButton(int ButtonNum)    鼠标*键在这帧保持按下
* GetMouseButtonDown(int ButtonNum)    鼠标*键在这帧按下
* GetMouseButtonUp(int ButtonNum)    鼠标*键在这帧抬起
* GetKey(int KeyBoardNum)    键盘*键在这帧保持按下
* GetKeyDown(int KeyBoardNum)    键盘*键在这帧按下
* GetKeyUp(int KeyBoardNum)    键盘*键在这帧抬起
* GetButton(string VirtualButtonName)   虚拟按键在这帧保持按下
* GetButtonDown(string VirtualButtonName)   虚拟按键在这帧按下
* GetButtonUp(string VirtualButtonName)   虚拟按键在这帧抬起
* GetAxis(string VirtualButtonName)     获取虚拟按键现在返回的值
* GetAxisRaw(string VirtualButtonName)     获取虚拟按键现在返回的值(0|1|-1)(无视Gravity,及Sensitivity的影响)

## InputManager
Unity提供的虚拟按键功能，主要用于为用户提供自定义按键的功能
* Edit->ProjectSetting->InputManager
* Name
* DescriptionName
* Native Button|Alt Native Button   反向按钮即按下返回0~-1
* Positive Button|Alt Positive Button   正向按钮即按下返回0~1
* Gravity   按键抬起后的归0速度
* Sensitivity   按键按下后的归1速度
* 可以设置多个相同名称的VirtualButton这样但按键就可以提供更多的按钮绑定



# Mathf
* Lerp(start, end, rate)    返回(end - start)*rate + start  常用于先快后慢或先慢后快的平滑过渡
```
InvokeRepeating("change",0,0.02);
```
```
private void change(){
    camera.fieldOfView = Lerp(camera.fieldOfView, 60, .1f);
    if(60 - camera.fieldOfView < 0.05){     //使用Lerp永远不会抵达终点
        camera.fieldOfView = 60;
        cancelInvoke("change")
    }
}
```
* float Repeat(num,limit)   根据num返回0 - limit-1的值 num%limit
* Repeat(float n,float max)   与%一样，但不会出现负数
* PingPong
* Pow(num,^n)   返回num的n次方
* float Sqrt(num)   返回num的开方
* PI   圆周率(float)
* Deg2Rad   角度转换为弧度(float)
* Rad2Deg   弧度转化为角度(float)
* Sin(Rad)   正弦
* Cos(Rad)   余弦
* Tan(Rad)   正切



# Vector3
Unity中的positon是以世界原点为起点的向量
https://docs.unity.cn/cn/current/ScriptReference/Vector3.html

## 向量的基本概念
* 有大小和方向的物理量
* (x,y,z)|(x,y)
* 模长，即向量的长度    Mathf.Sqrt(Mathf.Pow(x,2)+Mathf.Pow(y,2)+Mathf.Pow(z,2))
* 方向|归一化|单位向量|标准化向量     方向与原向量一致，但模长为1的向量，即原向量/原模长
* 向量相加  向量起点zero重叠，以两个向量的方向和模长作平行四边形，该平行四边形经过zero的对角线即为新向量
* 向量相减  向量起点zero重叠，a-b 相减后的向量起点为zero，方向为b的终点指向a的终点，模长为b的终点到a的终点
* 点乘|点积|内积    x1x2+y1y2+z1z2  
* 叉乘|叉积|外积    (y1z2-y2z1,z1x2-z2x1,x1y2-x2y1)

### 点乘|点积|内积
* x1x2+y1y2+z1z2    各分量的乘积和
* 几何意义：等于V1V2的模长的积 * cos(n)   |a|·|b|*cos(n)    -1< cos(n) < 1
* 一般使用单位向量进行点乘，此时点乘结果即为cos值
* 只能返回小于180的角
常用应用
求玩家是否在敌人视线的60°夹角内，此时一般使用enemy.transform.forward与|(player.transform.position - enemy.transform.position)|点乘求反余弦
```
Vector3 e2P = player.transform.position - enemy.transform.position;
float dot = Vector3.Dot(enemy.transform.forward, e2p.normailized);
//float deg = Mathf.Acos(dot) * Rad2Deg;
//float rad = Mathf.Acos(dot)
if(rad > 0.5f){      //由于60度的cos值为0.5f，且机器做反余弦运输消耗性能，因此一般使用cos值直接判断
}
```

### 叉乘|叉积|外积
* (y1z2-y2z1, z1x2-z2x1, x1y2-x2y1)
* 几何意义：返回一个垂直于V1/V2所在平面的向量，模长 等于V1V2的模长的积 * sin(n)    |a|* |b| *sin(n)   0< sin(n) < 1
* 可以通过y值判断两个向量的顺逆时针关系，y大于0时V1V2夹角小于180度，V1在V2的左边，反之夹角大于180度，V1在V2右边
常用应用
求玩家在敌人的左边还是右边
```
Vector3 e2P = player.transform.position - enemy.transform.position;
float dot =  Vector3.Dot(enemy.transform.forward, e2p.normailized);
//float deg = Mathf.Acos(dot) * Rad2Deg;
Vector3 cross = Vector3.Cross(enemy.transform.forward, e2p.normailized);
if(cross.y >0){
    //玩家在敌人右边
}
if(cross.y <0){
    //玩家在敌人左边
}
if(cross.y =0){
    //玩家和敌人在正前方或正后方
}
if(dot >0){
    //玩家在敌人前方
}
if(dot <0){
    //玩家在敌人后方
}
```

### 静态变量
* forward   (0,0,1)
* back  (0,0,-1)
* up    (0,1,0)
* down  (0,-1,0)
* right (1,0,0)
* left  (-1,0,0)
* zero  (0,0,0)
* one   (1,1,1)

### 实例变量
* magnitude     返回模长
* sqrMagnitude      模长的平方，可以用于比较向量模长(因为平方根计算消耗性能，因此如果可以用sqrMagnitude代替的场合可以提高效率)
* normalized    返回该向量的单位向量
* this[0|1|2]   使用索引器访问x,y,z    

### 静态方法
* float Distance(V1,V2)     n1与n2的距离，即两向量相减后的模长
* Vector3 Normalize(V1)   返回V1的单位向量，不设置V1
* float Dot(V1,V2)    V1V2的点乘
* Vector3 Cross(V1,V2)      V1V2的叉乘
* float Angle(V1,V2)      返回V1V2的角度，使用点乘实现
* Vector3 ClampMagnitude(V1,radius)     返回一个方向一致模长不超过radius的最大向量，可以将物体行动限制在一个圈内
* Vector3 Max(V1,V2)    返回V1V2内最大值组成的向量 (V1.x>V2.x ? V1.x : V2.x, V1.y>V2.y ? V1.y : V2.y, V1.z>V2.z ? V1.z : V2.z)
* Vector3 Min(V1,V2)    返回V1V2内最小值组成的向量
* void OrthoNormalize(ref V1,ref V2,ref V3)    把V1标准化并且把V2,V3设置为垂直于V1的标准化向量
* Vector3 Project(V1,V2)    将V1投影到V2的方向上，返回投影的向量
* Vector3 ProjectOnPlane(V1,V2)    将V1投影到V2垂直的平面，返回投影的向量
* Vector3 Reflect(V1,V2)    V1以V2为法线进行反射，即V1向量在V2垂直的平面上的反射向量，类似入射光反射光
* Vector3 Lerp(V1,V2,rate)      返回V1,V2根据rate的插值位置，rate被限制在0~1
* Vector3 LerpUnClamped(V1,V2,rate)     返回V1,V2根据rate的插值位置，rate无限制，可配合AnimationCurve进行物体移动速度的控制
```
t += Time.deltaTime;
v1.position = Vector3.LerpUnclamped(v1OriPosition, v2.position, curve.Evaluate(t));     //此时1s即可完成运动
```

### 实例方法
* Normalize()   将自身设置为自身的单位向量



# AnimationCurve
动画曲线
* 可在面板中设置自定义的值变换曲线

## 实例方法
* Evaluate(float)   根据float返回动画曲线中的值



# 角度，弧度
* 一个圆为360角度
* 一个圆为2Π弧度 1弧度即为弧长为半径的角

## 相关Mathf函数
* PI   圆周率(float)
* Deg2Rad   角度转换为弧度(float)
* Rad2Deg   弧度转化为角度(float)



# 三角函数|反三角函数

## 三角函数
已知边角求边

### 相关Mathf函数
* Sin(Rad)   正弦
* Cos(Rad)   余弦
* Tan(Rad)   正切

## 反三角函数
已知边边求角

### 相关Mathf函数
* Asin()   反正弦
* Acos(|V1|*|V2|)   反余弦
* Atan()   反正切



# 欧拉角|四元数
用于表示物体的旋转
## 欧拉角
* 使用三个角度保存方位
* x,z沿自身坐标系，y沿世界坐标系旋转
* Vector3 transform.EulerAngles
### 欧拉角的优点
* 仅用3个数字就可以表示方位，占用空间小
* 单位为沿坐标旋转的角度，符合思考模式
* 任意3个数字都可以表示一个欧拉角，不存在不合理的数字
### 欧拉角的缺点
* 表达方式不唯一，同一个方位有多个欧拉角可以描述，因此无法判断多个欧拉角是否相同
* 万向节死锁，数学上欧拉角由于单轴旋转会带动其他轴旋转，所以会导致死锁，在Unity内表示为当x旋转+-90度时，自身的y和z将重合，导致失去一个自由度
### Unity对于欧拉角的限制
* x轴范围在-90~90
* y，z轴范围在0~360
* 在触发万向节死锁时，沿y完成所有旋转，z为0
### 欧拉角在Unity中的调节
```
Vector eulerAngles = transform.eulerAngles;
eulerAngles += new Vector3(0,0,1);
```
### 相关transform方法
* eulerAngles   物体的欧拉角
* localEulerAngles   物体相对父级的欧拉角

## 四元数|Quaternion
* 由一个三维向量(X,Y,Z)及一个标量W组成
* X,Y,Z,W 取值范围为-1~1
* 旋转轴为V，旋转弧度为θ，则 (X,Y,Z) = (sin(θ/2) *V.x, sin(θ/2) *V.y, sin(θ/2) *V.z)   W = cos(θ/2)
* 四元数和四元数相乘，表示组合旋转
* 四元数和向量相乘，表示向量按四元数指示的旋转角度旋转

### 四元数的优点
* 不存在万向节死锁
### 四元数的缺点
* 难以使用，不能单独修改某个值
* 存在不合法的四元数
### 四元数在Unity中的调节
```
Vector3 axis = Vector3.up;
float rad = 50 * Mathf.Deg2Rad;

axis.x = Mathf.Sin(rad / 2) * axis.x;
axis.y = Mathf.Sin(rad / 2) * axis.y;
axis.z = Mathf.Sin(rad / 2) * axis.z;
float w = Mathf.Cos(rad / 2);

Quaternion qt = new Quaternion(axis.x, axis.y, axis.z, w);
```
等效于
```
transform.rotation = Quaternion.Euler(0, 50, 0);
```
组合旋转
```
transform.rotation *= Quaternion.Euler(0, 0, 1);
```
等效于
```
transform.Rotate(0, 0, 1);      //内部实现即是四元素的组合旋转
```
### 相关transform方法
* Quaternion rotation   获取物体旋转的四元数
### Quaternion
#### 静态变量
* identity      返回世界坐标系的角度，表示不旋转
#### 静态方法
* Quaternion Euler(x,y,z)(Vector3)   将欧拉角转化为四元数
* Quaternion AngleAxis(float angle, Vector3)    轴角旋转，常用于非世界坐标系的坐标系向量的轴
* Quaternion LookRotation(Vector3)     返回使物体的z轴的方向与传入向量相同时的旋转角度，如果需要注视旋转，则传入向量为目标位置-当前位置，常配合Lerp函数做慢速旋转，而transform.LookAt 无法提供这一功能
* Quaternion FromToRotation(V1,V2)    返回使V1方向与V2方向相同时的旋转角度
* Quaternion Lerp(Q1,Q2,rate)     插值旋转，rate被限制于0~1
* Quaternion LerpUnClamped(Q1,Q2,rate)    插值旋转，rate无限制
* Quaternion RotateTowards(Q1,Q2,rate)    匀速旋转
* float Angle(Q1,Q2)    返回两个四元数相差角度，常用于判断lerp旋转是否到位
#### 实例方法
* Vector3 eulerAngles   返回四元素的欧拉角
### 四元数在Unity中的应用
目标右前方30°距离30m处
```
Vector3 newPosition = transform.position + Quaternion.Euler(0, 30, 0) * transform.rotation * new Vector3(0, 0, 30);
Vector3 newPosition = transform.TransformPoint(Quaternion.Euler(0, 30, 0) * Vector3.forward * 30);
```
检测爆炸的受力范围(仅使用切点检测)
```
float personRed = 0.5f;
float effectRed = 10;

Vector3 P2B = v2.position - v1.position;

if (P2B.magnitude - personRed < effectRed)  //最短距离受到冲击
{
    float angle = Mathf.Acos(personRed / P2B.magnitude) * Mathf.Rad2Deg;

    Vector3 redVector = P2B.normalized * personRed;

    Vector3 check_right = Quaternion.Euler(0, angle, 0) * redVector;
    Vector3 right_position = v1.TransformPoint(check_right);

    Vector3 check_left = Quaternion.Euler(0, -angle, 0) * redVector;
    Vector3 left_position = v1.TransformPoint(check_left);

    Debug.DrawLine(v2.position, right_position, Color.red);
    Debug.DrawLine(v2.position, left_position, Color.red);

}
```

>> 深入学习：使用矩阵表示方位



# 贝塞尔曲线
任意几点可确定一条平滑曲线



# 参数方程
使用参数返回点坐标
* 圆
* 椭圆
* 抛物线
* 双曲线



# 坐标系

## World Space
世界坐标系，在场景中表示每个游戏对象的位置和方向

### 有关的transform方法
* InverseTransformPoint  转换点，受变换组件的位置/旋转/缩放影响
* InverseTransformDirection  转换方向，受变换组件的旋转影响
* InverseTransformVector     转换变量，受变换组件的旋转和缩放影响

## Local Space
物体局部坐标系，表示物体间相对位置和方向

### 有关的transform方法
* TransformPoint  转换点，受变换组件的位置/旋转/缩放影响
* TransformDirection  转换方向，受变换组件的旋转影响
* TransformVector     转换变量，受变换组件的旋转和缩放影响

# Screen Space
* 屏幕坐标系
* 原点在屏幕左下角
* 以像素为单位
* 表示物体在屏幕中的位置
* 右上为(Screen.width, Screen.height)
* Z为物体到相机的距离，为了将世界坐标转换为屏幕坐标时不丢失信息而保存

## 有关的camera方法
* WorldToScreenPoint    将点的世界坐标转换为屏幕坐标
* ScreenToWorldPoint    将点的屏幕坐标转换为世界坐标

# Viewport Space
* 视口坐标系
* 屏幕左下角为(0,0)，右上角为(1,1)，右上角为屏幕宽高的比例

## 有关的camera方法
* WorldToViewportPoint    将点的世界坐标转换为视口坐标
* ViewportToWorldPoint    将点的视口坐标转换为世界坐标



# Ridibody 与 Collider

## Ridibody
* Mass  质量
* Drag  阻力，通常砖头为0.001，羽毛为10
* AngularDrag  角阻力，当旋转物体时的阻力
* Use Gravity  是否使用重力
* Is Kinematic  运动学，不受物理引擎控制
* Interpolate  缓解刚体运动时的抖动，一般由于摩擦的原因产生
None  不应用插值
Interpolate  基于上一帧的变换来平滑本帧变换
Extrapolate  基于下一帧的预估变换来平滑本帧变换
* Collison Detection  快速移动的物体可能会发生穿透，可以改变检测频率来提高检测成功率，但对性能影响较大
Discrete  不连续检测，适用于普通碰撞
Continuous  连续碰撞检测
Continuous Dynamic  连续动态碰撞检测，适用高速物体
* Constraints 对刚体的运动约束，冻结沿世界某轴的移动或旋转

刚体在无运动时会休眠，不会检测其碰撞

## Collider
让物体有碰撞边界
* Cube Collider  最节约性能的碰撞器
* Mesh Collider  需要勾选Convex将网格合并优化

* Is Trigger   是否为触发器

* Material 物理材质

### Physic Material
* Dynamic Friction  动态摩擦力
* Static Friction   静态摩擦力
* Bounciness    弹力，1表示弹力无损耗
* Fricton Combine   摩擦力合并方式
* Bounce Combine    弹力合并方式

处于玩家可移动范围内的物体碰撞物体应该加碰撞器

## 碰撞
### 碰撞的产生条件
* 两物体具有碰撞器组件
* 运动的物体具有刚体组件

### 执行的生命周期
OnCollisionEnter(Collision colOther)    当碰撞开始时
OnCollisionStay(Collision colOther)     当碰撞进行中
OnCollisionExit(Collision colOther)     两者接触的最后一帧

### Collistion
contacts   接触点数组
contacts[index].point   接触点坐标
contacts[index].normal   接触面法线

## 触发
触发产生的条件
* 其中之一具有刚体
* 其中之一勾选触发器

执行的生命周期
OnTriggerEnter(Collider colOther)    当碰撞开始时
OnTriggerStay(Collider colOther)     当碰撞进行中
OnTriggerExit(Collider colOther)     两者接触的最后一帧



# Physics
物理方法
Raycast  射线检测



# Debug
* Log
* LogFormat
* DrawLin(Vector n1,Vector n2)