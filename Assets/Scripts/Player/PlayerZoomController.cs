using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoomController : MonoBehaviour
{
    [SerializeField] private LayerMask interactionLayer;

    Camera cam;
    Animator animator;
    MovementInput moveInput;
    CameraController cameraController;

    public bool isZoom;

    private void Awake()
    {
        moveInput = GetComponent<MovementInput>();
        animator = GetComponentInChildren<Animator>();
        cam = Camera.main;
        cameraController = cam.GetComponentInParent<CameraController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isZoom)
        {
            animator.SetBool("IsInteracting", true);
            cameraController.ToggleZoomAndSetFov(true, 30f);
            isZoom = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && isZoom)
        {
            animator.SetBool("IsInteracting", false);
            cameraController.ToggleZoomAndSetFov(false, 40f);
            isZoom = false;
        }
    }
}
