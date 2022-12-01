using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTeleporter : MonoBehaviour
{
    public GameObject girlInter;
    public GameObject girl;
    public Vector3 offset;
    public Vector3 ballOff;
    public Vector3 ReturnTeleportOff;
    public Vector3 ContainedOffset;
    public Collider Obj;

    public GameObject movingPlat;
    public GameObject Player;
    public Vector3 ballOffset;
    public GameObject particleEffect;
    public Cloth Poncho;

    public bool collided = false;
    public bool Contained = false;

    public Collider[] collider2;

    public bool onFloor;
    public bool Threw;
    private float timeCounter;

    public Audio_Manager AM;

    void Update()
    {
        Physics.IgnoreCollision(girl.GetComponent<Collider>(), GetComponent<Collider>());
        //Physics.IgnoreCollision(movingPlat.GetComponent<Collider>(), GetComponent<Collider>());

        if (collided == true)
        {
            particleEffect.transform.localScale = new Vector3 (3, 3, 3);
            GameObject SplashPartClone = Instantiate(particleEffect, transform.position + offset, particleEffect.transform.rotation);
            SplashPartClone.SetActive(true);

            Poncho.enabled = false;
            girl.transform.position = this.gameObject.transform.position + offset;
            collided = false;
            Poncho.enabled = true;
        }

        if (Contained)
        {
            gameObject.transform.parent = null;
            gameObject.transform.parent = Obj.transform;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            gameObject.GetComponent<Transform>().position = Obj.transform.position + ContainedOffset;
            collider2[1].enabled = true;
        }

        if (onFloor)
        {
            timeCounter += Time.deltaTime;
        }
        //Debug.Log(timeCounter);

        if (onFloor)
        {
            if (Threw)
            {
                if (timeCounter > 1.4 && timeCounter < 1.5)
                {
                    collided = true;

                    AM.sounds[2].source.pitch = 1f;
                    AM.Play("Wosh");
                }
            }
        }

        if (onFloor)
        {
            if (Threw)
            {
                if (timeCounter > 5 && timeCounter < 6)
                {
                    gameObject.transform.position = Player.transform.position + ReturnTeleportOff;
                    Threw = false;
                    particleEffect.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    GameObject SplashPartClone = Instantiate(particleEffect, Player.transform.position + ReturnTeleportOff, particleEffect.transform.rotation);
                    SplashPartClone.SetActive(true);

                    AM.sounds[2].source.pitch = 0.8f;
                    AM.Play("Wosh");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onFloor = true;
            girlInter.GetComponent<Collider>().enabled = false;


            StartCoroutine(MyCoroutine());
            
            IEnumerator MyCoroutine()
            {
                yield return new WaitForSeconds(1.5f);
                girlInter.GetComponent<Collider>().enabled = true;
            }
        }

        if (collision.gameObject.name == "BallContainer")
        {
            Obj = collision;
            Contained = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onFloor = false;
            timeCounter = 0;
            collided = false;
        }
    }
}
