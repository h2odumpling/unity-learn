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
        /// <summary>
        /// 寻找对应Component名为指定命名的Component并返回
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T findByName<T>(GameObject obj, string name) where T : Component
        {
            T[] transforms = obj.GetComponentsInChildren<T>();
            T target = null;
            foreach (T t in transforms)
            {
                if (t.name == name)
                {
                    target = t;
                    break;
                }
            }
            if (target == null)
            {
                Debug.Log("find nothing");
            }

            return target;
        }


        /// <summary>
        /// 寻找指定Component中位置与指定物体最近的Component并返回
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T findByDistance<T>(GameObject ori, GameObject obj = null) where T : Component
        {
            T[] objects;
            if (obj == null)
            {
                objects = FindObjectsOfType<T>();
            }
            else
            {
                objects = obj.GetComponentsInChildren<T>();
            }
            if (objects.Length == 0)
            {
                return null;
            }
            T target = objects[0];
            float minDistance = Vector3.Distance(ori.transform.position, target.transform.position);
            for (int i = 1; i < objects.Length; i++)
            {
                float thisDistance = Vector3.Distance(ori.transform.position, objects[i].transform.position);
                if (minDistance > thisDistance)
                {
                    minDistance = thisDistance;
                    target = objects[i];
                }
            }
            return target;
        }
    }
}