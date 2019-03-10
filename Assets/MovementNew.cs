using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNew : MonoBehaviour
{
    [SerializeField] private Transform faceCameraBone;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float jumpAmount = 10f;
    [SerializeField] float gravity = 8f;
    [SerializeField] float allowPlayerRotation = 0.1f;

    [HideInInspector] public bool isZoomCamera;

    [Range(0, 1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    Vector3 movement;
    Vector3 movementDirection;

    float inputX;
    float inputZ;

    CharacterController controller;
    Animator anim;
    Camera cam;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }

    private void Update()
    {
        InputMagnitude();
        Movement();
    }

    private void LateUpdate()
    {
        if (isZoomCamera)
        {
            faceCameraBone.forward = cam.transform.forward;
            //transform.rotation = Quaternion.LookRotation(cam.transform.forward);
        }
    }

    private void Movement()
    {
        if (controller.isGrounded)
        {
            inputX = Input.GetAxis("Horizontal");
            inputZ = Input.GetAxis("Vertical");

            Vector3 movementInput = new Vector3(inputX, 0f, inputZ);
            movement = transform.TransformDirection(movementInput);
            movement *= moveSpeed;

            if(Input.GetButton("Jump"))
            {
                movement.y = jumpAmount;
            }

        }

        movement.y -= gravity * Time.deltaTime;
        controller.Move(movement * Time.deltaTime);
    }

    private void InputMagnitude()
    {
        //anim.SetFloat("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
        //anim.SetFloat("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

        //Calculate the Input Magnitude
        float speed = new Vector2(inputX, inputZ).sqrMagnitude;

        //Physically move player
        if (speed > allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", speed, StartAnimTime, Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, cam.transform.eulerAngles.y, 0f);
        }
        else if (speed < allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", speed, StopAnimTime, Time.deltaTime);
        }
    }
}
