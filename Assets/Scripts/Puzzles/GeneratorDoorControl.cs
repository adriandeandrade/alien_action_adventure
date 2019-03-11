using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorDoorControl : MonoBehaviour
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    public void TriggerDoorOpen()
    {
        leftDoor.SetActive(false);
        rightDoor.SetActive(false);
    }
}
