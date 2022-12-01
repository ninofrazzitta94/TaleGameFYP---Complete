using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplashes : MonoBehaviour
{
    public GameObject SplashPart;

    public Audio_Manager AM;

    public AudioSource NormalAmbience;
    public AudioSource UnderwaterAmbience;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject SplashPartClone = Instantiate(SplashPart, other.transform.position, SplashPart.transform.rotation);
            SplashPartClone.SetActive(true);

            AM.sounds[8].source.pitch = 1.5f;


            AM.Play("Splash");

            NormalAmbience.enabled = false;
            UnderwaterAmbience.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject SplashPartClone = Instantiate(SplashPart, other.transform.position, SplashPart.transform.rotation);
            SplashPartClone.SetActive(true);

            AM.sounds[8].source.pitch = 2f;


            AM.Play("Splash");

            NormalAmbience.enabled = true;
            UnderwaterAmbience.enabled = false;
        }
    }
}
