using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    Transform target;
    private float rotationSpeed = 500.0f;
    Vector3 lookPoint;
    public static float scrollCount = 0f;
    public static float UpDownCount = 0f;
    private float scrollBorder = 30f;
    private float UpDownBorder = 8f;
    public static bool isDefoultPosition = true;

    // Start is called before the first frame update
    void Start()
    {
        lookPoint = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefoultPosition)
        {
            if (Input.GetMouseButton(1))
            {
                transform.RotateAround(lookPoint, Vector3.up, Time.deltaTime * rotationSpeed * Input.GetAxis("Mouse X"));
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0 && scrollCount > -scrollBorder - 1f)
            {
                float scroll = Input.GetAxis("Mouse ScrollWheel");

                transform.Translate(0, 0, 0.5f);
                scrollCount--;
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0 && scrollCount < scrollBorder - 10f)
            {
                float scroll = Input.GetAxis("Mouse ScrollWheel");

                transform.Translate(0, 0, -0.5f);
                scrollCount++;
            }

            if (Input.GetKey(KeyCode.E) && UpDownCount < UpDownBorder)
            {
                transform.Translate(0, 0.1f, 0);
                UpDownCount += 0.2f;
            }

            if (Input.GetKey(KeyCode.Q) && UpDownCount > -UpDownBorder)
            {
                transform.Translate(0, -0.1f, 0);
                UpDownCount -= 0.2f;
            }
        }
    }
}
