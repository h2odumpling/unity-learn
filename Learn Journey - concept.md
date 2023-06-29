# 短路求值
一个布尔表达式左侧如果为false则直接返回false，不进行下一个布尔求值

# 虚悬引用
引用在方法结束后不存在的值，在c#中无法编译
```
public int doSomething(){
    int i = 0;
    return ref i;
}
```