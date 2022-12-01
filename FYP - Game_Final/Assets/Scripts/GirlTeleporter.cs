using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlTeleporter : MonoBehaviour
{
    public GameObject girl;
    public  Vector3 offset;
    public GameObject particleEffect;
    public Cloth Poncho;
    public bool collided = false;

    public Audio_Manager AM;

    void Update()
    {
        if (collided == true)
        {
            if (Input.GetKeyDown("e"))
            {
                particleEffect.transform.localScale = new Vector3(3, 3, 3);
                GameObject SplashPartClone = Instantiate(particleEffect, transform.position + offset, particleEffect.transform.rotation);
                SplashPartClone.SetActive(true);

                Poncho.enabled = false;
                girl.transform.position = this.gameObject.transform.position + offset;
                Poncho.enabled = true;

                AM.sounds[2].source.pitch = 1f;
                AM.Play("Wosh");
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {      
            if (collision.gameObject.name == "Player")
            {
            collided = true;
            }        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collided = false;
        }
    }
}
