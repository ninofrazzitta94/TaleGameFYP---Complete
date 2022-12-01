using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFragmentManager : MonoBehaviour
{
    public DoorOpeningFragments doorOpeningScript;

    public Audio_Manager AM;

    public float PitchValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.name == "Girl")
        {
            PitchValue = AM.sounds[4].source.pitch + 0.35f;

            AM.sounds[4].source.pitch = PitchValue;
            AM.Play("PickUpS");

            doorOpeningScript.KeyFragments += 1;

            gameObject.GetComponentInChildren<Collider>().enabled = false;

            gameObject.GetComponentInChildren<crystal_follow>().enabled = true;
        }
    }
}
