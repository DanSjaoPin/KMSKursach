using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ApplyButt : MonoBehaviour, IPointerDownHandler
{
    public Text hintN;
    public Text hint;

    public void OnPointerDown(PointerEventData eventData)
    {
        MoovingBalls.inMicroscope = false;
    }
}
