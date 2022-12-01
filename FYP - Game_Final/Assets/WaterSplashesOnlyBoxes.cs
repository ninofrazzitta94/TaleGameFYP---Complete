using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplashesOnlyBoxes : MonoBehaviour
{
    public GameObject RipplePart;

    public Audio_Manager AM;

    float pitchValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Box")
        {
            GameObject SplashPartClone = Instantiate(RipplePart, other.transform.position, RipplePart.transform.rotation);
            SplashPartClone.SetActive(true);

        }

        if (other.gameObject.name == "Box")
        {
            AM.sounds[8].source.pitch = 1f;

            AM.Play("Splash");
        }
    }
}
