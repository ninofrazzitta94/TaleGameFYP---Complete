using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlUnlock : MonoBehaviour
{
    public GameObject GirlInteractModel;
    public GameObject CrystalBurst;
    public Collider[] TeleportersColliders;

    public Animator MaterialGlow;
    public Animator UI_E_Button;

    public bool inRange;

    public Audio_Manager AM;

    public IstructionButtons ShiftText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            inRange = true;
            UI_E_Button.SetBool("Fade", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            inRange = false;
            UI_E_Button.SetBool("Fade", false);
        }
    }
    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown("e"))
            {

                AM.Play("CrystalDestroy");

                GirlInteractModel.SetActive(true);

                GameObject SplashPartClone = Instantiate(CrystalBurst, transform.position, CrystalBurst.transform.rotation);
                SplashPartClone.SetActive(true);

                gameObject.SetActive(false);

                for (int i = 0; i < TeleportersColliders.Length; i++)
                {
                    TeleportersColliders[i].enabled = true;
                }

                MaterialGlow.SetBool("Set", false);
                UI_E_Button.SetBool("Fade", false);

                ShiftText.interacted = false;

            }
        }
    }
}
