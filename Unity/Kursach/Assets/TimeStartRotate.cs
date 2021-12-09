using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeStartRotate : MonoBehaviour
{
    private bool isRotate = false;
    public TextMeshPro textmeshPro;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && isRotate == false && OnUstanovka.isOn)
        {
            transform.rotation *= Quaternion.Euler(0f, 0, -180f);
            isRotate = true;
        }
    }

    public void OnMouseDown()
    {
        if (isRotate == true && !ButtDown.isDown)
        {
            transform.rotation *= Quaternion.Euler(0f, 0, 180f);
            isRotate = false;
            if (OnUstanovka.isOn)
                textmeshPro.SetText("00,00");
            ButtDown.seconds = 0f;
        }
    }
}
