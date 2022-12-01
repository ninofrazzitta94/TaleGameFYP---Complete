using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActivator : MonoBehaviour
{
    public CameraFollow cameraFollowScript;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            cameraFollowScript.enabled = true;
        }
    }

}
