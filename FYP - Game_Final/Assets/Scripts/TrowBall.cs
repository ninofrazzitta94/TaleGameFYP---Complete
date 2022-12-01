using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrowBall : MonoBehaviour

{
    public Rigidbody rb;
    public int clickForce = 20;
    private Plane plane = new Plane(Vector3.up, Vector3.zero);

    public bool grabbed = false;
    public bool ballShot = false;

    public bool CursorActivator;

    public GameObject player;
    public Collider[] collider2;

    public BallTeleporter BallTeleporterScript;

    public Audio_Manager AM;
    public AudioSource BallRoll;

    private void Update()
    {
        if (grabbed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (ballShot == false)
                {
                    BallTeleporterScript.Threw = true;
                    gameObject.transform.parent = null;
                    GetComponent<Rigidbody>().isKinematic = false;
                    GetComponent<Rigidbody>().detectCollisions = true;
                    collider2[1].enabled = false;
                    Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());


                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
                    Vector3 direction = (Vector3)(Input.mousePosition - screenPoint);
                    direction.Normalize();
                    this.GetComponent<Rigidbody>().AddForce(direction * clickForce, ForceMode.Impulse);

                    ballShot = true;

                    player.GetComponent<PlayerController>().NotHoldingBall();

                }
            }
        }

        if (rb.velocity.x > 1.1f || rb.velocity.x < -1.1f)
        {
            if (ballShot == false && grabbed == false)
            {
                BallRoll.enabled = true;

                //modify pitch using ball velocity
                float pitchModifier = 0f - 0.5f;
                float vel = Mathf.Abs(rb.velocity.x);
                BallRoll.pitch = 1f + (-vel/ 25) * pitchModifier;
            }
        }
        else
        {
            BallRoll.enabled = false;
        }

        if (CursorActivator)
        {
            ballShot = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collider2[1].enabled = true;
            grabbed = false;
            ballShot = false;

           float pitchValue = Random.Range(1f, 1.1f);

            AM.sounds[11].source.pitch = pitchValue;

            AM.Play("Ball");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            ballShot = false;
            player.GetComponent<PlayerController>().HoldingBall();
        }
        if (other.gameObject.name == "BallContainer")
        {
            ballShot = false;
        }
    }



}