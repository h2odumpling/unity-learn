# Shader
Shader是GPU流水线上一些可以高度编程的阶段，这些代码在GPU中运行，并控制流水线中的渲染细节\



# 渲染流水线

## 由CPU主导的阶段

### 应用阶段
主要内容是设置场景数据，剔除不可见物体，设置渲染状态\
* 把数据加载到显存中
一般情况下GPU对内存没有访问权力，且GPU访问显存速度更快，因此CPU一般会将数据从硬盘中读取至内存，后将内存中的数据存于显存，方便显卡后续操作\
* 设置渲染状态
* 调用DrawCall
CPU发起让GPU开始渲染模型的指令\
实际是CPU发送渲染指令给OpenGL或DirectX，通过后者传递至显卡驱动，再由显卡驱动翻译命令使GPU工作\
CPU与GPU的配合实际是通过一个命令缓冲区实现的，类似于队列，CPU将命令放入队列，GPU则负责读取\
DrawCall增多影响帧率的原因是CPU将大量时间耗费在提交DrawCall命令上，类似多文件复制导致的速度减慢是一样的\
减少DrawCall的方法有减少较小的网格结构或将其合并，减少材质的使用\

## 由GPU主导的阶段
又称为GPU流水线\

### 几何阶段
主要内容是将顶点坐标变换为屏幕坐标，输出顶点的深度值、着色等信息\
* Vertex Shader | 顶点着色器
可编程，CPU传入GPU的每个顶点都会调用一次顶点着色器，主要完成坐标变换和逐顶点光照工作\
坐标变换是指将顶点坐标从模型空间转换到齐次裁剪坐标，再经过硬件处理得到归一化的设备坐标\
* Tessellation Shader | 曲面部分着色器
可选着色器，用于细分图元\
* Geometry Shader | 几何着色器
可选着色器，用于执行逐图元着色或产生更多的图元\
* 裁剪
一个图元和摄像机有3种关系，完全在视野内、部分在视野内、完全在视野外\
裁剪用于处理部分在摄像机视野内的物体，将位于视野外的图元图元进行处理，舍弃在视野外的顶点，贴边形成新的顶点\
* 屏幕映射
将齐次裁剪坐标(x,y,z)转换至屏幕坐标系(x1,y1)\
具体坐标值和设置的屏幕分辨率有关\
z并未被舍弃，而是和屏幕坐标一起合称窗口坐标系传递至光栅化阶段\
z表示深度值，对后续的深度测试有重要的影响作用\

### 光栅化阶段
主要内容是生成屏幕像素并渲染最终图像\
* 三角形设置
计算三角形网格表示数据的过程，主要包括计算三角网格对像素的覆盖情况等\
* 三角形遍历
根据顶点信息对在三角形设置中覆盖的像素进行插值，形成一个片元序列，这个序列包括了屏幕坐标、深度信息、法线、纹理坐标等信息\
* 片元着色器
对片元序列中每个像素进行颜色有关的信息输出，输出一个或多个颜色，最重要的是纹理采样，通过插值得到对应的纹理坐标\
* 逐片元操作
通过模板测试、深度测试等对每个片元进行可见性测试，通过测试的会与颜色缓冲区的颜色进行混合\
混合操作需要确定物体是否透明，对于透明物体需要对颜色缓冲区的颜色及当前片元颜色进行混合，而不透明物体则可以使用片元颜色直接更新颜色缓冲区，类似于ps中图层的合并\



# OpenGL与DirectX
实际是提供了显卡驱动与应用程序直接的接口过渡，CPU发送渲染指令给OpenGL或DirectX，通过后者传递至显卡驱动，再由显卡驱动翻译命令使GPU工作\



# HLSL与GLSL与Cg
HLSL是DirectX提供的着色语言，控制了着色器的编译，因此用不同硬件也有一致的编译效果，但仅限于微软相关平台的使用\
GLSL是OpenGL提供的着色语言，较HLSL相比有广泛的跨平台性，但其跨平台基于硬件供应商对GLSL的实现，因此不同硬件会产生不同的编译效果\
Cg是由Nvidia提供的着色语言，与微软合作，真正意义上的跨平台，基于不同的平台生成不同的中间语言，语法与HLSL很像，可以无缝移植为HLSL，但无法发挥OpenGL最新的特性\

## Unity Shader中的语言选择
可以使用Unity Cg或GLSL，Unity Cg与Cg略有不同，类似于Mono基于CLR的移植\

   

# 顶点坐标变换过程

注：具体坐标系变换公式可查阅《Math：坐标系变换》\

## 模型空间
模型空间即为某个模型或对象自己的坐标系\

## 世界空间
世界空间即为Unity中的游戏空间\

## 观察空间
即摄像机空间\

## 裁剪空间
即齐次裁剪空间，这个过程中的变换矩阵一般称为投影矩阵或裁剪矩阵\

Aspect：摄像机纵横比（在屏幕上显示的宽高比），在Unity中可通过Camera.aspect得到，具体值为ViewPort Rect中W与H的比值\
Size：正交投影时视锥体竖直方向上高度的一半，在Unity中可通过设置Camera的Size得到\
透视投影的变换矩阵：\
M = [ cot(Fov/2)/Aspect 0          0                      0                     ] \
    | 0                 cot(Fov/2) 0                      0                     | \
    | 0                 0          -(Far+Near)/(Far-Near) -2Far*Near/(Far-Near) | \
    [ 0                 0          -1                     0                     ] \ 
透视投影的顶点变换：\
P = [ cot(Fov/2)/Aspect 0          0                      0                     ] [ x ]\
    | 0                 cot(Fov/2) 0                      0                     | [ y ]\
    | 0                 0          -(Far+Near)/(Far-Near) -2Far*Near/(Far-Near) | [ z ]\
    [ 0                 0          -1                     0                     ] [ 1 ]\ 
  = [ x*cot(Fov/2)/Aspect                            ] \
    | y*cot(Fov/2)                                   | \
    | -z(Far+Near)/(Far-Near) - 2Far*Near/(Far-Near) | \
    [ -z                                             ] \
此时P的顶点分量w为-z，且可通过-w<=x<=w,-w<=y<=w,-w<=z<=w判断顶点是否在视锥体内，不在则需要被裁剪\
正交投影的变换矩阵：\
M = [ 1/(Aspect*Size) 0      0             0                      ] \
    | 0               1/Size 0             0                      | \
    | 0               0      -2/(Far-Near) -(Far+Near)/(Far-Near) | \
    [ 0               0      0             1                      ] \ 
正交投影的顶点变换：
P = [ 1/(Aspect*Size) 0      0             0                      ] [ x ]\
    | 0               1/Size 0             0                      | | y |\
    | 0               0      -2/(Far-Near) -(Far+Near)/(Far-Near) | | z |\
    [ 0               0      0             1                      ] [ 1 ]\ 
  = [ x/Aspect*Size                          ] \
    | y/Size                                 | \
    | -2z/(Far-Near) - (Far+Near)/(Far-Near) | \
    [ 1                                      ] \

## 屏幕空间
将裁剪空间中得到的视锥体投影到屏幕空间，我们会在这里得到像素坐标\
先对透视投影进行进行标准齐次除法，又称为透视除法，即用齐次坐标的w分量分别除x、y、z分量，就可得到归一化的设备坐标，此时透视投影的裁剪空间会变换到一个立方体\
Px = clipx*pixelWidth/(2clipw)+pixelWidth/2
Py = clipy*pixelHeight/(2clipw)+picelHeight/2



# 法线变换
因为法线N垂直于切线T，因此TB·NB=0，而TB=M(A->B)TA，设NB=GNA，则M(A->B)TA·GNA=0，则TA(M(A->B)G)NA=0，则M(A->B)G=I时，上式成立，即G=(M(A->B)^T)^-1=(M(A->B)^-1)^T\
由此若M(A->B)是正交矩阵，则G=M(A->B)，而只使用旋转时，M(A->B)就是正交矩阵，而当包含统一缩放时，变换矩阵就是1/k*M(A->B)，其余情况需要求解逆转置矩阵\



# Unity Shader

## VS 扩展
* ShaderLabVS
UnityShader编程扩展，高亮代码等\
* Sublime
换行缩进插件\

## Shader结构
```
Shader "ShaderName"
{
  //定义shader的属性
  Properties {
    //声明一个color类型顶点属性
    _Color ("Color Tint", Color) = (1.0, 1.0, 1.0, 1.0)
  }
  //针对不同显卡进行渲染定义
  SubShader
  {

    Pass
    {
      CGPROGRAM
      //定义顶点着色器函数
      #pragma vertex vert
      //定义片元着色器函数
      #pragma fragment frag

      //加载UnityCg
      #include "UnityCg.cginc"

      //定义一个和属性中名称相同的变量，同步
      fixed4 _Color;

      struct a2v{
        //用顶点坐标填充vertex
        float4 vert : POSITION;
        //用法线方向填充normal
        float3 normal : NORMAL;
        //用模型第一套纹理填充texcoord
        float texcoord : TEXCOORD0;
      };

      struct v2f{
        //pos里包含了顶点在裁剪空间的位置信息
        float4 pos : SV_POSITION;
        //存储颜色信息
        float3 color : COLOR0;
      };

      v2f vert(a2v v){
        v2f o;
        o.pos = UnityObjectToClipPos (v.vert);
        o.color = v.normal * 0.5 + fixed3(0.5, 0.5, 0.5);
        return o;
      }

      //float4 vert(float4 v : POSITION) : SV_POSITION{
      //    return UnityObjectToClipPos(v);
      //}

      float4 frag(v2f o) : SV_TARGET{
        fixed3 c = o.color;
        c *= _Color.rgb;
        return fixed4(c, 1.0);
      }

      //float4 frag() : SV_TARGET{
      //    return fixed4(1.0, 1.0, 1.0, 1.0);
      //}

      ENDCG
    }
  }
}
```

## Shader中使用的数据结构
* float
32位浮点型，同c#\
* half
16位浮点型，精度范围在-60000~60000\
* fixed
11位浮点型，精度范围在-2.0~2.0

### 数据结构带来的差异
* PC等桌面型GPU，一般会无视数据结构直接按float进行计算\
* 移动平台的GPU，一般会按设置精度进行计算\
* fixed 实际只在较旧的移动端GPU上使用，现在大部分GPU把他等同于half\

## Shader Debug
在shader编码中进行debug的方法\

### 假彩色图像
把需要调试的变量设为0-1之间，然后把他们作为颜色输出，判断值是否正确\

## DirectX|OpenGl
DirectX的语法更加严格，因此最好用严格的语法结构进行Shader编写\

## Shader注意点
* DirectX的语法更加严格
最好用严格的语法结构进行Shader编写\
* 除以0的情况要避免出现
不同平台对除以零得到的值有可能不同，有些平台可以得到白色，有些平台可以得到黑色，有些平台可能直接报错\
对有可能为0的分母，需要强行约束为不为零，也可以加或减一个特别小的浮点数来达成这点\

## Shader性能优化
* 减少在Shader中的运算，尤其在片元着色器
* 减少if、while等控制语句在Shader上的运行
主要是由于GPU和CPU关于这些语句的实现方式不同，导致GPU中的这些语句性能很差\
避免控制语句的嵌套\
if中尽量使用常量\
计算流程尽可能上行，将片元着色器的放在顶点着色器执行，将顶点着色器的放在CPU执行\