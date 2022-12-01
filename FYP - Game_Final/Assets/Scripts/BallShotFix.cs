using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShotFix : MonoBehaviour
{

    public TrowBall ballOtherball;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            ballOtherball.CursorActivator = true;
        }
    }


}
