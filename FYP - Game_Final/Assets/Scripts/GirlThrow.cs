using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlThrow : MonoBehaviour
{
    public Vector3 impulse = new Vector3(5.0f, 0.0f, 0.0f);

    public bool push = true;

    void FixedUpdate()
    {
        if (push)
        {
            GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
            push = false;
        }
    }
}
