using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public DoorOpeningFragments doorOpeningScript;

    public Audio_Manager AM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "Girl")
        {
            gameObject.GetComponentInChildren<Collider>().enabled = false;

            gameObject.GetComponentInChildren<crystal_follow>().enabled = true;

            doorOpeningScript.KeyFragments = 6;

            AM.sounds[4].source.pitch = 0.5f;
            AM.Play("PickUpS");
        }
    }
}
