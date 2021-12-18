using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoovingBalls : MonoBehaviour
{
    public static Vector3 startPosition, needPosition;

    public Text hintN;
    public Text hint;

    public static Vector3 defaultPosition = new Vector3(1.151f, -19.295f, -4.2358f);
    public static int MoovingCount = 0;
    float speed = 0.05f;
    float speedFall = 0.000009f;
    float offset = 0;
    public static bool inMicroscope;
    public static bool isReady = false;

    void Start()
    {
        startPosition = transform.position;
    }

    public void OnMouseDown()
    {
        MoovingCount++;
    }

    void Update()
    {
        if (transform.position == new Vector3(1.2731f, -14.59f, -4.273f))//шарик в воздухе
        {
            MoovingCount = 2;
            startPosition = transform.position;
            offset = 0;
        }
        if (transform.position == new Vector3(5.161f, -15.84f, -7.83f) && MoovingCount != 4)//шарик в микроскопе
        {
            MoovingCount = 3;
            startPosition = transform.position;
            offset = 0;
            hintN.text = "Действие 3";
            hint.text = "Нажимая Left и Right сместите бок шарика с 0, замерьте его диаметр и занесите значения в таблицу. Нажмите Apply и кликом перенесите шарик в колбу";
        }
        if (transform.position == new Vector3(-11.52f, -9.08f, -8.695f))//шарик над колбой
        {
            MoovingCount = 5;
            startPosition = transform.position;
            offset = 0;
        }
        if (transform.position == new Vector3(-11.52f, -11.515f, -8.695f))//шарик готов
        {
            MoovingCount = 6;
            startPosition = transform.position;
            offset = 0;
            isReady = true;
        }

        if (MoovingCount == 1)//запуск шарика
        {
            needPosition = new Vector3(1.2731f, -14.59f, -4.273f);
            offset += speed;
            transform.position = Vector3.Lerp(startPosition, needPosition, offset);
        }
        else if (MoovingCount == 2)//шарик в микроскопе
        {
            needPosition = new Vector3(5.161f, -15.84f, -7.83f);
            offset += speed;
            transform.position = Vector3.Lerp(startPosition, needPosition, offset);
            inMicroscope = true;
        }
        else if (MoovingCount == 4)//шарик над колбой
        {
            inMicroscope = false;
            needPosition = new Vector3(-11.52f, -9.08f, -8.695f);
            offset += speed;
            transform.position = Vector3.Lerp(startPosition, needPosition, offset);
            startPosition = transform.position;
        }
        else if (MoovingCount == 5)//шарик в колбе
        {
            needPosition = new Vector3(-11.52f, -11.515f, -8.695f);
            offset += speed;
            transform.position = Vector3.Lerp(startPosition, needPosition, offset);
            startPosition = transform.position;
            hintN.text = "Действие 4";
            hint.text = "Нажмите пробел для запуска секундомера. Замерьте время падения шарика и внесите в таблицу.";
        }
        else if (isReady == true && ButtDown.GO == true)//шарик ПАДАЕТ
        {
            startPosition = transform.position;
            needPosition = new Vector3(-11.52f, -18.92f, -8.695f);
            offset += speedFall;
            transform.position = Vector3.Lerp(startPosition, needPosition, offset);
            hintN.text = "Действие 5";
            hint.text = "После завершения падения нажмите кнопку \"Переместить шарик в баночку\". Сбросьте значение секундомера нажав на тумблер.";
        }

        if (BallToStart.ToStart == true)
        {
            MoovingCount = 0;

            transform.position = defaultPosition;
            startPosition = defaultPosition;

            isReady = false;
            inMicroscope = false;
        }
    }
}
