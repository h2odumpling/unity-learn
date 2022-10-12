using Microsoft.VisualBasic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Test
{
    class Program
    {
        static void Main()
        {

            MyList<int> list = new MyList<int>();

            list.Add(10);
            list.Add(20);
            list.Add(130);
            list.Add(10);
            list.Add(140);
            list.Add(150);
            list.Add(160);
            list.Add(170);
            list.Add(180);
            list.Add(190);

            list.Sort();

            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

    }

    class MyList<T> where T:IComparable
    {
        private T[] array;

        private int count = 0;  //数组元素个数

        public MyList()
        {
            array = new T[0];
        }

        public MyList(T[] array){
            this.array = array;
            count = array.Length -1;
        }

        public MyList(int length)
        {
            this.array = new T[length];
        }

        public T this[int index]
        {
            get { return array[index]; }        //索引不存在时报错
            set {
                array[index] = value; 
            }
        }

        public int Capacity { get { return array.Length; } }

        public void Add(T value)
        {
            grow(count +1);
            array[count] = value;
            count++;
        }

        public void Insert(T value, int index)
        {
            count++;
            grow(count);
            for(int i= count+1; i>index; i--)
            {
                array[i] = array[i-1];
            }
            array[index] = value;
        }

        public int Count
        {
            get { return count; }
        }

        public void RemoveAt(int index)
        {
            for(int i = index; i < Count; i++)
            {
                array[i] = array[i + 1];
            }
            count--;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Sort()
        {
            for(int i = 0; i < count -1; i++)
            {
                for(int j = i+1; j < count; j++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        //这个方法用于数组扩容
        public void grow(int length)
        {
            int ord_length = array.Length;
            if(ord_length < length)
            {
                var temp = array;

                if(ord_length == 0)
                {
                    ord_length = 4;
                }

                while(ord_length < length)
                {
                    ord_length = ord_length * 2;
                }
                array = new T[ord_length];
                Array.Copy(temp, 0, array, 0, temp.Count());
            }
        }
    }
}
