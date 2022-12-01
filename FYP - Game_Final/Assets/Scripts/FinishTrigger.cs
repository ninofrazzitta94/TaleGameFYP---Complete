using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public Girl_Interaction Girl_InteractionScript;
    public Animator GirlAnimator;

    public bool Activated; 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Activated = true;
        }

        if (Activated)
        {
            Girl_InteractionScript.closeBy = false;
            GirlAnimator.SetBool("Run1", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Activated = false;
        }
    }
}
