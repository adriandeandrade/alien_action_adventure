using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DetectItemInteraction : MonoBehaviour
{
    [SerializeField] private Transform interactionPosition;
    [SerializeField] private bool useCustomInteractionPosition;
    public bool isWithinInteractionDistance;
    public bool lookingAt;

    Camera cam;
    SphereCollider interactionCollider;
    InteractionUIController worldSpaceUIController;
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
        //DetectLookAt();
    }

    private void DetectLookAt()
    {
        if (!isWithinInteractionDistance) return;

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, Mathf.Infinity, GameManager.instance.itemPickUpLayer) && !lookingAt)
        {
            lookingAt = true;
            meshRenderer.material.SetColor("_BaseColor", Color.red);
            Debug.Log("Looking at object");
            return;
        }

        lookingAt = false;
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
