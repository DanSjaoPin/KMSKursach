using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtDown : MonoBehaviour
{
    public float speed = 0.01f;
    public static bool isDown = false;
    public static bool GO = false;
    public TextMeshPro textmeshPro;
    public static float seconds = 0f;

    void Awake()
    {
        Application.targetFrameRate = -2;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            transform.position += new Vector3(0, -0.2f, 0);
            isDown = true;
            if (MoovingBalls.isReady)
                GO = true;
        }

        if (OnUstanovka.isOn && isDown)
        {
            if (seconds < 10)
                textmeshPro.SetText("0" + string.Format("{0:N2}", seconds));
            else if (seconds >= 100)
                seconds = 0f;
            else
                textmeshPro.SetText(string.Format("{0:N2}", seconds));
            seconds += Time.deltaTime;   
        }     

        if (Input.GetKeyUp("space"))
        {
            transform.position = transform.position + new Vector3(0, 0.2f, 0);
            isDown = false;
        }
    }
}
