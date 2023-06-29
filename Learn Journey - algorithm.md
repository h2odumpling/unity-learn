# 数据结构
数据在程序中的存储结构，是问题的核心，算法的基础

* 集合
* 线性结构
* 树状结构
* 图状结构

## 线性表
* 是线性结构的一种
* 一个接着一个排列
比如List,Array

### 顺序表
* 在内存中，用一块连续的内存空间存放线性表中的元素，表中相邻的元素在内存中的存储空间也是相邻的。
* 只要知道顺序表的基地址（0号元素的存放位置）和每个元素所占存储单元的个数就可以求出顺序表中任意一个数据元素的存储地址。
比如数组
 
### 链表
* 单个元素至只储值和下一个元素的索引
* 链表只保存首元素的索引，每次都要从首元素开始遍历
* 多链表 还在元素中存放上一个元素的索引
* 循环链表 尾元素指向首元素

### 队列
* 一种特殊的线性表
* 先进先出
* 有顺序队列和链队列

### 栈
* 一种特殊的线性表
* 后进先出
* 有顺序栈和堆栈


# 算法
解决问题的思路

## 算法的评价标准
* 时间复杂度：运行时间，一般与循环次数成正比，2次循环就是n^2
* 空间复杂度：占用空间
一般情况下运行时间和占用空间是对立的\
时间复杂度



# 冒泡
遍历数组，把最大的元素放置于数组最后，依次遍历\
复杂度 O(n^2)\
```
void static Pop (int[] _arr){
  int i,j,temp;
  for(i = 0; i < _arr.Length - 1; i++){
    for(j = i+1; j < _arr.Length; j++){
      if(_arr[i] > _arr[j]){
        temp = _arr[i];
        _arr[i] = _arr[j];
        _arr[j] = temp;
      }
    }
  }
}
```
冒泡排序优化
```
private void Main()
{
    Emp e1 = new Emp("z", 10);
    Emp e2 = new Emp("a", 12);
    Emp e3 = new Emp("b", 125);
    Emp e4 = new Emp("c", 212);
    Emp e5 = new Emp("d", 2);
    Emp e6 = new Emp("e", 1112);


    Emp[] empList = new Emp[] {e1,e2,e3,e4,e5,e6};

    Pop<Emp>(empList, Emp.compare);

    for(int i = 0; i < empList.Length - 1; i++)
    {
        Console.WriteLine(empList[i]);
    }
}

class Emp
{
    private string name;
    private int age;
    public Emp(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public static bool compare(Emp e1, Emp e2)
    {
        return e1.age > e2.age;
    }
}

public T[] Pop<T>(T[] arr,Func<T,T,bool> compareMethod)
{
    bool has_change;
    has_change = false;
    do
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (compareMethod(arr[i], arr[i + 1]))
            {
                var temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
                has_change = true;
            }
        }
    } while (has_change == true);
    return arr;
}
```



# 二分查找
log(n)\
必须在有序队列中进行\
```
int static Quick(int[] _arr, int tar){
  int left = 0;
  int right = _arr.Length;
  int mid = 0;
  while(left <= right){
    mid = (left + right) /2;
    if(_arr[mid] == tar){
      return mid;
    }else if(_arr[mid] > tar){
      right = mid - 1;
    }else{
      left = mid + 1;
    }
  }
  return -1;
}
```



# 插入排序
O^1~O^2\
遍历数组，每次排序0~i的元素，0~i-1的元素是有序的，实际去查找i元素的位置，若有j位置的元素小于（升序时）i位置的元素，则i的位置在j+1处即可结束本次循环开始下一次循环\
```
//不创建新数组
static int[] insertSort(int[] ints)
{
    int temp;
    for (int i = 0; i < ints.Length; i++)
    {
        temp = ints[i];
        if (i > 0)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (ints[j] > temp)
                {
                    ints[j + 1] = ints[j];
                    ints[j] = temp;
                }
                else
                {
                    break;
                }
            }
        }
    }
    return ints;
}
//创建新数组的情况下，遍历原数组，从后往前遍历新数组，若新数组元素大于原数组元素则后移一位，直至将原数组元素插入新数组中
static int[] newInsertSort(int[] ints)
{
    int[] result = new int[ints.Length];
    for (int i = 0; i < ints.Length; i++)
    {
        result[i] = ints[i];
        if (i > 0)
        {    
            for(int j = i - 1; j>=0; j--)
            {
                if (j == 0)
                {
                    result[j] = ints[i];
                    break;
                }
                if (result[j] > ints[i])
                {
                    result[j + 1] = result[j];
                    result[j] = ints[i];
                }
                else
                {
                    break;
                }
            }
        }
    }
    return result;
}
```



# 选择排序
O(n^2)，当n比较小，快于冒泡\
循环遍历原数组，每次取出最小或最大的值\
```
static int[] chooseSort(int[] ints)
{
    int temp;
    int min;
    int indexMin;
    for(int i = 0; i < ints.Length-1; i++)
    {
        min = ints[i];
        indexMin = i;
        for(int j = i+1; j< ints.Length; j++)
        {
            if (ints[j] < min)
            {
                min = ints[j];
                indexMin = j;
            }
        }
        if(indexMin == i)
        {
            break; 
        }
        temp = ints[i];
        ints[i] = min;
        ints[indexMin] = temp;
    }
    return ints;
}
```



# 快速排序
O(nlog(n))~O(n^2)
因速度及性能在各类排序方法中较好，固较为常用\
从数组中取出第一位数x，首位索引l，末尾索引r，先从后往前遍历，将小于x的数y放于x的位置，再从前往后遍历，将大于x的值z放于y处，循环此过程直到l=r则把x的值插入此处，此时x左边都是小于x的数，x右边都是大于x的数\
按同样方法处理x左边的数及右边的数，递归得出最后的排序\

```
static int[] quickSort(int[] ints, int left, int right)
{
    if(left >= right)
    {
        return ints;
    }

    int x = ints[left];
    int i = left;
    int j = right;
    while(i < j)
    {
        while (i < j)
        {
            if (ints[j] <= x)
            {
                ints[i] = ints[j];
                break;
            }
            j--;
        }

        while(i < j)
        {
            if(ints[i] > x)
            {
                ints[j] = ints[i];
                break;
            }
            i++;
        }
    }
    ints[i] = x;
    quickSort(ints, left, i - 1);
    quickSort(ints, i + 1, right);

    return ints;
}
```



# 中文分词算法
一般用作全文索引搜索时使用\

## n元分词法
把数据按n字符长度进行切割\
比如："中国人在中国" 会分词为 中国 国人 人在 在中\

## mmseg分词法
基于统计学，对词库进行分析和数学归纳\
而中文因为没有分界会导致明显歧义，因此还要引入歧义解决方法\

### chunk
表示分词方式，包括词条数组和歧义解决规则\

#### 词条数组
将数据分为词条数组，然后交给歧义解决规则进行筛选\
"研究生命"可以分词为"研究生/命"、"研究/生命"\

#### 歧义解决规则
以下规则依次进行进行，最后筛选出最优的词条数组作为分词结果\
* 最大匹配
匹配最长的长度\
"国际化"会选择为"国际化"而非"国际/化"
* 最大平均长度
匹配平均词最大的词条数组\
"南京市长江大桥"可匹配"南京市/长江大桥"、"南京/市长/江大桥"，7/2 > 7/3 选前者\
* 最小方差
选择方差最小的词条数组\
"研究生命科学"可匹配"研究/生命/科学"、"研究生/命/科学"，选前者\
* 最大单字自由
选择单字出现频率最高的词条数组\
"主要是因为"可匹配"主要/是/因为"、"主/要是/因为"，而单字是"是"的出现频率高，因此选前者\

## CRF|HMM
运用概率统计及机器学习的分词法\
优势：\
对未登录词汇的识别效果好\
劣势：\
实现复杂\



# 文本相似度算法
## BM25