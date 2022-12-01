using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftSound : MonoBehaviour
{

    public Audio_Manager AM;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lift")
        {
            AM.Stop("Lift");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Lift")
        {
            AM.Play("Lift");
        }
    }
}
