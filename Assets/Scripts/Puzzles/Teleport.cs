using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform teleportPos;
    [SerializeField] private Transform character;

    public void TeleportToNewPos()
    {
        character.position = teleportPos.position;
    } 
}
