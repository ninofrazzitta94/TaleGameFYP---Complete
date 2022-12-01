using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDoor : MonoBehaviour
{
    public GameObject doorMid;
    public Vector3 offset;

    public Animator MaterialAnimator;

    public Audio_Manager AM;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Door Half 2")
        {
            AM.Play("RockHit");

            MaterialAnimator.SetBool("Set", true);

            transform.parent = collision.transform;
            doorMid.SetActive(true);

            collision.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + offset;

        }

        if (collision.gameObject.layer == 8)
        {
            AM.Play("RockDrop");
        }
    }
}
