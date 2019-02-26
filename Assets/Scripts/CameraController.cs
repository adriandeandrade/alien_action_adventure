using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraMoveSpeed = 120f;
    [SerializeField] private float clampAngle = 80f;
    [SerializeField] private float sensitivity = 150f;
    [SerializeField] private GameObject followTarget;
    [SerializeField] private Vector3 offset;

    float rotY;
    float rotX;

    Camera cam;
    MovementInput movementInput;

    private void Awake()
    {
        cam = Camera.main;
        movementInput = followTarget.GetComponentInParent<MovementInput>();
    }

    private void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Mouse X"); // Get input axises
        float inputY = Input.GetAxis("Mouse Y");

        rotY += inputX * sensitivity * Time.deltaTime; // Increment / decrement rotation values on x and y axis
        rotX += -inputY * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0f);
        transform.rotation = localRotation;
    }

    private void LateUpdate()
    {
        Transform target = followTarget.transform;

        float step = cameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position + offset, step);
    }

    public void SwitchToZoomTarget()
    {
        cam.fieldOfView = 30f;
        movementInput.isZoomCamera = true;
    }

    public void SwitchToOriginalTarget()
    {
        cam.fieldOfView = 50f;
        movementInput.isZoomCamera = false;
    }

    //IEnumerator CameraFovLerp(float lerpTarget)
    //{
    //    float currentFov = cam.fe
    //}
}
