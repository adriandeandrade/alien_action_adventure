using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 3f;
    [SerializeField] private Transform interactionTransform;
    [SerializeField] private Transform player;

    bool hasInteracted = false;

    private void Update()
    {
        if(!hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);

            if(distance <= interactionRadius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with: " + transform.name);
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, interactionRadius);
    }
}
