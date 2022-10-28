using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    /// <summary>
    /// 查找物体组件
    /// </summary>
    public class FindComponent
    {
        public static T findByName<T>(GameObject obj, string name) where T : Component
        {
            T[] transforms = obj.GetComponentsInChildren<T>();
            T target = default(T);
            foreach (T t in transforms)
            {
                if (t.name == name)
                {
                    target = t;
                    break;
                }
            }
            if (target == default(T))
            {
                Debug.Log("find nothing");
            }

            return target;
        }
    }
}