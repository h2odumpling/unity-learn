# Navigation
导航路径因先设置Navigation Static属性，后在Navigation-Object窗口中为其关联对应的区域。
>> 深入学习：导航算法



# Animator
模型（fbx）文件可以包含多个动画切片，可以通过Animator Controller控制各个切片的切换，具体方法为在Animator右侧创建pram，并在右侧Layer窗口中制作关联，连接箭头可以点击并关联相应的pram进行控制。
>> 深入学习：尝试自己制作游戏相关的人物动画



# UGUI
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
### FixedUpdate
在每个固定时间后执行，默认为0.02s，一般用于物理动作相关的处理
### Update()
在每个渲染帧调用，收到渲染性能的影响
### LaterUpdate()
在每个渲染帧和Update之后调用，
>> 深入学习：laterUpdate 是在所有物体的Update之后调用还是在当前物体Update之后调用
...
