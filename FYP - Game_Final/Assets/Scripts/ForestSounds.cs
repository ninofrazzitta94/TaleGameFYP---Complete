using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestSounds : MonoBehaviour
{

    private int index;

    private void Update()
    {

        if (index < 3)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        index = SceneManager.GetActiveScene().buildIndex;
    }
}
