using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButt : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool isDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }
}
