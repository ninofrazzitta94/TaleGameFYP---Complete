using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public float yPos = 2.02f;
    public Vector3 Newoffset;
    public Vector3 NewRotation;
    private Vector3 offset;
    private Quaternion rotOffset;
    public Rigidbody playerRB;
    public Rigidbody girlRB;

    public bool collided = false;
    public bool HoldingHands = false;
    public bool girlFinished = false;
    public Collider col;

    public GameObject player;

    public Animator GirlAnimator;


    void FixedUpdate()
    {
        yPos = this.gameObject.transform.position.y;

        if (HoldingHands)
        {
            transform.rotation = rotOffset;
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            smoothedPosition.y = yPos;
            transform.position = smoothedPosition;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            collided = true;
        }

        if (col.gameObject.name == "FinishDoor")
        {
            girlFinished = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            collided = false;
        }

        if (col.gameObject.name == "FinishDoor")
        {
            girlFinished = false;
        }
    }

    private void Update()
    {
        if (playerRB.velocity.x > 0.1)
        {
            offset = Newoffset;
            rotOffset = Quaternion.Euler(0, 0, 0);
        }
        if (playerRB.velocity.x < -0.1)
        {
            offset = Newoffset * -1;
            rotOffset = Quaternion.Euler(0, 180, 0);
        }

        //if (HoldingHands == true)

        Physics.IgnoreCollision(player.GetComponent<Collider>(), this.GetComponent<Collider>());     
        
        
       /* 
        if (HoldingHands == false)
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>(), false);
        }
       */ 

        if (collided == true)
        {
            if (Input.GetKey("left shift") || Input.GetKey("right shift"))
            {
                HoldingHands = true;
            }            
        }
        if (Input.GetKeyUp("left shift") || Input.GetKeyUp("right shift"))
        {
            HoldingHands = false;
        }

        //Animation

        if (HoldingHands && playerRB.velocity.x != 0)
        {
            GirlAnimator.SetBool("Run", true);
        }
        else
        {
            GirlAnimator.SetBool("Run", false);
        }
    }
}
