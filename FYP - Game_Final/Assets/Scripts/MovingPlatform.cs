using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3[] points;
    public int pointNumber;
    private Vector3 currentTarget;

    public float tolerance;
    public float speed;
    public float delayTime;

    private float delayStart;

    public bool automatic;
    public bool moving = false;

    public AudioSource MovingSound;

    void Start()
    {
        //Change to initial position
        points[0] = gameObject.transform.position;

        if (points.Length > 0)
        {
            currentTarget = points[0];
        }
        tolerance = speed * Time.fixedDeltaTime;
    }

    void FixedUpdate()
    {
        if (transform.position != currentTarget)
        {
            MovePlatform();
            moving = true;
            MovingSound.enabled = true;
        }
        else
        {
            UpdateTarget();
            moving = false;
            MovingSound.enabled = false;
        }
    }

    void MovePlatform()
    {
        Vector3 heading = currentTarget - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.fixedDeltaTime;
        if (heading.magnitude < tolerance)
        {
            transform.position = currentTarget;
            delayStart = Time.time;
        }
    }

    void UpdateTarget()
    {
        if (automatic)
        {
            if (Time.time - delayStart > delayTime)
            {
                NextPlatform();
            }
        }

    }

    public void NextPlatform()
    {
        pointNumber++;
        if (pointNumber >= points.Length)
        {
            pointNumber = 0;
        }
        currentTarget = points[pointNumber];
    }

    public void Move()
    {
        pointNumber = 1;
        currentTarget = points[pointNumber];
    }

    public void ReverseMove()
    {
        pointNumber = 0;
        currentTarget = points[pointNumber];
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "PressPadInter")
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "PressPadInter")
        {
            collision.transform.parent = null;
        }
    }
}
