# 单例
public class Singleton{
  static Singleton ins;
  public static Singleton ins{
    get{
      if(ins == null){
        return new Singleton();
      }else{
        return ins;
      }
    }
  }
}



# 简单工厂
public class SimpleFactory{
  public static Factory MakeProduct(string type){
    Factory factory = Null;
    switch(type){
      case 'type1':
        factory = new prod1();
        break;
      case 'type2':
        factory = new prod2();
        break;
      default:
        break;
    }
    return factory;
  }
}
public class BaseProd{
  public abstract void prod();
}
public class prod1 : BaseProd{
  public override void prod(){
    //do prod1
  }
}
public class prod2 : BaseProd{
  public override void prod(){
    //do prod2
  }
}



>> 深入学习：其他设计模式
