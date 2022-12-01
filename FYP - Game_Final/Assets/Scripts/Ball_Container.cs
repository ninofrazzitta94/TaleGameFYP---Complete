using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Container : MonoBehaviour
{
    public MovingPlatform movingPlatformScript;
    public BallTeleporter BallTeleporterScript;
    public Vector3 ballOffset;
    public GameObject Ball;
    public GameObject Ball1;
    public GameObject playerSkeleton;
    public GameObject player;
    public TrowBall TrowBallScript;

    public bool InSocket;

    public Audio_Manager AM;

    public bool BallIN;
    public bool Ball1IN;

    private void OnTriggerEnter(Collider other)
    {
        if (Ball.GetComponent<BallTeleporter>().Contained  || Ball1.GetComponent<BallTeleporter>().Contained)
        {
            if (other.gameObject.name == "Player")
            {
                player.GetComponent<PlayerController>().HoldingBall();

                if (Ball.GetComponent<BallTeleporter>().Threw == true  && Ball.GetComponent<BallTeleporter>().Contained == true)
                {

                    BallIN = false;

                    Ball.transform.parent = null;
                    Ball.transform.parent = playerSkeleton.transform;
                    Ball.GetComponent<BallTeleporter>().Contained = false;
                    Ball.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                    Ball.GetComponent<Rigidbody>().isKinematic = true;
                    Ball.GetComponent<Rigidbody>().detectCollisions = false;
                    Ball.GetComponent<Transform>().position = playerSkeleton.transform.position + ballOffset;

                    Ball.GetComponent<TrowBall>().grabbed = true;
                    Ball.GetComponent<TrowBall>().ballShot = false;

                    InSocket = false;

                    AM.sounds[9].source.pitch = 1f;
                    AM.Play("Place");

                    player.GetComponent<PlayerController>().HoldingBall();
                }

                if (Ball1.GetComponent<BallTeleporter>().Threw == true && Ball1.GetComponent<BallTeleporter>().Contained == true)
                {
                    Ball1IN = false;

                    Ball1.transform.parent = null;
                    Ball1.transform.parent = playerSkeleton.transform;
                    Ball1.GetComponent<BallTeleporter>().Contained = false;
                    Ball1.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                    Ball1.GetComponent<Rigidbody>().isKinematic = true;
                    Ball1.GetComponent<Rigidbody>().detectCollisions = false;
                    Ball1.GetComponent<Transform>().position = playerSkeleton.transform.position + ballOffset;

                    Ball1.GetComponent<TrowBall>().grabbed = true;
                    Ball1.GetComponent<TrowBall>().ballShot = false;

                    InSocket = false;

                    AM.sounds[9].source.pitch = 1f;
                    AM.Play("Place");

                    player.GetComponent<PlayerController>().HoldingBall();
                }

                if (other.gameObject.name == "Ball")
                {
                    player.GetComponent<PlayerController>().NotHoldingBall();
                }

                if (other.gameObject.name == "Ball1")
                {
                    player.GetComponent<PlayerController>().NotHoldingBall();
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            InSocket = true;
            movingPlatformScript.Move();
            AM.sounds[9].source.pitch = 0.7f;
            other.GetComponent<TrowBall>().ballShot = true;
            AM.Play("Place");
        }

        if (other.gameObject.name == "Ball")
        {
            BallIN = true;

        }

        if (other.gameObject.name == "Ball1")
        {
            Ball1IN = true;
        }

    }

    private void Update()
    {
        if (InSocket == false)
        {
            movingPlatformScript.ReverseMove();
        } 
        /*
        if (Ball1.GetComponent<BallTeleporter>().Contained == true)
        {
            Physics.IgnoreCollision(Ball.GetComponents<Collider>()[0], this.GetComponent<Collider>());
            Physics.IgnoreCollision(Ball.GetComponents<Collider>()[1], this.GetComponent<Collider>());
        }
        */

        //ignore collsions when the other ball is in
        if (BallIN)
        {
            Physics.IgnoreCollision(Ball1.GetComponents<Collider>()[0], this.GetComponent<Collider>());
            Physics.IgnoreCollision(Ball1.GetComponents<Collider>()[1], this.GetComponent<Collider>());
        }

        if (Ball1IN)
        {
            Physics.IgnoreCollision(Ball.GetComponents<Collider>()[0], this.GetComponent<Collider>());
            Physics.IgnoreCollision(Ball.GetComponents<Collider>()[1], this.GetComponent<Collider>());
        }
    }
}
