using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDropSound : MonoBehaviour
{
    public Audio_Manager AM;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "BoxTrigger")
        {
            AM.Play("BoxDrop");
            Debug.Log("Collision");
        }
    }
}
