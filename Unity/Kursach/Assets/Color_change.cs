using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_change : MonoBehaviour
{
    Color defaultColor;

    public void HighlightObject()
    {
        defaultColor = this.GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = new Color(200, 240, 0);
    }

    public void defaultCol()
    {
        GetComponent<Renderer>().material.color = defaultColor;
    }
}
