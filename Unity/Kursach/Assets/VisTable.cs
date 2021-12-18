using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VisTable : MonoBehaviour, IPointerClickHandler
{
    public GameObject Table;
    public static bool isVisible = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        isVisible = !isVisible;
    }

    void Update()
    {
        if (!isVisible)
        {
            Table.SetActive(false);
        }
        else if (isVisible)
        {
            Table.SetActive(true);
        }
    }
}
