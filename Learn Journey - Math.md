# 高数符号
* ∑
  表示sum求和，用编程概念理解，i和n表示数组键的范围，k表示数组标识，以下式子就是在数组k中取$k_1$~$k_n$的求和
  $\displaystyle\sum_{i=1}^{n}k_i$


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



# 全排列和对换

## 全排列
把n个元素排成一行，被称为这n个元素的全排列
* 标准次序\
  元素排列的规则
* 逆序数\
  如果某2个元素排列和标准次序不同，则称为这两个元素构成一次逆序
* 奇偶排列\
  逆序数为奇数的排列是奇排列，逆序数为偶数的排列为偶排列

## 对换
将排列中任意2个元素交换位置
* 相邻对换\
  相邻的两个元素对换
* 奇排列对换1次后为偶排列，偶排列对换1次后为奇排列
* 奇排列对换为标准排列需要奇数次对换，偶排列对换为标准排列需要偶数次对换



# 行列式

## 2阶

有方程组
$$
\begin{cases}
a_{11}x_1+a_{12}x_2=b_1 \\
a_{21}x_1+a_{22}x_2=b_2 \\
\end{cases}
$$
则
$$
\begin{cases}
x_1 = \frac{1}{2} \\
a_{21}x_1+a_{22}x_2=b_2 \\
\end{cases}
$$

用行列式表示
$$
x_1 = \frac{D_1}{D} = \frac{
  \begin{vmatrix}
  b_1 & a_{12} \\
  b_2 & a_{22} \\
  \end{vmatrix} 
}{
  \begin{vmatrix}
  a_{11} & a_{12} \\
  a_{21} & a_{22} \\
  \end{vmatrix} 
} = \frac{
  b_1a_{22}-b_2a_{12}
}{
  a_{11}a_{22}-a_{12}a_{21}
}
$$
$$
x_2 = \frac{D_2}{D} = \frac{
  \begin{vmatrix}
  a_{11} & b_1 \\
  a_{21} & b_2 \\
  \end{vmatrix} 
}{
  \begin{vmatrix}
  a_{11} & a_{12} \\
  a_{21} & a_{22} \\
  \end{vmatrix} 
} = \frac{
  b_2a_{11}-b_1a_{21}
}{
  a_{11}a_{22}-a_{12}a_{21}
}
$$

## 3阶
$$
\begin{vmatrix}
a_{11} & a_{12} & a_{13} \\
a_{21} & a_{22} & a_{23} \\
a_{31} & a_{32} & a_{33} \\
\end{vmatrix} =
a_{11}×a_{22}×a_{33} + a_{12}×a_{23}×a_{31} + a_{13}×a_{21}×a_{32} - a_{11}×a_{23}×a_{32} - a_{12}×a_{21}×a_{33} -a_{13}×a_{22}×a_{31}
$$

## n阶
$$
\begin{vmatrix}
a_{11} & a_{12} & \cdots & a_{1n} \\
a_{21} & a_{22} & \cdots & a_{2n} \\
\vdots & \vdots & \ddots & \vdots \\
a_{n1} & a_{n2} & \cdots & a_{nn} \\
\end{vmatrix} = 
\displaystyle\sum_{p_1\cdots p_n}(-1)^{p_1\cdots p_n}a_{1p_1}a_{2p_2}\cdots a_{np_n}
$$

## 特殊行列式

* 上（下）三角行列式

  主对角线以上（以下）的行列式
$$
\begin{vmatrix}
a_{11} & 0 & \cdots & 0 \\
a_{21} & a_{22} & \cdots & 0 \\
\vdots & \vdots & \ddots & \vdots \\
a_{n1} & a_{n2} & \cdots & a_{nn} \\
\end{vmatrix} = 
a_{11}a_{11}\cdots a_{nn}
$$

* 对角行列式
  
  主对角线上下皆为0的行列式
$$
\begin{vmatrix}
a_{11} & 0 & \cdots & 0 \\
0 & a_{22} & \cdots & 0 \\
\vdots & \vdots & \ddots & \vdots \\
0 & 0 & \cdots & a_{nn} \\
\end{vmatrix} = 
a_{11}a_{11}\cdots a_{nn}
$$

## 行列式的特性
* 行列式等于它的转置行列式
  $D = D^T$
* 对换行列式2行/列，行列式变号
* 行列式2行/列相等，行列式结果为0
* 行列式某行/列乘k，等于行列式结构乘k
* 行列式某行/列是某2数列上的值的和，行列式等于该行/列分别以这两个数列构成的行列式的和
* 行列式某行/列乘k加到另一行/列，行列式值不变



# 矩阵
由m*n个标量组成的长方形数组\
可以表示为$A_{m×n}$，也可表示为$(a_{ij})_{m×n}$\
$m×n$成为矩阵的型\
以下矩阵M中的元素，可以表示为m11,m12,m13,m21,m22,m23,m31,m32,m33
```math
\begin{bmatrix}
1 & 1 & 1 \\
2 & 2 & 2 \\
3 & 3 & 3
\end{bmatrix}
```
向量可以看成只有1行的行矩阵或只有1列的列矩阵\

## 矩阵类型

### 行矩阵|列矩阵

* 行矩阵
```math
\begin{bmatrix}
a_{11} & a_{12} & a_{13} \cdots a_{1n}
\end{bmatrix}
```
* 列矩阵
```math
\begin{bmatrix}
a_{11} \\
a_{21} \\
\vdots \\
a_{n1} \\
\end{bmatrix}
```

### 方阵|方块矩阵|n阶矩阵
行数等于列数的矩阵

* 对角元素\
行号和列号相等的元素，就是对角元素，比如m11、m22

### 零矩阵
使用$O$表示\
不同型的零矩阵不想等

### n阶对角矩阵
一个方阵除对角元素外的其他元素都为0的方阵\
用$diag(a11, a22, \cdots, ann)$表示\
对角矩阵是特殊的方阵
```math
\begin{bmatrix}
a_{11} & 0 & 0 & 0 \\
0 & a_{22} & 0 & 0 \\
0 & 0 & \ddots & 0 \\
0 & 0 & 0 & a_{nn}
\end{bmatrix}
```

### 数量阵 | 纯量阵
满足 $a_{11} = a_{22} = \dots = a_{nn} = a $ 的对角矩阵

### 单位矩阵
如果一个对角矩阵中对角元素值都为1，则这个矩阵是一个单位矩阵，一般用In来表示\
记为$E_n$\
```math
\begin{bmatrix}
1 & 0 & 0 \\
0 & 1 & 0 \\
0 & 0 & 1
\end{bmatrix}
```
单位矩阵满足 AE = EA = A, 其中A为方阵\
$E_m A_{mn} = A_{mn}$\
$A_{mn} E_n = A_{mn}$

### 逆矩阵
使用M^-1表示\
一个方阵乘以他的逆矩阵，会得到一个单位矩阵\
MM^-1 = I\
不是所有的方阵都由逆矩阵，例如所有元素都为0的矩阵就没有逆矩阵，如果一个方阵有逆矩阵，那这个方阵就是可逆的或非奇异的，反之这个方阵就是不可逆的或奇异的\
一个行列式不为0的矩阵，必定是可逆矩阵

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

## 非齐次线性方程组
$$
\begin{cases}
a_{11}x_1 + a_{12}x_2 + a_{13}x_3 + \dots + a_{1n}x_n = b_1 \\
a_{21}x_1 + a_{22}x_2 + a_{23}x_3 + \dots + a_{2n}x_n = b_2 \\
\vdots \\
a_{m1}x_1 + a_{m2}x_2 + a_{m3}x_3 + \dots + a_{mn}x_n = b_m \\
\end{cases}
$$

* 系数阵
$$
A = 
\begin{bmatrix}
a_{11} & a_{12} & \dots & a_{1n} \\
a_{21} & a_{22} & \dots & a_{2n} \\
\vdots \\
a_{m1} & a_{m2} & \dots & a_{mn}
\end{bmatrix}
$$

* 未知数矩阵
$$
X = 
\begin{bmatrix}
x_{1} \\
x_{2} \\
\vdots \\
x_{n}
\end{bmatrix}
$$

* 常数项矩阵
$$
b = 
\begin{bmatrix}
b_{1} \\
b_{2} \\
\vdots \\
b_{n}
\end{bmatrix}
$$

* 增广矩阵
$$
\begin{bmatrix}
a_{11} & a_{12} & \dots & a_{1n} & b_1 \\
a_{21} & a_{22} & \dots & a_{2n} & b_2 \\
\vdots \\
a_{m1} & a_{m2} & \dots & a_{mn} & b_m
\end{bmatrix}
$$

### 表达形式
* 矩阵形式
$AX=b$
* 向量形式
把A做列分块得
$$
A=
\begin{bmatrix}
\alpha_{1} & \alpha_{2} & \cdots & \alpha_{n}
\end{bmatrix}
$$
则
$$
AX = 
\begin{bmatrix}
\alpha_{1} & \alpha_{2} & \cdots & \alpha_{n}
\end{bmatrix}
\begin{bmatrix}
x_1 \\
x_2 \\
\vdots \\
x_n
\end{bmatrix}=
\alpha_1 x_1 + \alpha_2 x_2 + \cdots + \alpha_{n} x_n = b
$$

## 矩阵的运算方法

### 矩阵的和差
2个同型矩阵之间可以使用和差运算
$$
A_{m×n} \pm B_{m×n} = (a_{ij} \pm b_{ij})_{m×n} 
$$

* 交换律\
  $A+B = B+A$
* 结合律\
  $(A+B)+C = A+(B+C)$

### 矩阵数乘
矩阵和标量的乘法
```math
kM = 
k
\begin{bmatrix}
1 & 1 & 1 \\
2 & 2 & 2 \\
3 & 3 & 3
\end{bmatrix}
=
\begin{bmatrix}
k & k & k \\
2k & 2k & 2k \\
3k & 3k & 3k
\end{bmatrix}
```

### 矩阵和矩阵的乘法
前提：A 的列数必须等于B 的行数\
AB = C = 以A的行数为行数，B的列数为列数的新矩阵 C\
其中C中的元素 $c_{ij} = A_i · B_j$，$A_i$为A第i行元素构成的向量，$B_j$为B第j行元素构成的向量

* 结合律
  $A+B+C = A+(B+C)$
* 分配律
  $A(B+C) = AB + AC$\
  $(B+C)A = BA + CA$

### 方幂 | 矩阵的幂次方运算
前提：必须是方阵\
$A^k = A A \dots A $\
$A^k A^l = A^{k+l}$\
$(A^k)^l = A^{kl}$\
* $(AB)^k = AB AB AB \dots AB \neq A^k B^k$\
  仅有当$AB = BA$ 则 $(AB)^k = A^k B^k$

#### 方幂的求解思路
1. 归纳法
2. 展开为列矩阵与行距阵后通过结合律计算中间项
3. 若$B^n = 0$ 可通过 $A = B + kE$
4. 相似对角化

## 转置矩阵
将原矩阵行变为列，列变为行的运算方式\
$M_{ij}^T = M_{ji}$

* $(A^T)^T = A$
* $(A+B)^T = A^T + B^T$
* $(kA)^T = k A^T$
* $(AB)^T = B^T A^T$

### 对称矩阵
$A^T = A$的矩阵

### 反对称矩阵
$A^T = -A$的矩阵

## 方阵的行列式
由n阶方针A的所有元素构成的行列式，记做$|A|$或$det(A)$\
矩阵是一个数表\
方阵的行列式是一个数

* $|A^T| = |A|$
* $|kA| = k^n |A|$
* $|AB| = |A| |B|$

### 伴随矩阵
行列式$|A|$的各个元素的代数余子式$A_{ij}$构成的矩阵\
$$
A^* = 
\begin{bmatrix}
A_{11} & A_{21} & \cdots & A_{n1} \\
A_{12} & A_{22} & \cdots & A_{n2} \\
\vdots & \vdots & \ddots & \vdots \\
A_{1n} & A_{2n} & \cdots & A_{nn} \\
\end{bmatrix}
$$

* $A A^* = A^* A = |A|E$
* $A^* = |A| A^{-1}$
* $(A^*)^{-1} = (A^{-1})^*$
* $(A^*)^T = (A^T)^*$
* $(A^*)^* = |A|^{n-2} A$
* $(AB)^* = B^* A^*$
* $(kA)* = k^{n-1} A^*$

## 方阵可逆
如果对方阵A存在方阵B，使得$AB = BA = E$，则A可逆，且方阵A是非奇异矩阵\
$B = A^{-1}$

* 若方阵可逆，$|A| \neq 0$，反之$|A| \neq 0$，A必定可逆
* $A^{-1} = \frac{A^*}{|A|}$\
  可通过在$|A \neq 0$时同除$|A|$得出结论
* 若A为方阵，且$AB = E$，则A可逆，且逆矩阵为B
* 若A可逆，则有且仅有唯一B为A的逆矩阵
* 若A可逆，则$|A| = \frac{1}{|A|}$
* 若A可逆，则$(A^{-1})^{-1} = A$
* 若A可逆，则$A^T$也可逆，且$(A^T)^{-1} = (A^{-1})^T$
* 若A可逆，则对$k \neq 0$，$(kA)^{-1} = \frac{1}{k} A^{-1}$
* 若A、B可逆，则AB可逆，且$(AB)^{-1} = B^{-1}A^{-1}$

* 2阶方阵A的逆矩阵$A^{-1}$为，$\frac{1}{|A|}$ * 主对角线互换位置，副对角线加负号的矩阵

## 方阵的多项式
定义为 $\phi (A) = a_0 E + a_1 A + \cdots + a_m A^m$

* 因为$A^k$，$A^l$，$E$均可以交换，则A的不同的多项式也可以交换，因为A的多项式相乘，始终是$A^k$，$A^l$，$E$在相乘
* 若$A = P \lambda P^{-1}$，则$A = P \phi (\lambda) P^{-1}$

## 克拉默法则
含有n个未知量的线性方程组 *
$$
\begin{cases}
a_{11} x_1 + a_{12} x_2 + \cdots + a_{1n} x_n = b_1 \\
a_{21} x_1 + a_{22} x_2 + \cdots + a_{2n} x_n = b_2 \\
\vdots \\
a_{n1} x_1 + a_{n2} x_2 + \cdots + a_{nn} x_n = b_n
\end{cases}
$$
则系数矩阵可以表示为A
$$
A = 
\begin{bmatrix}
a_{11} & a_{12} & \cdots & a_{1n} \\
a_{21} & a_{22} & \cdots & a_{2n} \\
\vdots & \vdots & \ddots & \vdots \\
a_{n1} & a_{n2} & \cdots & a_{nn} 
\end{bmatrix}
$$
未知数矩阵可以表示为X
$$
X = 
\begin{bmatrix}
x_{1}\\
x_{2}\\
\vdots \\
x_{n}\\
\end{bmatrix}
$$
常数矩阵可以表示为b
$$
b = 
\begin{bmatrix}
b_{1}\\
b_{2}\\
\vdots \\
b_{n}\\
\end{bmatrix}
$$
则多项式可以表示为 $AX = b$ \
且若$|A| \neq 0$，则 * 有唯一解，$x_1 = \frac{|A_1|}{|A|}$，$x_2 = \frac{|A_2|}{|A|}$ $\cdots$ $x_n = \frac{|A_n|}{|A|}$ \
其中 $A_j$ 可以表示为系数矩阵A中第j列元素用常数项代替得到的矩阵
$$
A_j = 
\begin{bmatrix}
a_{11} & a_{12} & \cdots & a_{1,j-1} & b_1 & a_{1,j+1} & \cdots & a_{1n} \\
a_{21} & a_{22} & \cdots & a_{2,j-1} & b_2 & a_{2,j+1} & \cdots & a_{2n} \\
\vdots & \vdots & \vdots & \vdots & \vdots & \vdots & \ddots & \vdots \\
a_{n1} & a_{n2} & \cdots & a_{n,j-1} & b_n & a_{n,j+1} & \cdots & a_{nn} 
\end{bmatrix}
$$

### 证明
$|A| \neq 0$，所以A可逆，对$AX = b$左乘$A^{-1}$ \
$$
X = A^{-1} b = \frac{1}{|A|} A^* b
$$
$$
\begin{bmatrix}
x_{1}\\
x_{2}\\
\vdots \\
x_{n}\\
\end{bmatrix} = \frac{1}{|A|}
\begin{bmatrix}
A_{11} & A_{12} & \cdots & A_{1n}\\
A_{21} & A_{22} & \cdots & A_{2n}\\
\vdots & \vdots & \ddots & \vdots & \\
A_{n1} & A_{n2} & \cdots & A_{nn}\\
\end{bmatrix}
\begin{bmatrix}
b_{1}\\
b_{2}\\
\vdots \\
b_{n}\\
\end{bmatrix} = \frac{1}{|A|}
\begin{bmatrix}
A_{11}b_1 + A_{12}b_2 + \cdots + A_{1n}b_n\\
A_{21}b_1 + A_{22}b_2 + \cdots + A_{2n}b_n\\
\vdots \\
A_{n1}b_1 + A_{n2}b_2 + \cdots + A_{nn}b_n\\
\end{bmatrix}
$$
则 $|A_j| = A_{11}b_1 + A_{12}b_2 + \cdots + A_{1n}b_n$，为A的第j列为b的矩阵的第j列展开
则 $x_j = \frac{|A_j|}{|A|}$

### 性质及推论
* 如果$A_n X = 0$，且$|A| \neq 0$，则只有解为0
* 如果$A_n X = b$无解或有2个及以上解，则$|A|=0$

## 齐次坐标
M33的矩阵不足以表示平移、缩放等操作，因此我们把它扩展到M44的矩阵，齐次坐标也可能超过四维\

## 分块矩阵
按一定规则把矩阵分为多个矩阵，通过观察达到简化计算的目的
$$
A = 
\begin{bmatrix}
a_{11} & a_{12} | & a_{13} & a_{14}\\
a_{21} & a_{22} | & a_{23} & a_{24}\\
-- & -- & -- & -- \\
a_{31} & a_{32} | & a_{33} & a_{34}
\end{bmatrix}
$$
分割得
$$
A = 
\begin{bmatrix}
A_{11} & A_{12}\\
A_{21} & A_{22}
\end{bmatrix}
$$
$$
A_{11} = 
\begin{bmatrix}
a_{11} & a_{12}\\
a_{21} & a_{22}
\end{bmatrix},
A_{12} = 
\begin{bmatrix}
a_{13} & a_{14}\\
a_{23} & a_{24}
\end{bmatrix},
A_{21} = 
\begin{bmatrix}
a_{31} & a_{32}
\end{bmatrix},
A_{22} = 
\begin{bmatrix}
a_{33} & a_{34}
\end{bmatrix}
$$

### 分块矩阵的和差
AB同型且做相同分块方式，则和差为对应块的加减
$$
A + B =
\begin{bmatrix}
A_{11} & \cdots & A_{1r}\\
\vdots &  & \vdots \\
A_{s1} & \cdots & A_{sr}
\end{bmatrix} +
\begin{bmatrix}
B_{11} & \cdots & B_{1r}\\
\vdots &  & \vdots \\
B_{s1} & \cdots & B_{sr}
\end{bmatrix} = 
\begin{bmatrix}
A_{11} + B_{11} & \cdots & A_{1r} + B_{1r}\\
\vdots &  & \vdots \\
A_{s1} + B_{s1} & \cdots & A_{sr} + B_{sr}
\end{bmatrix}
$$

### 分块矩阵的数乘
$$
\lambda A =
\begin{bmatrix}
\lambda A_{11} & \cdots & \lambda A_{1r}\\
\vdots &  & \vdots \\
\lambda A_{s1} & \cdots & \lambda A_{sr}
\end{bmatrix}
$$

### 分块矩阵的乘法
设$A_{ml}, B_{ln}$，若A的列分法与B的行分法一致，则块乘法与矩阵元素乘法一致
$$
AB =
\begin{bmatrix}
A_{11} & \cdots & A_{1l}\\
\vdots &  & \vdots \\
A_{m1} & \cdots & A_{ml}
\end{bmatrix}
\begin{bmatrix}
B_{11} & \cdots & B_{1n}\\
\vdots &  & \vdots \\
B_{l1} & \cdots & B_{ln}
\end{bmatrix}
$$

### 分块矩阵的方幂
仅对分块对角矩阵
$$
A^k = 
\begin{bmatrix}
A_{1} &  &  &\\
& A_{2} & & \\
& & \ddots & \\
& & & A_{n}
\end{bmatrix}^k =
\begin{bmatrix}
A_{1}^k &  &  &\\
& A_{2}^k & & \\
& & \ddots & \\
& & & A_{n}^k
\end{bmatrix}
$$

### 分块矩阵的转置
$$
A^T = 
\begin{bmatrix}
A_{11} & \cdots & A_{1r}\\
\vdots &  & \vdots \\
A_{s1} & \cdots & A_{sr}
\end{bmatrix} ^T = 
\begin{bmatrix}
A_{11}^T & \cdots & A_{s1}^T\\
\vdots &  & \vdots \\
A_{1r}^T & \cdots & A_{sr}^T
\end{bmatrix}
$$

### 分块矩阵的行列式
* 若A为分块对角矩阵
$$
|A|= 
\begin{vmatrix}
A_{1} &  &  &\\
& A_{2} & & \\
& & \ddots & \\
& & & A_{n}
\end{vmatrix} 
= |A_{1}| |A_{2}| \cdots |A_{n}|
$$
* 若
$$
|A| = 
\begin{vmatrix}
A_{nn} & B_{nm}\\
O & c_{mm}\\
\end{vmatrix} =
\begin{vmatrix}
A_{nn} & O\\
B_{mn} & c_{mm}\\
\end{vmatrix} =
|A_{nn}||C_{mm}|
$$
* 若
$$
|A| = 
\begin{vmatrix}
O & A_{nn}\\
C_{mm} & B_{mn}\\
\end{vmatrix} =
\begin{vmatrix}
B_{nm} & A_{nn}\\
C_{mm} & O\\
\end{vmatrix} =
(-1)^{mn} |A_{nn}| |C_{mm}|
$$

### 分块矩阵的逆运算
* 若A为分块对角阵，且$|A_{1}| \neq 0,|A_{2}| \neq 0,\cdots,|A_{n}| \neq 0$，则
$$
A= 
\begin{bmatrix}
A_{1} &  &  &\\
& A_{2} & & \\
& & \ddots & \\
& & & A_{n}
\end{bmatrix}^{-1} =
\begin{bmatrix}
A_{1}^{-1} &  &  &\\
& A_{2}^{-1} & & \\
& & \ddots & \\
& & & A_{n}^{-1}
\end{bmatrix}
$$
* 若
$$
A^{-1} = 
\begin{bmatrix}
A & C \\
O & B 
\end{bmatrix}^{-1} =
\begin{bmatrix}
A^{-1} & -A^{-1} C B^{-1} \\
O & B^{-1} 
\end{bmatrix}
$$
* 若
$$
A^{-1} =  
\begin{bmatrix}
A & O \\
C & B 
\end{bmatrix}^{-1} =
\begin{bmatrix}
A^{-1} & O \\
-B^{-1} C A^{-1} & B^{-1} 
\end{bmatrix}
$$
* 若
$$
A^{-1} =  
\begin{bmatrix}
O & A \\
B & O 
\end{bmatrix}^{-1} =
\begin{bmatrix}
O & B^{-1} \\
A^{-1} & O 
\end{bmatrix}
$$
* 若
$$
A^{-1} =  
\begin{bmatrix}
C & A \\
B & 0 
\end{bmatrix}^{-1} =
\begin{bmatrix}
O & B^{-1} \\
A^{-1} & -A^{-1} C B^{-1} 
\end{bmatrix}
$$
* 若
$$
A^{-1} =  
\begin{bmatrix}
O & A \\
B & C 
\end{bmatrix}^{-1} =
\begin{bmatrix}
-B^{-1} C A^{-1} & B^{-1} \\
A^{-1} & O 
\end{bmatrix}
$$

## 矩阵初等变换

### 矩阵的等价
如果A经过有限次的初等行(列)变换，转换成B，则称A、B行(列)等价，记作$A \xrightarrow{r} B$($A \xrightarrow{c} B$)
若A经过有限次初等变换转换成B，则称A、B等价，记作$A \sim B$

* 反身性，$A \sim B$
* 对称性，若$A \sim B$，则$B \sim A$
* 传递性，若$A \sim B$，$B \sim C$，则$A \sim C$

### 特殊的相关矩阵

* 行阶梯矩阵
$$
\begin{bmatrix}
\Delta & * & * & * & * & * \\
0 & \Delta & * & * & * & * \\
0 & 0 & 0 & 0 & \Delta & * \\
0 & 0 & 0 & 0 & 0 & \Delta
\end{bmatrix},
\Delta \neq 0 
$$

* 行最简形矩阵
$$
\begin{bmatrix}
1 & 0 & * & * & 0 & * \\
0 & 1 & * & * & 0 & * \\
0 & 0 & 0 & 0 & 1 & * \\
0 & 0 & 0 & 0 & 0 & 0
\end{bmatrix}
$$

* 标准形矩阵
$$
A_{mn} \xrightarrow{r,c} 
\begin{bmatrix}
E_r & 0 \\
0 & 0
\end{bmatrix}
$$

## 初等矩阵
单位矩阵E经过1次初等变换得到的矩阵，称为初等矩阵

* $E_{ij}$
$$
\begin{bmatrix}
1 \\
& \ddots \\
& & 0 & \cdots & \cdots & \cdots & 1\\
& & \vdots & 1 & & & \vdots\\
& & \vdots & & \ddots & & \vdots\\
& & \vdots & & & 1 & \vdots\\
& & 1 & \cdots & \cdots & \cdots & 0 \\
& & & & & & & \ddots \\
& & & & & & & & 1
\end{bmatrix}
$$

* $E_{i(k)} , k \neq 0$
$$
\begin{bmatrix}
1 \\
& \ddots \\
& & 1 \\
& & & k \\
& & & & 1 \\
& & & & & \ddots \\
& & & & & & 1 
\end{bmatrix}
$$

* $E_{ij(k)} , k \neq 0$
$$
\begin{bmatrix}
1 \\
& \ddots \\
& & 1 & \cdots & k \\
& & & \ddots & \vdots \\
& & & & 1 \\
& & & & & \ddots \\
& & & & & & 1 
\end{bmatrix}
$$

1. 矩阵A左乘初等矩阵，相当于对A做初等行变换
2. 矩阵A又乘初等矩阵，相当于对A做初等列变换
3. 若方阵A可逆，则A只进行标准行或列变换就能得到矩阵标准型
4. 若方阵A可逆，则存在有限个初等矩阵$P_1,P_2,\cdots,P_n$，使得$A = P_1 P_2 \cdots P_n$
5. 若$A_{mn} \xrightarrow{r} B_{mn}$，则存在m阶可逆矩阵P，使得$PA = B$
6. 若$A_{mn} \xrightarrow{c} B_{mn}$，则存在n阶可逆矩阵Q，使得$AQ = B$
7. 若$A_{mn} \xrightarrow B_{mn}$，则存在m阶可逆矩阵P和n阶可逆矩阵Q，使得$PAQ = B$
8. 若A为n阶可逆方阵，则$A \xrightarrow{r} E$

## 矩阵的秩
矩阵的最高阶非零子式的阶数，就是矩阵的秩，记做$R(A)$或$r(A)$
* 在$A_{mn}$中，任取k行与k列，$k <= min(m,n)$，位于这些行列交叉处有$k^2$个元素，不改变他们在A中的位置而取得的k阶行列式，成为A的k阶子式
* 在A中有一个不等于0的r阶子式D，满足r+1阶子式全为0，那么D为A的最高阶非零子式，其中r就是矩阵A的秩
* 零矩阵的秩为0
* $0 \leq R(A) \leq min(m,n)$
* 已知R(A)，若A中有某个s阶非零子式，则$R(A) \ge s$，若A中有l阶子式全为0，则$R(A) \lt l$
* $R(A^T) = R(A)$
* $A_n 可逆 \Leftarrow \Rightarrow |A| \neq 0 \Leftarrow \Rightarrow R(A) = n$ 
* $A_{mn}，$若$R(A) = m$，则A为行满秩矩阵
* $A_{mn}，$若$R(A) = n$，则A为列满秩矩阵
* 可逆矩阵就是满秩矩阵，不可逆矩阵就是降秩矩阵
* 行阶梯矩阵的秩是非零行的行数
* 初等变换不改变矩阵的秩
* 若AB等价，即$A \sim B$，则$R(A) = R(B)$
* 若PQ可逆则$R(PAQ) = R(A)$
* $max(R(A),R(B)) \le R(A,B) \le R(A) + R(B)$ \
  $R(A^T) = R(A), R(B^T) = R(B)$\
  将$R(A^T)$,$R(B^T)$基础行变换为行阶梯矩阵$A_1, B_1$\
  $R(\frac{A_1}{B_1}) = R(\frac{A^T}{B^T}) \le R(A) + R(B)$ 
* $R(A \pm B) \le R(A) + R(B)$\
  为$(A \pm B)$ 构建增广矩阵 $(A \pm B, B)$\
  $(A \pm B, B) \xrightarrow{c} (A, B)$\
  所以$R(A \pm B) \le R(A \pm B, B) \le R(A) + R(B)$
* $R(AB) \le min(R(A),R(B))$
* 若$A_{mn} B_{nt} = 0$，则$R(A) + R(B) \le n$

### n元线性方程组与矩阵的秩
$A_{mn} X_{n1} = b{m1}$，其中m为方程个数，n为未知量个数
* 若$R(A) = R(A,b) = n \Leftarrow \Rightarrow AX = b 有唯一解$
* 若$R(A) = R(A,b) < n \Leftarrow \Rightarrow AX = b 有无穷解$
* 若$R(A) < R(A,b) < n \Leftarrow \Rightarrow AX = b 无解$

1. n元齐次线性方程组中，$A_{mn}=0 有非零解 \Leftarrow \Rightarrow R(A) < n$，$A_{mn}=0 只有零解 \Leftarrow \Rightarrow R(A) = n$
2. n元非齐次线性方程组中，$A_{mn}=b 有解 \Leftarrow \Rightarrow R(A) = R(A,b)$
3. 矩阵方程$AX=B 有解 \Leftarrow \Rightarrow R(A) = R(A,B)$



# 向量组的线性相关性

## 向量
n个有次序的数$a_1, a_2, \cdots, a_n$的数组成为n维向量，其中数组的元素成为向量的分量
* 实向量：分量均为实数的向量
* 复向量：有1个以上的分量为复数的向量

向量一般使用$\alpha, \beta, \cdots$表示，且一般情况下$\alpha$为列向量，$\alpha^T$为行向量
$$
\alpha = 
\begin{bmatrix}
a_1 \\
a_2 \\
\vdots \\
a_n
\end{bmatrix}
$$
向量是矩阵，符合矩阵运算的规则

## 向量组
若干个同维数的列向量（行向量）组成的集合称为向量组

1. 矩阵与向量组
   可以将矩阵写错列向量组或行向量组的形式
2. 线性方程组的解与向量组\
   方程组的向量形式：$x_1 \alpha _1 + x_2 \alpha _2 + \cdots + x_n \alpha _n = b$

### 向量组的线性组合
* 线性组合\
  对一个向量组，使用$k_1, k_2, \cdots, k_m$的组合系数分别乘以向量组的向量，这个过程叫线性组合\
$k_1 \alpha _1 + k_2 \alpha _2 + \cdots + k_m \alpha _m$
* 向量的线性表示\
  对一个向量b，若存在组合系数，使得$b = k_1 \alpha _1 + k_2 \alpha _2 + \cdots + k_m \alpha _m$，则称向量b可由向量组A线性表示\
即方程组$x_1 \alpha _1 + x_2 \alpha _2 + \cdots + x_n \alpha _n = b$有解\
则$R(A) = R(A,b)$
* 向量组的线性表示\
  若向量组B中的每个向量都能由向量组A线性表示，则称向量组B可由向量组A线性表示
* 矩阵表示\
  设向量组$A = (\alpha _1, \alpha _2, \cdots, \alpha _m)$和向量组$B = (\beta _1, \beta _2, \cdots, \beta _l)$，若满足
$$
\beta _j = (\alpha _1, \alpha _2, \cdots, \alpha _m) * 
\begin{bmatrix}
k_{1j} \\
k_{2j} \\
\vdots \\
k_{mj}
\end{bmatrix},
j \in (1,2,\cdots,l)
$$
则可表示为
$$
(\beta _1, \beta _2, \cdots, \beta _m) =
(\alpha _1, \alpha _2, \cdots, \alpha _m) * 
\begin{bmatrix}
k_{11} & k_{12} & \cdots & k_{1l} \\
k_{21} & k_{22} & \cdots & k_{2l} \\
\vdots & \vdots & \ddots & \vdots \\
k_{m1} & k_{m2} & \cdots & k_{ml} 
\end{bmatrix}
$$
记作$B = AK$，K称为系数矩阵或表示矩阵\
对于$A_{mn} B_{nl} = C_{ml}$，则C的列向量组可由A的列向量组线性表示，C的行向量组可由B的行向量组线性表示
* 向量组等价\
  若向量组A与向量组B可以互相线性表示，则称AB等价\
  且AB等价 $\Leftarrow\Rightarrow R(A) = R(B) = R(A,B)$
* 向量组构成的矩阵等价则向量组也等价，但向量组等价时构成的矩阵不一定等价，因为矩阵等价需要同型
* 若向量组$\beta _1, \beta _2, \cdots, \beta _l$可由向量组$\alpha _1, \alpha _2, \cdots, \alpha _m$线性表示，则$R(\beta _1, \beta _2, \cdots, \beta _l) \le R(\alpha _1, \alpha _2, \cdots, \alpha _m)$
* 若n维单位坐标向量可由向量组A线性表示 $\Leftarrow\Rightarrow R(A) = n$\
  可由$A_{mn}X = E_n有解，即R(A) = R(A,E) = n$证得

### 向量组的线性相关
对于用向量组A，把0向量线性表示，则$k_1 \alpha _1 + k_2 \alpha _2 + \cdots + k_m \alpha _m = 0 $\
若当且仅当$k_1 = k_2 = \cdots = k_m = 0$时，上式成立，则$\alpha _1, \alpha _2, \cdots, \alpha _m$线性无关\
若$k_1, k_2, \cdots, k_m$不全为0时，上式成立，则$\alpha _1, \alpha _2, \cdots, \alpha _m$线性相关

* 若向量组A线性相关，则R(A) < m
* 若向量组A线性无关，则R(A) = m
* 若向量组A由n个n维向量构成，则当向量组A线性相关时，$|A| \neq 0$，当向量组A线性无关时，$|A| = 0$
* 若2维向量$\alpha _1, \alpha _2$线性相关，即$\alpha _1, \alpha _2$共线
* 若3维向量$\alpha _1, \alpha _2, \alpha _3$线性相关，即$\alpha _1, \alpha _2, \alpha _3$共面
* 对于向量组A:$\alpha _1, \alpha _2, \cdots, \alpha _m$、向量组B:$\alpha _1, \alpha _2, \cdots, \alpha _m, \alpha _{m+1} + \cdots + \alpha _{m+n}$，若A线性相关则B线性相关，若B线性无关则A线性无关
* A为m个n维向量构成的向量组，若$n < m$，则A一定线性相关
* A为m个n位向量构成的向量组，若A线性无关，则当向量分量增加时，A仍线性无关
* 对于向量组A:$\alpha _1, \alpha _2, \cdots, \alpha _m$，若A线性无关，且向量组B:$\alpha _1, \alpha _2, \cdots, \alpha _m, \beta$线性相关，则$\beta$可由向量组A唯一线性表示

### 向量组的秩
1. 秩与最大无关组\
   对于向量组A，在其中选出r个向量，满足$\alpha _1, \alpha _2, \cdots, \alpha _r$线性无关，且在A中任意r+1个向量都线性相关，
   则称$\alpha _1, \alpha _2, \cdots, \alpha _r$是向量组A的最大线性无关组，其中r被称为向量组单秩，记为$R_A$，最大线性无关组可以有多个，但$R_A$固定
   1. 向量组A与其最大线性无关组等价
   2. 矩阵A的秩等于向量组A对应列向量组的秩，也等于行向量组的秩
   3. 矩阵A最高阶非零子式所在的列，构成了列向量组的一个最大无关组，矩阵A最高阶非零子式所在的行，构成了行向量组的一个最大无关组

### 向量组解的结构

1. 齐次线性方程组解的结构$A_{mn}X=0$
   1. 若$\delta _1, \delta _2$是方程组$A_{mn}X=0$的两个解，则$\delta _1 + \delta _2$也是方程组$A_{mn}X=0$的解
   2. 若$\delta$是方程组$A_{mn}X=0$的解，则$k \delta$也是方程组$A_{mn}X=0$的解
   3. $R_A$为非自由未知量个数，n为总未知量个数，$n-R_A$为自由未知量个数
2. 基础解系
   若$\delta _1, \delta _2, \cdots , \delta _{n-R_A}$为向量组的最大无关组，则$X = k_1 \delta _2 + k_2 \delta _1 + \cdots + k_{n-R_A} \delta _{n-R_A}$为$AX = 0$的通解，$\delta _1, \delta _2, \cdots , \delta _{n-R_A}$被称为基础解系，是方程组的最大线性无关解 
3. 非齐次线性方程组解的结构$A_{mn}X=b$
   1. 令b=0，则得$A_{mn}X=0$，此方程组为该非齐次线性方程组的导出组
   2. 若$\eta _1, \eta _2$是$AX=b$的解，则$\delta = \eta _1 - \eta _2$是对应导出组的解\
   $A(\delta) = A(\eta _1 - \eta _2) = A(\eta _1) - A(\eta _2) = b - b = 0$
   3. 若$\eta$是$AX=b$的解，$\delta$是对应导出组的解，则$\eta + \delta$是$AX=b$的解
   $A(\delta + \eta) = A(\delta) + A(\eta) = b + 0 = b$

## 向量空间
是一个同维向量的集合V，其中的向量之间有加法和数乘运算，若$V_a \in V,V_b \in V$，则$a+b \in V, ka \in V$，称V为一个向量空间\
$R^2$表示2维向量空间，$R^3$表示3维向量空间\
若不满足加法或数乘运算，则不是一个向量空间

### 向量空间的基
若向量空间V又最大线性无关组，则此最大线性无关组为V的基，基中所含无关向量的个数称为V的维数

### 坐标
在$R^3$中，$\alpha = (x, y, z)^T = xi + yj + zk$，则xyz实际为ijk作为基向量时的系数\
在向量空间V下，若$\alpha _1, \alpha _2, \cdots ,\alpha _n$为V的一组基，若$x = k_1 \alpha _1 + k_2 \alpha _2 + \cdots + k_n \alpha _n$，则称$k_1, k_2, \cdots, k_n$为x在基$\alpha _1, \alpha _2, \cdots ,\alpha _n$下的坐标\
当基为各方向上的单位向量时，被称为自然基

### 过渡矩阵
对于向量空间V，有两组基$\alpha _1, \alpha _2, \cdots ,\alpha _n$与$\beta _1, \beta _2, \cdots ,\beta _n$，若$(\beta _1, \beta _2, \cdots ,\beta _n) = (\alpha _1, \alpha _2, \cdots ,\alpha _n)P$，则称P为由基$\alpha _1, \alpha _2, \cdots ,\alpha _n$到基$\beta _1, \beta _2, \cdots ,\beta _n$到过渡矩阵\
若两组基均可逆，则A->B的过渡矩阵P是B->A的过渡矩阵的逆矩阵

### 坐标变换公式
对于向量空间V，坐标X是基$\alpha _1, \alpha _2, \cdots ,\alpha _n$下的坐标，坐标Y是基$\beta _1, \beta _2, \cdots ,\beta _n$下的坐标，则$AX = BY$，因为AB可逆，所以$X = A^{-1}BY = PY, Y = B^{-1}AX = P^{-1}Y$


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
