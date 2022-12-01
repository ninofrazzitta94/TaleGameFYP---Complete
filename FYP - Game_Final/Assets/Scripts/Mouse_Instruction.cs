using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Instruction : MonoBehaviour
{
    public Animator MouseIcon;

    public bool Activated = true;

    private void OnTriggerEnter(Collider other)
    {
        if (Activated)
        {
            if (other.gameObject.name == "Ball")
            {
                MouseIcon.SetBool("Fade", true);
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseIcon.SetBool("Fade", false);
            Activated = false;
        }
    }
}
