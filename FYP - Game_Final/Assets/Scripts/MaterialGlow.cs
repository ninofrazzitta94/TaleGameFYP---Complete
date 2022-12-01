using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialGlow : MonoBehaviour
{

    public Animator MaterialAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            MaterialAnimator.SetBool("Set", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            MaterialAnimator.SetBool("Set", false);
        }
    }
}
