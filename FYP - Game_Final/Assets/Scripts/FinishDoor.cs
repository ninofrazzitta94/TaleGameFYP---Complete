using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour
{
    public PlayerController boyScript;
    public GirlFollow girlScript;
    public ManageScenes ManageScenesScript;


    public bool PuzzleCompleted = false;
    public bool FragmentsCollected = false;

    public GameObject Portal;
    public GameObject particleEffect;

    private void Update()
    {
        if (boyScript.BoyFinished == true && girlScript.girlFinished == true)
        {
            PuzzleCompleted = true;
        }

        if (FragmentsCollected)
        {
            GetComponent<Collider>().enabled = true;
        }

        if (PuzzleCompleted)
        {

            GameObject SplashPartClone = Instantiate(particleEffect, Portal.transform.position, particleEffect.transform.rotation);
            SplashPartClone.SetActive(true);

            StartCoroutine(Coroutine1());

            PuzzleCompleted = false;

            IEnumerator Coroutine1()
            {

                yield return new WaitForSeconds(0.1f);

                Portal.SetActive(true);

                StartCoroutine(Coroutine2());
            }

            IEnumerator Coroutine2()
            {

                yield return new WaitForSeconds(0.2f);

                ManageScenesScript.LoadNextLevel();

            }
        }
    }
}
