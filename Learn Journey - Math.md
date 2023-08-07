# 集合
* 具有某种特定性质的事物的总和
* 组成集合的事物被称为这个集合的元素

## 常用数集
* N 自然数集    {0,1,2...}
* N*|N+     不包含0的自然数集{1,2...}
* Z     整数集
* Q     有理数集
* R     实数集


# 函数
* 设x,y两个变量，D是一个给定数集，如果对于每个数x∈D，y按一定的法则总有确定的数值与它对应，则称y是x的函数，y=f(x)
* 函数只和自变量和应变量有关，和符号无关，例 y=2x,x=2y 实为一个函数

## 函数性质

### 奇偶性

1. 偶函数
   关于x=0对称\
   f(x) = f(-x)

2. 奇函数
   关于坐标原点(0,0)对称\
   -f(x) = f(-x)

### 反函数
* 关于 y=x 对称
* 只有单调函数才有对称函数，非单调函数的反函数会导致同一个自变量对应多个应变量，不符合函数定义

### 有界性
* 如果一个函数的应变量永远在 y=m,y=n 范围内，则此函数具有界限

#### 上界限
* 如果一个函数的应变量永远小于等于m，则此函数具有上界限，例如 $y = x^2$

#### 下界限
* 如果一个函数应变量永远大于等于m，则此函数具有下界限,例如 $y = -x^2$

### 周期
* f(x) = f(x+a) = f(x-a)
* y = sin(x)，x∈R 是周期函数
* y = sin(x)，x>0 不是周期函数
* f(x)的周期，一般指f(x)的最小正周期，如 y=sin(x) 的正周期为 π



# 三角函数
* 正弦 sin
* 余弦 cos
* 正切 tan
* 余切 cot
  $cot = \frac{1}{tan}$
* 正割 csc
  $csc = \frac{1}{sin}$
* 余割 sec
  $sec = \frac{1}{cos}$

## 三角函数常用公式
* $sin^2 + cos^2 = 1$
* $1 + tan^2 = sec^2$
* $1 + cot^2 = csc^2$
* $sin(a+-b) = sin(a)cos(b) +- cos(a)sin(b)$
* $sin(2a) = 2 sin(a)cos(a)$
* $cos(2a) = cos(a)^2 - sin(a)^2 = 2 cos(a)^2 - 1 = 1 - 2 sin(a)^2$
* $sin(a)^2 = \frac{1-cos(2a)}{2}$
* $cos(a)^2 = \frac{1+cos(2a)}{2}$
* 积化和差
    $sin(a)cos(b) = \frac{sin(a+b) + sin(a-b)}{2}$
    $sin(a)sin(b) = \frac{cos(a-b) - cos(a+b)}{2}$
    $cos(a)cos(b) = \frac{cos(a+b) + cos(a-b)}{2}$
* 和差化积
    $sin(a) + sin(b) = 2 sin(\frac{a+b}{2}) cos(\frac{a-b}{2})$
    $sin(a) - sin(b) = 2 sin(\frac{a-b}{2}) cos(\frac{a+b}{2})$
    $cos(a) - cos(b) = 2 sin(\frac{a+b}{2}) sin(\frac{a-b}{2})$
    $cos(a) + cos(b) = 2 cos(\frac{a+b}{2}) cos(\frac{a-b}{2})$

## 反三角函数

### 反正弦函数
* y = arcsin(x), x∈[-1,1], y∈[$\frac{-π}{2}$,$\frac{π}{2}$]
* y = sin(x), x∈[$\frac{-π}{2}$,$\frac{π}{2}$] 的反函数
* 奇函数，增函数
* sin(arcsin(x)) = x
* arcsin(sin(x)) 当x∈[$\frac{-π}{2}$,$\frac{π}{2}$]时，等于x，其余情况下不等

### 反余弦函数
* y = arccos(x),x∈[-1,1],y∈[0,π]
* y = cos(x),x∈[0,π] 的反函数
* 减函数
* cos(arccos(x)) = x
* arccos(cos(x)) 当x∈[0,π]时，等于x，其余情况下不等



# 三维坐标系
三维坐标系有左手坐标系和右手坐标系之分\
大拇指是x轴，食指是y轴，中指是z轴

## 旋向性
指不同的两个三维坐标系可以通过旋转变得一致

## 默认旋转方向的定义
按四元数的旋转定义而言，围绕一个轴进行一定度数的旋转，那么旋转方向是如何定义的呢\
在左手坐标系中，我们使用左手法则定义旋转方向，即为顺时针\
在右手坐标系中，我们使用右手法则定义旋转方法，即为逆时针



# 向量
有方向和模长的有向线段



# 标量
只有模长没有方向的线段



# 矩阵
由m*n个标量组成的长方形数组\
以下矩阵M中的元素，可以表示为m11,m12,m13,m21,m22,m23,m31,m32,m33
```math
\begin{bmatrix}
1 & 1 & 1 \\
2 & 2 & 2 \\
3 & 3 & 3
\end{bmatrix}
```
向量可以看成只有1行的行矩阵或只有1列的列矩阵\

## 矩阵和标量的乘法
```math
kM = 
\begin{bmatrix}
1 & 1 & 1 \\
2 & 2 & 2 \\
3 & 3 & 3
\end{bmatrix}
```

## 矩阵和矩阵的乘法
前提：A 的列数必须等于B 的行数\
AB = 以A的行数为行数，B的列数为列数的新矩阵 C，其中C中的元素 cij = Ai · Bj，Ai为A第i行元素构成的向量，Bj为B第j行元素构成的向量

## 转置矩阵
将原矩阵行变为列，列变为行的运算方式\
Mij^T = Mji\

* 特性1：
  $(M^T)^T = M$
* 特性2：
  $(AB)^T = B^TA^T$

## 方阵|方块矩阵
行数等于列数的矩阵\

### 对角元素
行号和列号相等的元素，就是对角元素，比如m11、m22\

### 对角矩阵
如果一个方阵除对角元素外的其他元素都为0，那么这个方阵就是一个对角矩阵\
```math
\begin{bmatrix}
1 & 0 & 0 \\
0 & 2 & 0 \\
0 & 0 & 3
\end{bmatrix}
```

### 单位矩阵
如果一个对角矩阵中对角元素值都为1，则这个矩阵是一个单位矩阵，一般用In来表示\
单位矩阵满足 MI = IM = M\
```math
\begin{bmatrix}
1 & 0 & 0 \\
0 & 1 & 0 \\
0 & 0 & 1
\end{bmatrix}
```

### 逆矩阵
使用M^-1表示\
一个方阵乘以他的逆矩阵，会得到一个单位矩阵\
MM^-1 = I\
不是所有的方阵都由逆矩阵，例如所有元素都为0的矩阵就没有逆矩阵，如果一个方阵有逆矩阵，那这个方阵就是可逆的或非奇异的，反之这个方阵就是不可逆的或奇异的\
一个行列式不为0的矩阵，必定是可逆矩阵\
>> 深入学习：行列式\

* 特性1：
  $(M^{-1})^{-1} = M$
* 特性2：
  $I^{-1} = I$
* 特性3：
  $(M^T)^{-1} = (M^{-1})^T$
* 特性4：
  $(ABC)^{-1} = C^{-1}B^{-1}A^{-1}$

### 正交矩阵
如果一个矩阵和他的转置矩阵相乘是单位矩阵，那么这个矩阵是正交矩阵\
$(M^T)M = M(M^T) = I$

```math
M=
\begin{bmatrix}
V1 \\
V2 \\
V3
\end{bmatrix}
```
```math
M^T=
\begin{bmatrix}
V1 & V2 & V3
\end{bmatrix}
```
则
```math
M(M^T) =
\begin{bmatrix}
V1·V1 & V1·V2 & V1·V3 \\
V2·V1 & V2·V2 & V2·V3 \\
V3·V1 & V3·V2 & V3·V3 
\end{bmatrix} =
\begin{bmatrix}
1 & 0 & 0 \\
0 & 1 & 0 \\
0 & 0 & 1 
\end{bmatrix} = I
```

* 特性1：
  $M^{-1} = M^T$
* 特性2：
  矩阵每一行或列表示的向量都是单位向量
* 特性3：
  矩阵每一行或列表示的向量都相互垂直

## 齐次坐标
M33的矩阵不足以表示平移、缩放等操作，因此我们把它扩展到M44的矩阵，齐次坐标也可能超过四维\

## 平移矩阵
用以表示向量或点的平移的矩阵\

* 点的平移
```math
\begin{bmatrix}
1 & 0 & 0 & tx \\
0 & 1 & 0 & ty \\
0 & 0 & 1 & tz \\
0 & 0 & 0 & 1 
\end{bmatrix}
\begin{bmatrix}
x \\
y \\
z \\
1 
\end{bmatrix} =
\begin{bmatrix}
x+tx \\
y+ty \\
z+tz \\
1 
\end{bmatrix}
```

* 向量的平移
```math
\begin{bmatrix}
1 & 0 & 0 & tx \\
0 & 1 & 0 & ty \\
0 & 0 & 1 & tz \\
0 & 0 & 0 & 1 
\end{bmatrix}
\begin{bmatrix}
x \\
y \\
z \\
0 
\end{bmatrix} = 
\begin{bmatrix}
x \\
y \\
z \\
0 
\end{bmatrix}
```

* 特性1：平移矩阵的逆矩阵就是反向平移得到的矩阵
```math
\begin{bmatrix}
1 & 0 & 0 & -tx \\
0 & 1 & 0 & -ty \\
0 & 0 & 1 & -tz \\
0 & 0 & 0 & 1 
\end{bmatrix}
```

## 缩放矩阵
表示模型或向量沿着x、y、z轴的缩放\

* 模型的缩放
```math
\begin{bmatrix}
kx & 0 & 0 & 0 \\
0 & ky & 0 & 0 \\
0 & 0 & kz & 0 \\
0 & 0 & 0 & 1 
\end{bmatrix}
\begin{bmatrix}
x \\
y \\
z \\
1 
\end{bmatrix} = 
\begin{bmatrix}
x*kx \\
y*ky \\
z*kz \\
1 
\end{bmatrix}
```

* 向量的缩放
```math
\begin{bmatrix}
kx & 0 & 0 & 0 \\
0 & ky & 0 & 0 \\
0 & 0 & kz & 0 \\
0 & 0 & 0 & 1 
\end{bmatrix}
\begin{bmatrix}
x \\
y \\
z \\
0 
\end{bmatrix} = 
\begin{bmatrix}
x*kx \\
y*ky \\
z*kz \\
0 
\end{bmatrix}
```

* 特性1：当kx=ky=kz时，称为统一缩放，其他情况为非统一缩放，统一缩放是按比例的放大或缩小，非统一缩放会导致模型的拉伸或挤压\
* 特性2：缩放矩阵的逆矩阵是原缩放系数倒数的矩阵
```math
\begin{bmatrix}
\frac{1}{kx} & 0 & 0 & 0 \\
0 & \frac{1}{ky} & 0 & 0 \\
0 & 0 & \frac{1}{kz} & 0 \\
0 & 0 & 0 & 1 
\end{bmatrix}
```

当希望不沿着xyz轴进行缩放时，一般会经过变换将缩放轴变换为标准坐标轴，然后进行缩放，再逆变得到原来坐标轴的朝向\

## 旋转矩阵
表示模型或向量绕着x、y、z轴旋转\

```math
Rx(θ) =
\begin{bmatrix}
1 & 0 & 0 & 0 \\
0 & cos(θ) & -sin(θ) & 0 \\
0 & sin(θ) & cos(θ) & 0 \\
0 & 0 & 0 & 1 
\end{bmatrix}
```
```math
Ry(θ) =
\begin{bmatrix}
cos(θ) & 0 & sin(θ) & 0 \\
0 & 1 & 0 & 0 \\
-sin(θ) & 0 & cos(θ) & 0 \\
0 & 0 & 0 & 1 
\end{bmatrix}
```
```math
Rz(θ) =
\begin{bmatrix}
cos(θ) & -sin(θ) & 0 & 0 \\
sin(θ) & cos(θ) & 0 & 0 \\
0 & 0 & 1 & 0 \\
0 & 0 & 0 & 1 
\end{bmatrix}
```

* 特性1：旋转矩阵时正交矩阵，旋转矩阵的串联也是正交矩阵\

## 复合变换
一般按缩放、旋转、平移的过程串联矩阵\
复合旋转一般有给定的绕轴旋转的顺序，在unity中是按zxy\
```math
\begin{bmatrix}
1 & 0 & 0 & 0 \\
0 & 1 & 0 & 0 \\
0 & 0 & 1 & 0 \\
0 & 0 & 0 & 1 
\end{bmatrix}
```

## 坐标系变换

注：以下公式中Xc是Mc坐标系x轴的向量在Mp中的表示，Oc是Mc坐标系中原点在Mp中的表示\

* 点的变换
```math
M(c→p) = 
\begin{bmatrix}
| & | & | & | \\
Xc & Yc & Zc & Oc \\
| & | & | & | \\
0 & 0 & 0 & 1 
\end{bmatrix}
```
```math
M(c→p)Ac = 
\begin{bmatrix}
| & | & | & | \\
Xc & Yc & Zc & Oc \\
| & | & | & | \\
0 & 0 & 0 & 1 
\end{bmatrix}
\begin{bmatrix}
a \\
b \\
c \\
1
\end{bmatrix}
```

* 向量的变换
```math
M(c→p) =
\begin{bmatrix}
| & | & | \\
Xc & Yc & Zc \\
| & | & | 
\end{bmatrix} 
= M(p→c)^-1
= M(p→c)^T =
\begin{bmatrix}
\cdots & Xp & \cdots \\
\cdots & Yp & \cdots \\
\cdots & Zp & \cdots 
\end{bmatrix} 
```
M(c→p)是正交矩阵，因为坐标轴都是正交矩阵\
验证以上公式可用：\
```math
M(c→p)Xp =
\begin{bmatrix}
\cdots & Xp & \cdots \\
\cdots & Yp & \cdots \\
\cdots & Zp & \cdots 
\end{bmatrix} 
\begin{bmatrix}
| \\
Xp \\
| 
\end{bmatrix} =
\begin{bmatrix}
Xp·Xp \\
Yp·Xp \\
Zp·Xp 
\end{bmatrix} =
\begin{bmatrix}
1 \\
0 \\
0 
\end{bmatrix}
```
