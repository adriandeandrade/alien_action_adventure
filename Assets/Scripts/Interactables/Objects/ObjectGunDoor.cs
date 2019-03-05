using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGunDoor : Interactable
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    public override void Interact()
    {
        TriggerDoorOpen();
        isInteractable = false;
    }

    private void TriggerDoorOpen()
    {
        leftDoor.SetActive(false);
        rightDoor.SetActive(false);
    }
}
