using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBalls : MonoBehaviour
{
    public static bool Move1 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (!Move1)
        {
            transform.position += new Vector3(0, 3f, 0);
            Move1 = true;
        }
    }
}
