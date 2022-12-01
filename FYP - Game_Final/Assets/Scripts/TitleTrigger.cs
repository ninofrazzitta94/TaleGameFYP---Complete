using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTrigger : MonoBehaviour
{
    public Animator TitleAnim;
    public bool activated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            activated = true;
        }
    }

    private void Update()
    {
        if (activated)
        {
            TitleAnim.SetTrigger("Title");
        }
    }
}
