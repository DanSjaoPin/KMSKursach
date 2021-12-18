using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnUstanovka : MonoBehaviour
{
    public static bool isOn = false;
    public TextMeshPro textmeshPro;
    public Text hintN;
    public Text hint;

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
            hintN.text = "Действие 2";
            hint.text = "Переместите шарик на предметный столик (кликните на шарик)";
        }
        else
        {
            transform.rotation *= Quaternion.Euler(0, 30f, 0);
            isOn = false;
            textmeshPro.SetText("");
            ButtDown.seconds = 0f;
            hintN.text = "Действие 1";
            hint.text = "Включите блок питания установки (нажмите на тумблер)";
        } 
    }
}
