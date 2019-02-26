using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Interactable : MonoBehaviour
{
    [SerializeField] private Color debugColor;

    Color originalColor;
    MeshRenderer meshRenderer;

    bool isInteracting = false;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        //originalColor = meshRenderer.material.color;
    }

    public virtual void Interact()
    {
        //if(!isInteracting)
        //{
        //    isInteracting = true;
        //    Debug.Log("looking at item.");
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInteracting)
        {
            //meshRenderer.material.color = debugColor;

            isInteracting = true;
            Debug.Log("Has interacted with: " + transform.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInteracting)
        {
            //meshRenderer.material.color = originalColor;

            isInteracting = false;
            Debug.Log("Stopped interacting with: " + transform.name);
        }
    }
}
