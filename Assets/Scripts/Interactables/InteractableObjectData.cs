using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable Object", menuName = "Interactable Objects/New Interactable Object")]
public class InteractableObjectData : ScriptableObject
{
    public string interactionTitle;
    public string objectDescriptionTitle;
    [TextArea] public string objectDescription;
    public bool isDocument;
}
