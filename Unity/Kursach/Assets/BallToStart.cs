using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallToStart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public static bool ToStart;

    public Text hintN;
    public Text hint;

    public void OnPointerDown(PointerEventData eventData)
    {
        ToStart = true;
        ButtDown.GO = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!OnUstanovka.isOn)
        {
            hintN.text = "Действие 1";
            hint.text = "Включите блок питания установки (нажмите на тумблер)";
        }
        else
        {
            hintN.text = "Действие 2";
            hint.text = "Переместите шарик на предметный столик (кликните на шарик)";
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ToStart = false;
    }
}
