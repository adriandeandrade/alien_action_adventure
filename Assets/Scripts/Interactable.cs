using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour
{
    bool isInteracting = false;

    WorldSpaceUIController worldSpaceUIController;

    private void Awake()
    {
        worldSpaceUIController = FindObjectOfType<WorldSpaceUIController>();
    }

    private void Update()
    {
        
    }

    public virtual void Interact()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInteracting)
        {
            isInteracting = true;
            worldSpaceUIController.SetPosition(gameObject);
            worldSpaceUIController.ToggleCanvas(true);
            Debug.Log("Has interacted with: " + transform.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInteracting)
        {
            isInteracting = false;
            worldSpaceUIController.ToggleCanvas(false);
            Debug.Log("Stopped interacting with: " + transform.name);
        }
    }
}
