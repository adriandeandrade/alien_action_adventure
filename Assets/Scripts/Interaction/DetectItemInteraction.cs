using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DetectItemInteraction : MonoBehaviour
{
    [SerializeField] private Transform interactionPosition;
    [SerializeField] private bool useCustomInteractionPosition;
    public bool isWithinInteractionDistance;

    Camera cam;
    SphereCollider interactionCollider;
    [HideInInspector] public InteractionUIController worldSpaceUIController;
    InventoryItemInteractable inventoryItemInteractable;
    MeshRenderer meshRenderer;

    Color originalColor;

    private void Awake()
    {
        cam = Camera.main;
        meshRenderer = GetComponent<MeshRenderer>();
        inventoryItemInteractable = GetComponent<InventoryItemInteractable>();
        worldSpaceUIController = FindObjectOfType<InteractionUIController>();

        if(meshRenderer == null)
        {
            meshRenderer = GetComponentInChildren<MeshRenderer>();
        }

        originalColor = meshRenderer.material.GetColor("_BaseColor");
    }

    private void Start()
    {
        if (interactionPosition == null)
        {
            interactionPosition = transform;
        }
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!inventoryItemInteractable.isInteractable) return;

        if (other.CompareTag("Player") && !isWithinInteractionDistance)
        {
            isWithinInteractionDistance = true;
            meshRenderer.material.SetColor("_BaseColor", Color.red);
            worldSpaceUIController.SetPosition(interactionPosition, useCustomInteractionPosition);
            worldSpaceUIController.UpdateUI(inventoryItemInteractable.data);
            worldSpaceUIController.ToggleCanvas(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!inventoryItemInteractable.isInteractable) return;

        if (other.CompareTag("Player") && isWithinInteractionDistance)
        {
            isWithinInteractionDistance = false;
            meshRenderer.material.SetColor("_BaseColor", originalColor);
            worldSpaceUIController.TriggerFadeOut();
        }
    }
}
