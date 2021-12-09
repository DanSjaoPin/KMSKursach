using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnUstanovka : MonoBehaviour
{
    public static bool isOn = false;
    public TextMeshPro textmeshPro;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (!isOn)
        {
            transform.rotation *= Quaternion.Euler(0, -30f, 0);
            isOn = true;
            textmeshPro.SetText("00,00");
        }
        else
        {
            transform.rotation *= Quaternion.Euler(0, 30f, 0);
            isOn = false;
            textmeshPro.SetText("");
            ButtDown.seconds = 0f;
        } 
    }
}
