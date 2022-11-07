using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper{
    /// <summary>
    /// 时间帮助类，倒计时
    /// </summary>
    /// timeDown = new TimeHelper(120, 1);
    /// if (timeDown.timeDown())
    /// {
    ///     trigger();
    ///     if (timeDown.Finish)
    ///         finalTrigger();
    /// }
    class TimeHelper
    {
        private float totalTime;
        private float split;

        private float nowTime;
        private float deltaTotal = 0;
        private float nextTime;
        private bool finish = false;

        //倒计时剩余时间
        public float NowTime
        {
            get { return nowTime; }
        }
        //倒计时完成状态
        public bool Finish
        {
            get { return finish; }
        }


        public TimeHelper(float totalTime, float split = 1)
        {
            this.totalTime = this.nowTime = totalTime;
            this.split = this.nextTime = split;
        }

        public bool deltaDown()
        {
            if (Finish)
            {
                return false;
            }
            deltaTotal += Time.deltaTime;
            if (deltaTotal >= split)
            {
                task();
                return true;
            }
            return false;
        }

        public bool timeDown()
        {
            if (Finish)
            {
                return false;
            }
            if (Time.time >= nextTime)
            {
                task();
                return true;
            }
            return false;
        }

        private void task()
        {
            nextTime += split;
            nowTime -= split;
            if (nowTime <= 0)
            {
                finish = true;
            }
        }
    }
}
