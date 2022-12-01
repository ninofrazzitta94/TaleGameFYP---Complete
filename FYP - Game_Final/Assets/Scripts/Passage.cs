using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Passage : MonoBehaviour
{
    public ManageScenes sceneManagerScript;

    public bool activated;

    private void Update()
    {
        if (activated)
        {
            sceneManagerScript.LoadNextLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            sceneManagerScript.LoadNextLevel();
        }
    }
}
