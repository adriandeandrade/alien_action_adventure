using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickupNotification : MonoBehaviour
{
    [SerializeField] private float showTime;
    [SerializeField] private Image icon;

    public void ShowIcon()
    {
        icon.enabled = true;
        StartCoroutine(ShowTimer());
    }

    IEnumerator ShowTimer ()
    {
        yield return new WaitForSeconds(showTime);
        icon.enabled = false;
    }
}
