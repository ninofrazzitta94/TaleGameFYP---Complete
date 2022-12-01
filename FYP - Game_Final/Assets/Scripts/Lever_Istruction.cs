using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Istruction : MonoBehaviour
{

    public DestroyPlatform DestroyScript;
    public Animator UI_E_Animator;

    private void OnTriggerEnter(Collider other)
    {
        if (DestroyScript.Interacted == false)
        {
            UI_E_Animator.SetBool("Fade", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UI_E_Animator.SetBool("Fade", false);
    }
}
