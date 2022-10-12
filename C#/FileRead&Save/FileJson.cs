using System.IO;
using UnityEngine;

public class FileJson : DataTypeFactory
{
    public override void Write(Data data)
    {
        string json = JsonUtility.ToJson(data);

        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(json);
            sw.Close();
        }
    }

    public override Data Read()
    {
        using (StreamReader sr = new StreamReader(path))
        {
            string data = sr.ReadToEnd();
            sr.Close();
            return JsonUtility.FromJson<Data>(data);
        }
    }
}
