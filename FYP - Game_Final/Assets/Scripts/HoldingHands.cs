using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzelGames.FastIK;

public class HoldingHands : MonoBehaviour
{

    public FastIKFabric BoyScript;
    public FastIKFabric GirlScript;

    public GirlFollow GirlFollowScript;

    public GameObject BoyTarget;
    public GameObject GirlTarget;
    public GameObject HandsTarget;
    public GameObject HandsTargetGirl;

    public Transform BoyInitialPos;
    public Transform girlInitialPos;

    public bool activated;


    void Update()
    {
        
        if (GirlFollowScript.HoldingHands)
        {
            BoyScript.enabled = true;
            GirlScript.enabled = true;

            BoyTarget.transform.position = Vector3.Lerp(HandsTarget.transform.position, BoyTarget.transform.position, 0.5f);
            BoyTarget.transform.rotation = Quaternion.Slerp(BoyTarget.transform.rotation,HandsTarget.transform.rotation,0.5f);
            GirlTarget.transform.position = Vector3.Lerp(HandsTargetGirl.transform.position, GirlTarget.transform.position, 0.5f);
            GirlTarget.transform.rotation = Quaternion.Slerp(GirlTarget.transform.rotation, HandsTargetGirl.transform.rotation, 0.5f);
        }
        else
        {

            BoyTarget.transform.position = Vector3.Lerp(HandsTarget.transform.position, BoyInitialPos.position, 0.5f);
            GirlTarget.transform.position = Vector3.Lerp(HandsTargetGirl.transform.position, girlInitialPos.position, 0.5f);

            BoyScript.enabled = false;
            GirlScript.enabled = false;          
        }
    }
}
