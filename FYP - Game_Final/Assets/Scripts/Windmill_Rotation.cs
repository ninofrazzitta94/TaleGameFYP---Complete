using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill_Rotation : MonoBehaviour
{

    public float speed;
    public bool activate;

    public Ball_Container BallContainerScript;

    public AudioSource WindMillSounds;

    void FixedUpdate()
    {
        if (BallContainerScript.InSocket)
        {
            activate = true;
            WindMillSounds.enabled = true;
        }
        else
        {
            activate = false;
            WindMillSounds.enabled = false;
        }

        if (activate)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }
}
