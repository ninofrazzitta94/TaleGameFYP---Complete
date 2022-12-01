using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public GameObject platformToDestroy;

    public bool collided = false;
    public bool BoyInteracted = false;
    public bool GirlCollided = false;
    public bool Interacted = false;

    public GameObject Lever;
    public Vector3 ParticleOffset;
    public GameObject particleEffect;

    public Audio_Manager Audio_ManagerScript;

    private float rotz = -40;

    void Update()
    {
        if (collided == true)
        {
            if (Input.GetKeyDown("e"))
            {
                Destroy(platformToDestroy);

                Lever.transform.rotation = Quaternion.Euler(0, 0, rotz);

                BoyInteracted = true;

                Audio_ManagerScript.Play("WoodDestroy");

                GameObject SplashPartClone = Instantiate(particleEffect, platformToDestroy.transform.position + ParticleOffset, particleEffect.transform.rotation);
                SplashPartClone.SetActive(true);

                if (platformToDestroy.activeInHierarchy == true)
                {
                    Interacted = true;
                }
            }
        }
        if (GirlCollided == true)
        {           
            Destroy(platformToDestroy);

            Lever.transform.rotation = Quaternion.Euler(0, 0, rotz);

            Audio_ManagerScript.Play("WoodDestroy");

            GameObject SplashPartClone = Instantiate(particleEffect, platformToDestroy.transform.position + ParticleOffset, particleEffect.transform.rotation);
            SplashPartClone.SetActive(true);

            GirlCollided = false;
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collided = true;
        }

        if (collision.gameObject.name == "Girl")
        {
            GirlCollided = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collided = false;
        }

        if (collision.gameObject.name == "Girl")
        {
            GirlCollided = false;
        }
    }
}
