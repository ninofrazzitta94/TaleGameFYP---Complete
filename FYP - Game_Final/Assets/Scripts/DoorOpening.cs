using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorOpening : MonoBehaviour
{

    public bool KeyCollected = false;
    public GameObject KeyUI;

    private void OnTriggerEnter(Collider other)
    {
        if (KeyCollected)
        {
            if (other.gameObject.name == "Player")
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (KeyCollected)
        {
            KeyUI.SetActive(true);
        }
        else
            KeyUI.SetActive(false);
    }

}
