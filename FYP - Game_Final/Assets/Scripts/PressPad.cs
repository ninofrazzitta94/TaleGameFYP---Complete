using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressPad : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 initialOffset;
    public GameObject pressPad;

    public bool Pressed = false;

    public MovingPlatform movingPlatformScript;



    bool playSound;

    private void Start()
    {
        initialOffset = gameObject.transform.position;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "PressPadInter")
        {
            Pressed = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "PressPadInter")
        {
            Pressed = false;
        }
    }

    private void Update()
    {
        if (Pressed == true)
        {
            pressPad.transform.position = gameObject.transform.position + offset;
            Pressed = true;
            movingPlatformScript.Move();
        }
        else
        {
            pressPad.transform.position = initialOffset;
            Pressed = false;
            movingPlatformScript.ReverseMove();
        }
    }
}
