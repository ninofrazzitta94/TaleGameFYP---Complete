using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialGlowFinal : MonoBehaviour
{

    public Animator MaterialAnimator;

    public bool boyCollided;
    public bool GirlCollided;

    private void Update()
    {
        if (boyCollided && GirlCollided)
        {
            MaterialAnimator.SetBool("Set", true);
        }
        else
        {
            MaterialAnimator.SetBool("Set", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            boyCollided = true;
        }
        if (other.gameObject.name == "Girl")
        {
            GirlCollided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            boyCollided = false;
        }
        if (other.gameObject.name == "Girl")
        {
            GirlCollided = false;
        }
    }
}
