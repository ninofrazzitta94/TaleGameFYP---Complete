using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DangeonAmbience2 : MonoBehaviour
{
    private int index;

    private void Update()
    {

        if (index < 7)
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
