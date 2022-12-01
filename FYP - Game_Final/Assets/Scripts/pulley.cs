using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulley : MonoBehaviour
{
    public float xAngle;

    public MovingPlatform MovingPlatformScript;
    public PressPad PresspadScript;

    void Update()
    {
        transform.Rotate(xAngle, 0, 0, Space.Self);

        if (MovingPlatformScript.moving == true && PresspadScript.Pressed == true)
        {
            xAngle = -2;
        }
        else if ((MovingPlatformScript.moving == true && PresspadScript.Pressed == false))
        {
            xAngle = 2;
        }
        else
        {
            xAngle = 0;
        }
    }
}
