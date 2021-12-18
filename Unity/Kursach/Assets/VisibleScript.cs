using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibleScript : MonoBehaviour
{
    public GameObject Ochko;
    public GameObject Sharic;
    public static bool isVisible;
    public static int count = 0;

    public static bool refresh = false;

    void Update()
    {
        if (!MoovingBalls.inMicroscope)
        {
            Ochko.SetActive(false);
            count = 0;
        }
        else if (MoovingBalls.inMicroscope && count == 0)
        {
            Ochko.SetActive(true);
            refresh = true;
            count = 1;
        }
    }
}
