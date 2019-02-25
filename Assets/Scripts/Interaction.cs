using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private LayerMask interactionLayer;

    Camera cam;
    Animator animator;
    MovementInput moveInput;

    public bool isPressingInteractionButton;

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

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, interactionLayer))
        {
            Debug.Log("We hit " + hit.collider.name + " : " + hit.point);
        }
    }

    private void GetInteraction()
    {
        Ray interactionRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.SphereCast(interactionRay, 1f, out interactionInfo, Mathf.Infinity, interactionLayer))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;

            if (interactedObject != null)
            {
                interactedObject.GetComponent<Interactable>().Interact();
            }
        }
    }
}
