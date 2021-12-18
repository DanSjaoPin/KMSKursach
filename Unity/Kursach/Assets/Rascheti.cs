using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Rascheti : MonoBehaviour, IPointerClickHandler
{
    public List<InputField> diameter;
    public InputField length;
    public List<InputField> time;

    public List<Text> iN;
    public Text avgN;
    public Text deltaN;
    public Text eN;
    public List<Text> Rei;

    public void OnPointerClick(PointerEventData eventData)
    {
        //diameter[0].text = "1,61";
        //diameter[1].text = "1,23";
        //diameter[2].text = "0,91";
        //diameter[3].text = "1,14";
        //diameter[4].text = "0,7";
        //length.text = "0,1";
        //time[0].text = "2,21";
        //time[1].text = "3,32";
        //time[2].text = "3,53";
        //time[3].text = "2,96";
        //time[4].text = "4";


        try
        {
            for (int i = 0; i < 5; i++)
            {
                double res = (Math.Pow(Convert.ToDouble(diameter[i].text) * Math.Pow(10,-3), 2) * 9.81 * (7800 - 1260) * Convert.ToDouble(time[i].text)) / 18 * Convert.ToDouble(length.text);
                res = Math.Round((res * 100), 2);
                iN[i].text = res.ToString();
            }

            double avgn = (Convert.ToDouble(iN[1].text) + Convert.ToDouble(iN[2].text) + Convert.ToDouble(iN[3].text) + Convert.ToDouble(iN[4].text)) / 5;

            avgN.text = Math.Round( avgn, 2).ToString();

            double x = 0;

            for (int i = 0; i < 5; i++)
            {
                x += Math.Pow((Convert.ToDouble(iN[i].text) - Convert.ToDouble(avgN.text)), 2);
                Debug.Log("For " + x);
            }

            x = (1f / (5f * 4f)) * x;
            Debug.Log("///" + x);
            x = 2.8 * Math.Sqrt(x);
            Debug.Log("sqrt" + x);
            deltaN.text = (x).ToString();

            eN.text = ((Convert.ToDouble(deltaN.text) / Convert.ToDouble(avgN.text))*100).ToString() + "%";

            for (int i = 0; i < 5; i++)
            {
                double res = (Convert.ToDouble(length.text) * 1260) / (Convert.ToDouble(iN[i].text) * Convert.ToDouble(diameter[i].text) * Math.Pow(10, -3) * Convert.ToDouble(time[i].text));
                res = Math.Round((res), 2);
                Rei[i].text = res.ToString();
            }
        }
        catch
        {
            Console.WriteLine("Введены неккоректные данные (разрешены только запятые и числа)");
        }
    }
}
