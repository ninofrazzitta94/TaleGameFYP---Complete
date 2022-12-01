using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabToRestart : MonoBehaviour
{
    public Animator TabToRestartText;


    void Start()
    {
        StartCoroutine(ShowText());

        IEnumerator ShowText()
        {
            yield return new WaitForSeconds(10);

            TabToRestartText.SetBool("Set", true);
        }
    }
}
