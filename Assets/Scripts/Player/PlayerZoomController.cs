using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoomController : MonoBehaviour
{
    [SerializeField] private LayerMask interactionLayer;

    Camera cam;
    Animator animator;
    vThirdPersonCamera cameraController;

    public bool isZoom;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        cam = Camera.main;
        cameraController = cam.GetComponentInParent<vThirdPersonCamera>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1) && !isZoom)
        {
            animator.SetBool("IsInteracting", true);
            cameraController.ToggleZoomAndSetFov(true, 40f);
            isZoom = true;
        }
        else if (Input.GetMouseButtonUp(1) && isZoom)
        {
            animator.SetBool("IsInteracting", false);
            cameraController.ToggleZoomAndSetFov(false, 60f);
            isZoom = false;
        }
    }
}
