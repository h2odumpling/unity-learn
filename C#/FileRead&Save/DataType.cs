using Unity.VisualScripting;

public class DataType
{

    public string path = @"D:\Unity Project\CommonTemp\data"; 

    [System.Serializable]
    public class Person
    {
        public string name;
        public int age;
    }
    [System.Serializable]
    public class Data
    {
        public Person[] person;
    }

    public static Data initData()
    {
        Data init_data = new Data();
        init_data.person = new Person[3];
        Person p1 = new Person();
        p1.name = "a";
        p1.age = 11;
        init_data.person[0] = p1;
        Person p2 = new Person();
        p2.name = "b";
        p2.age = 12;
        init_data.person[1] = p2;
        Person p3 = new Person();
        p3.name = "c";
        p3.age = 13;
        init_data.person[2] = p3;

        return init_data;
    }
}
