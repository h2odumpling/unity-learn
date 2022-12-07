using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Default{
    /// <summary>
    /// 
    /// </summary>
    public class Test : MonoBehaviour,IDragHandler,IPointerDownHandler
    {
        private RectTransform rectTransform;
        private RectTransform parentRTF;
        public Vector2 screenPosition;

        public Vector3 position;

        private void Start()
        {
            parentRTF = transform.parent as RectTransform;
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 worldPoint;
            //屏幕坐标
            RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRTF, eventData.position + screenPosition, eventData.pressEventCamera, out worldPoint);
            transform.position = worldPoint;
            //世界坐标
            RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRTF, eventData.position, eventData.pressEventCamera, out worldPoint);
            transform.position = worldPoint + position;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //以下通过两种方式同步轴心点的位置

            //转换屏幕坐标获取点击时的偏移量
            Vector3 pp = eventData.enterEventCamera.WorldToScreenPoint(rectTransform.position);
            screenPosition = new Vector2(pp.x, pp.y) - eventData.pressPosition;

            //计算点击时的世界坐标到ui世界坐标的偏移量
            RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRTF, eventData.position, eventData.pressEventCamera, out position);
            position = transform.position - position;
        }
    } 
}