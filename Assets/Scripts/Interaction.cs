using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private LayerMask interactionLayer;

    Camera cam;
    Animator animator;
    MovementInput moveInput;

    bool isPressingInteractionButton;

    private void Awake()
    {
        moveInput = GetComponent<MovementInput>();
        animator = GetComponentInChildren<Animator>();
        cam = Camera.main;
    }

    private void Update()
    {
        float interacting = Input.GetAxis("Left Trigger");
        if (!isPressingInteractionButton && interacting > 0.01)
        {
            animator.SetBool("IsInteracting", true);
            isPressingInteractionButton = true;
            moveInput.isZoomCamera = true;
        }
        else if (interacting == 0 && isPressingInteractionButton)
        {
            animator.SetBool("IsInteracting", false);
            isPressingInteractionButton = false;
            moveInput.isZoomCamera = false;
        }

        GetInteraction();

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin, cam.transform.forward * 5000000, Color.red);
    }

    private void GetInteraction()
    {
        Ray interactionRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay.origin, cam.transform.forward, out interactionInfo, Mathf.Infinity, interactionLayer))
        {
            bool hit = false;

            if (interactionInfo.collider != null)
            {
                hit = true;
            } else
            {
                hit = false;
            }

            if(hit)
            {
                interactionInfo.collider.GetComponent<Interactable>().Interact();
            }
        }
    }
}
