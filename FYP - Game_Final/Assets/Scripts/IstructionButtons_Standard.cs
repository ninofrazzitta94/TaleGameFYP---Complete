using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IstructionButtons_Standard : MonoBehaviour
{
    public Animator Text;

    public bool interacted = false;

    private void OnTriggerStay(Collider other)
    {
        if (interacted == false)
        {
            if (other.gameObject.name == "Player")
            {
                Text.SetBool("Fade", true);

                if (Input.GetKey(KeyCode.E))
                {
                    interacted = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Text.SetBool("Fade", false);
        }
    }

}
