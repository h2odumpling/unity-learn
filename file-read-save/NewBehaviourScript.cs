using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //FileWriteReader.factory("xml").Write(DataType.initData());

        DataType.Data d = FileWriteReader.factory("xml").Read();
        Debug.Log(JsonUtility.ToJson(d));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
