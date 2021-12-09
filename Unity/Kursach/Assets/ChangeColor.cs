using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Texture OffLamp;
    public Texture OnLamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OnUstanovka.isOn)
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = OnLamp;
        }

        if (!OnUstanovka.isOn)
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = OffLamp;
        }
    }
}
