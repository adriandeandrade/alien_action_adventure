using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupAntiMatterGun : MonoBehaviour
{
    public Text gunModeText;
    public Text tutorialText;

    public void TriggerOnPickupGun()
    {
        GameManager.instance.GetGun();
        gunModeText.gameObject.SetActive(true);
        tutorialText.gameObject.SetActive(true);
    }
}
