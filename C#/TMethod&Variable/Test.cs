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
            int z = 0;
            var re = Method.genu(z);
            Console.WriteLine(re);
        }

    }

    class Method
    {
        public static string meth<T>(string str)
        {
            Type t = typeof(T);
            return t.ToString()+"-"+str;
        }
        public static object genu(object c)
        {
            string className = c.GetType().FullName;
            Type t = Type.GetType(className);
            var method = Type.GetType("Test.Method").GetMethod("meth").MakeGenericMethod(new Type[] { t });
            return method.Invoke(null, new object[] { "hello" });
        }
    }
}
