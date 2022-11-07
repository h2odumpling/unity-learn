using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomNavigation{
    /// <summary>
    /// 根据点移动的导航
    /// </summary>
    public class PointNavigation : MonoBehaviour
    {
        public GameObject WayList;  //导航路径列表
        public string WayName = "Way1";     //导航路径名称
        public int AppearPoint = 1;     //导航起始点+1
        public int Speed = 1;    //移动速度，可以从其他信息组件调用

        [HideInInspector]
        public bool IsFinished = false;     //是否完成导航

        private Transform Way;      //使用的路径
        private Transform NowTarget;    //现在朝向的目标
        private int Length;     //总路径长度

        private void Start()
        {
            Way = WayList.transform.Find(WayName);
            NowTarget = Way.GetChild(AppearPoint - 1);
            Length = Way.childCount;
            Debug.Log(Length);
            transform.position = NowTarget.position;

            LookAtNext();
            InvokeRepeating("MoveToMethod", 0, (float)0.02);
        }

        //private void Update()
        //{
        //    if (IsFinished)
        //    {
        //        CancelInvoke("Update");
        //        return;
        //    }
        //    transform.position = Vector3.MoveTowards(transform.position, NowTarget.position, Speed * Time.deltaTime);
        //    if (transform.position.Equals(NowTarget.position))
        //    {
        //        LookAtNext();
        //    }
        //}

        private void LookAtNext()
        {
            if(NowTarget.GetSiblingIndex() < Length - 1)   //当还有下一个目标时转向
            {
                NowTarget = Way.GetChild(NowTarget.GetSiblingIndex() + 1);
                transform.LookAt(NowTarget);
            }
            else
            {
                IsFinished = true;
                CancelInvoke("MoveToMethod");
                Debug.Log(IsFinished);
            }
        }

        private void MoveToMethod()
        {
            transform.position = Vector3.MoveTowards(transform.position, NowTarget.position, (float)(Speed * 0.02));
            if (transform.position.Equals(NowTarget.position))
            {
                LookAtNext();
            }
        }
    }
}
