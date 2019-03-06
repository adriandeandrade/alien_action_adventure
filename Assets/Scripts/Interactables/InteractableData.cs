using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable Data Object", menuName = "Interactable Objects/New Interactable Data Object")]
public class InteractableData : ScriptableObject
{
    public string interactionName; // Ex. Press E to Interact with Generator. Generator = interactionName
}
