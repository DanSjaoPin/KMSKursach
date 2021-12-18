using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingUIBalls : MonoBehaviour 
{
    RectTransform SharicTransform;
    float LeftBorder = 205f;
    float RightBorder = 200f;
    System.Random rand = new System.Random();
    int randSharicSize = 50;
    int randSetkaXPos = 0;

    public void Start()
    {
        SharicTransform = GetComponent<RectTransform>();

        randSharicSize += rand.Next(-12, 12);
        SharicTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, randSharicSize);
        SharicTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, randSharicSize);

        randSetkaXPos += rand.Next(-150, 150);
        float deltapos = randSetkaXPos;
        SharicTransform.anchoredPosition += new Vector2(deltapos, 0);
    }

    void Update()
    {
        if (VisibleScript.refresh && VisibleScript.count == 1)
        {
            SharicTransform = GetComponent<RectTransform>();

            randSharicSize = 50;
            randSetkaXPos = 0;

            randSharicSize += rand.Next(-15, 15);
            SharicTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, randSharicSize);
            SharicTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, randSharicSize);

            randSetkaXPos += rand.Next(-250, 250);
            float deltapos = randSetkaXPos;
            SharicTransform.anchoredPosition += new Vector2(deltapos, 0);

            VisibleScript.refresh = false;
            VisibleScript.count++;
        }
        if (RightButt.isDown && SharicTransform.anchoredPosition.x <= RightBorder)
        {
            SharicTransform.anchoredPosition += new Vector2(1f, 0);
        }
        if (LeftButt.isDown && SharicTransform.anchoredPosition.x >= -LeftBorder)
        {
            SharicTransform.anchoredPosition += new Vector2(-1f, 0);
        }
    }
}
