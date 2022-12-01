using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSplashSounds : MonoBehaviour
{
    public Audio_Manager AM;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            AM.sounds[8].source.volume = 0.2f;
        }
    }
}
