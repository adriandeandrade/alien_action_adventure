using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DetectItemInteraction))]
public class InventoryItemInteractable : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPickup;
    public InventoryItemData data;
    public bool isInteractable; // Used to make object interactable or now.

    DetectItemInteraction detectItemInteraction;
    ItemPickupNotification notification;

    private void Awake()
    {
        if (OnPickup == null)
        {
            OnPickup = new UnityEvent();
        }

        detectItemInteraction = GetComponent<DetectItemInteraction>();
        notification = FindObjectOfType<ItemPickupNotification>();
    }

    private void Update()
    {
        if(detectItemInteraction.isWithinInteractionDistance)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
        }
    }

    public void Interact()
    {
        OnPickup.Invoke();
        InventoryManager.instance.AddItem(this);
        notification.ShowIcon();
        detectItemInteraction.worldSpaceUIController.ToggleCanvas(false);
        isInteractable = false;
        Destroy(gameObject);
    }
}
