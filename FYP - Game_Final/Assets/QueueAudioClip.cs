using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
 [RequireComponent(typeof(AudioSource))]
public class QueueAudioClip : MonoBehaviour
{
    public AudioSource ASIntro;
    public AudioSource ASLoop;
    private bool startLoop;

    void FixedUpdate()
    {
        if (!ASIntro.isPlaying && !startLoop)
        {
            ASLoop.Play();
            startLoop = true;
        }
    }
}

