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