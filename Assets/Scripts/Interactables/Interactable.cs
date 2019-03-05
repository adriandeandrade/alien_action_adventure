using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour
{
    public InteractableObjectData objectData;

    [SerializeField] private Transform interactionPosition;
    [SerializeField] private bool useCustomInteractionPosition;
    public bool isInteractable;

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
        if(useCustomInteractionPosition)
        {
            interactionCollider.center = interactionPosition.localPosition;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInteracting)
        {
            Interact();
            worldSpaceUIController.ToggleCanvas(false);
        }
    }

    public virtual void Interact()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isInteractable) return;

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
        if (!isInteractable) return;

        if (other.CompareTag("Player") && isInteracting)
        {
            isInteracting = false;
            worldSpaceUIController.TriggerFadeOut();
        }
    }

}
