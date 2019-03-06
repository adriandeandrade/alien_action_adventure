using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DetectInteraction))]
public class InteractableBase : MonoBehaviour
{
    public InteractableData data;
    [SerializeField] private UnityEvent OnInteract;
    public bool isInteractable; // Used to make object interactable or now.

    DetectInteraction detectInteraction;

    private void Awake()
    {
        if(OnInteract == null)
        {
            OnInteract = new UnityEvent();
        }

        detectInteraction = GetComponent<DetectInteraction>();
    }

    private void Update()
    {
        if(detectInteraction.isWithinInteractionDistance)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }

    public void Interact()
    {
        OnInteract.Invoke();
        Debug.Log("Interacted With Object");
    }
}
