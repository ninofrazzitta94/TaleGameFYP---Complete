using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBox : MonoBehaviour
{

    private Rigidbody rb;
    public float force;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            rb.drag = 2;
        }
    }
}
