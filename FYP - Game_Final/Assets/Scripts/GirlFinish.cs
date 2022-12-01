using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlFinish : MonoBehaviour
{
    public GameObject particleEffects;
    public GameObject girlprop;
    public GameObject girlInteractableModel;
    public GameObject Crystal;
    public Cloth cloth;

    public Animator girlPropAnim;

    public Vector3 offset;
    public float speed;

    public bool activation = true;
    public bool boyinRange = false;
    public bool girlinRange = false;

    public Flash FlashScript;
    public ManageScenes ManageScenesScript;
    public MaterialGlowFinal MaterialGlowFinalScript;

    public AudioSource MagicCharge;

    private void Start()
    
    {
        offset = girlprop.transform.position + offset;
    }

    void Update()
    {
        if (boyinRange && girlinRange)
        {          
                activation = true;            
        }
        if (activation)
        {
            girlInteractableModel.SetActive(false);
            girlprop.SetActive(true);
            particleEffects.SetActive(true);
            boyinRange = false;
            girlinRange = false;
            girlprop.transform.position = Vector3.Lerp(girlprop.transform.position, offset, speed * Time.deltaTime);
            StartCoroutine(Coroutine());

        }
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(5);

            MaterialGlowFinalScript.GirlCollided = false;
            MaterialGlowFinalScript.boyCollided = false;

            girlPropAnim.SetBool("Freeze", true);
            particleEffects.SetActive(false);
            FlashScript.CameraFlash();
            Crystal.SetActive(true);
            cloth.enabled = false;
            activation = false;
            StartCoroutine(Coroutine2());
            MagicCharge.enabled = false;
        }

        IEnumerator Coroutine2()
        {
            yield return new WaitForSeconds(10);

            ManageScenesScript.LoadNextLevel();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            boyinRange = true;
            girlinRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            boyinRange = false;
            girlinRange = false;
        }
    }
}
