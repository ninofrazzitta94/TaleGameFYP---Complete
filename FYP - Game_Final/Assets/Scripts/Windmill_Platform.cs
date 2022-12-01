using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill_Platform : MonoBehaviour
{

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler (0, 0, 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "PressPadInter")
        {
            collision.transform.parent = transform;
            //collision.transform.localScale = new Vector3 (1, 1, 1);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "PressPadInter")
        {
            collision.transform.parent = null;
        }
    }

}
