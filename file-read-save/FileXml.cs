using System.Xml;
using UnityEngine;
using System.Reflection;
using System;

public class FileXml : DataTypeFactory
{
    public new string path = @"D:\Unity Project\CommonTemp\dataXml.xml";

    public override void Write(Data data)
    {
        Debug.Log(JsonUtility.ToJson(data));

        XmlDocument xml = new XmlDocument();
        XmlElement root = xml.CreateElement("Data");
        XmlElement part;

        FieldInfo[] fileds = data.GetType().GetFields();

        for (int i = 0; i < fileds.Length; i++)
        {
            Debug.Log(fileds[i].Name);
            Debug.Log(fileds[i].GetValue(data));

            //for (int j = 0; j < fileds[i].GetValue(data).GetType().GetFields().Length; j++)
            //{
            //    Debug.Log(j);
            //}

            part = xml.CreateElement(fileds[i].Name);

            if (fileds[i].Name == "person")
            {
                for (int j = 0; j < data.person.Length; j++)
                {
                    XmlElement p = xml.CreateElement("p" + Convert.ToString(j));
                    p.SetAttribute("name", data.person[j].name);
                    p.SetAttribute("age", Convert.ToString(data.person[j].age));
                    part.AppendChild(p);
                }
            }

            root.AppendChild(part);
        }
        xml.AppendChild(root);
        xml.Save(path);

    }

    public override Data Read()
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(path);
        XmlNodeList xmlNodeList = xml.SelectSingleNode("Data").ChildNodes;
        Data data = new Data();
        foreach (XmlNode xmlNode in xmlNodeList)
        {
            if(xmlNode.Name == "person")
            {
                data.person = new Person[xmlNode.ChildNodes.Count];
                int i = 0;
                foreach(XmlNode xmlNode2 in xmlNode.ChildNodes)
                {
                    Person p = new Person();
                    p.name = xmlNode2.Attributes["name"].Value;
                    p.age = int.Parse( xmlNode2.Attributes["age"].Value);
                    data.person[i] = p;
                    i++;
                }
            }
        }
        return data;
    }
}
