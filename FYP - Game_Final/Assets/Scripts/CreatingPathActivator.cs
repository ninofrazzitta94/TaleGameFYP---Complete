using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class CreatingPathActivator : MonoBehaviour
{
    public GameObject Lever;
    public GameObject path;

    private void Update()
    {
        if (Lever.GetComponent<DestroyPlatform>().GirlCollided == true || Lever.GetComponent<DestroyPlatform>().BoyInteracted)
        {
            path.GetComponent<GeneratePathExample>().enabled = true;           
        }
    }
}

