using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    public float flashTime = .2f;
    public bool ActivateFlash = false;

    private Image Image;
    private float startTime;
    private bool flashing = false;

    void Start()
    {
        Image = GetComponent<Image>();
        Color col = Image.color;
        col.a = 0.0f;
        Image.color = col;
    }

    void Update()
    {
        if (ActivateFlash && !flashing)
        {
            CameraFlash();
        }
        else
        {
            ActivateFlash = false;
        }
    }

    public void CameraFlash()
    {
        Color col = Image.color;

        startTime = Time.time;

        ActivateFlash = false;

        col.a = 1.0f;

        Image.color = col;

        flashing = true;

        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        bool done = false;

        while (!done)
        {
            float perc;
            Color col = Image.color;

            perc = Time.time - startTime;
            perc = perc / flashTime;

            if (perc > 1.0f)
            {
                perc = 1.0f;
                done = true;
            }

            col.a = Mathf.Lerp(1.0f, 0.0f, perc);
            Image.color = col;
            flashing = true;

            yield return null;
        }

        flashing = false;

        yield break;
    }
}

