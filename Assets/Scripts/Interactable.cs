using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour
{
    public InteractableObjectData objectData;

    [SerializeField] private Transform interactionPosition;
    [SerializeField] private bool useCustomInteractionPosition;

    bool isInteracting = false;
    string objectName;

    InteractionUIController worldSpaceUIController;
    SphereCollider interactionCollider;

    private void Awake()
    {
        worldSpaceUIController = FindObjectOfType<InteractionUIController>();
        interactionCollider = GetComponent<SphereCollider>();
    }

    private void Start()
    {
        if(objectData != null)
        {
            InitializeInteractable();
        } else
        {
            Debug.LogError("Object does not have a reference to its data object.");
        }

        if(useCustomInteractionPosition)
        {
            interactionCollider.center = interactionPosition.localPosition;
        }
    }

    public virtual void Interact()
    {
        
    }

    private void InitializeInteractable()
    {
        objectName = objectData.objectName;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInteracting)
        {
            isInteracting = true;
            worldSpaceUIController.SetPosition(interactionPosition, useCustomInteractionPosition);
            worldSpaceUIController.UpdateUI(objectData);
            worldSpaceUIController.ToggleCanvas(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInteracting)
        {
            isInteracting = false;
            worldSpaceUIController.TriggerFadeOut();
        }
    }

}
