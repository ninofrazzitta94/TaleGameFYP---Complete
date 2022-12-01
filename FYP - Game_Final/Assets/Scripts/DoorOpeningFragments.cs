using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpeningFragments : MonoBehaviour
{
    public int KeyFragments = 0;
    public Text UIText;
    public FinishDoor finishScript;

    public Audio_Manager AM;

    private void OnTriggerEnter(Collider other)
    {
        {
           if (KeyFragments == 6)
           { 
              if (other.gameObject.name == "Player")
              {
                    //gameObject.SetActive(false);
                    Debug.Log("player collided");
                    Destroy(gameObject);
                    finishScript.FragmentsCollected = true;

                    AM.Play("Unlock");

              }
           }
        }
    }

    private void Update()
    {
        UIText.text = KeyFragments.ToString() + "/6";
    }

}
