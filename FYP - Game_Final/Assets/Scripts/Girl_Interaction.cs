using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl_Interaction : MonoBehaviour
{
    float distance;
    public float setDistance;
    Vector3 relativePosition;
    public GameObject Girl;
    public GameObject Obj;
    public bool closeBy = false;
    public GameObject player;

    public Quaternion rotOffset;
    public float Speed;
    public Vector3 offset;

    public Animator GirlAnimator;


    private void Update()
    {
        Physics.IgnoreCollision(player.GetComponent<Collider>(), this.GetComponent<Collider>());
    }

    void FixedUpdate()
    {
        distance = Vector3.Distance(Girl.transform.position, Obj.transform.position);

        relativePosition = Girl.transform.position - Obj.transform.position;

        if (distance < setDistance)
        {
            closeBy = false;
            GirlAnimator.SetBool("Run1", false);
        }

        if (closeBy)
        {
            GirlAnimator.SetBool("Run1", true);
            transform.rotation = rotOffset;
            Vector3 desiredPosition = Obj.transform.position + offset;
            Girl.transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Speed);                       
        }

        if (relativePosition.x > 0.1)
        {
            Quaternion priorRot = transform.rotation;
            rotOffset = Quaternion.Slerp(priorRot, Quaternion.Euler(0, 180, 0), 0.5f);

        }
        if (relativePosition.x < -0.1)
        {
            Quaternion priorRot = transform.rotation;
            rotOffset = Quaternion.Slerp(priorRot, Quaternion.Euler(0, 0, 0), 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Girl Inter")
        {
             Obj = other.gameObject;
            closeBy = true;
        }
    }
}
