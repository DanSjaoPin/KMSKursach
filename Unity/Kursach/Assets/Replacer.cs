using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacer : MonoBehaviour
{
    public List<Transform> objectsForLook;
    bool move = false;
    Vector3 startPosition, needPosition;
    float speed = 0.01f;
    float offset = 0;
    Quaternion startRotation, needRotation;

    public void Default()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = objectsForLook[0].position;
            needRotation = objectsForLook[0].rotation;
            Move.isDefoultPosition = true;
        }
    }

    public void Kolba()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = objectsForLook[1].position;
            needRotation = objectsForLook[1].rotation;
            Move.isDefoultPosition = false;
        }
    }

    public void Stoyka()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = objectsForLook[2].position;
            needRotation = objectsForLook[2].rotation;
            Move.isDefoultPosition = false;
        }
    }

    public void Knopka()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = objectsForLook[3].position;
            needRotation = objectsForLook[3].rotation;
            Move.isDefoultPosition = false;
        }
    }

    public void Sekundomer()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = objectsForLook[4].position;
            needRotation = objectsForLook[4].rotation;
            Move.isDefoultPosition = false;
        }
    }

    public void BP()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = objectsForLook[5].position;
            needRotation = objectsForLook[5].rotation;
            Move.isDefoultPosition = false;
        }
    }

    public void Banochka()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = objectsForLook[6].position;
            needRotation = objectsForLook[6].rotation;
            Move.isDefoultPosition = false;
        }
    }

    public void Mikroscope()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = objectsForLook[7].position;
            needRotation = objectsForLook[7 ].rotation;
            Move.isDefoultPosition = false;
        }
    }

    public void Stolic()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = objectsForLook[8].position;
            needRotation = objectsForLook[8].rotation;
            Move.isDefoultPosition = false;
        }
    }

    public void Baraban()
    {
        if (!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = objectsForLook[9].position;
            needRotation = objectsForLook[9].rotation;
            Move.isDefoultPosition = false;
        }
    }
        
    void Update()
    {
        if (move)
        {
            offset += speed;
            transform.position = Vector3.Lerp(startPosition, needPosition, offset);
            transform.rotation = Quaternion.Slerp(startRotation, needRotation, offset);
            if(offset >= 1)
            {
                move = false;
                offset = 0;
            }
        }
    }
}
