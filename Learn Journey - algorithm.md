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
 
### 


# 算法
解决问题的思路

## 算法的评价标准
* 运行时间
* 占用空间
一般情况下运行时间和占用空间是对立的



# 冒泡
遍历数组，把最大的元素放置于数组最后，依次遍历
复杂度 O(n^2)
```
void function Pop (int[] _arr){
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



# 选择排序
O(n^2)，当n比较小，快于冒泡
```
void function Selection (int[] _arr){
  int i,j,min,temp;
  for(i = 0; i < _arr.Length - 1; i++){
    min = i;
    for(j = i+1; j < _arr.Length; j++){
      if(_arr[min] > _arr[j]){
        min = j;
      }
    }
    temp = _arr[min];
    _arr[min] = _arr[i];
    _arr[i] = temp;
  }
}
```



# 插入排序
O(1)，当n比较小时比较适用
```
void function Insert (int[] _arr){
  int i,j,temp;
  for(i = 1; i < _arr.Length; i++;){
    temp = _arr[i];
    for(j = i-1; j >= 0; j--){
      if(temp > _arr[j]){
        _arr[j+1] = _arr[j];
        _arr[j] = _arr[temp];
      }
    }
  }
}
```



# 二分查找
必须在有序队列中进行
```
int function Quick(int[] _arr, int tar){
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







