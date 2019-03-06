using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DetectInteraction : MonoBehaviour
{
    [SerializeField] private Transform interactionPosition;
    [SerializeField] private bool useCustomInteractionPosition;
    public bool isWithinInteractionDistance;

    SphereCollider interactionCollider;
    [HideInInspector] public InteractionUIController worldSpaceUIController;
    InteractableBaseInteractable interactableBase;

    private void Awake()
    {
        interactionCollider = GetComponent<SphereCollider>();
        interactableBase = GetComponent<InteractableBaseInteractable>();
        worldSpaceUIController = FindObjectOfType<InteractionUIController>();
    }

    private void Start()
    {
        if(interactionPosition == null)
        {
            interactionPosition = transform;
        }

        // interactionCollider.center = interactionPosition.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!interactableBase.isInteractable) return;

        if (other.CompareTag("Player") && !isWithinInteractionDistance)
        {
            isWithinInteractionDistance = true;
            worldSpaceUIController.SetPosition(interactionPosition, useCustomInteractionPosition);
            worldSpaceUIController.UpdateUI(interactableBase.data);
            worldSpaceUIController.ToggleCanvas(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!interactableBase.isInteractable) return;

        if (other.CompareTag("Player") && isWithinInteractionDistance)
        {
            isWithinInteractionDistance = false;
            worldSpaceUIController.TriggerFadeOut();
        }
    }
}
