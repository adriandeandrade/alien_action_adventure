using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    Rigidbody rBody;

    Vector3 movement;
    Vector3 desiredMovement;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        float movementMag = Mathf.Clamp(movement.magnitude, 0f, 1f);
        Vector3 movementNorm = movement.normalized;
        desiredMovement = movementNorm * movementMag;
        transform.Translate(desiredMovement * moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //rBody.velocity = (desiredMovement * moveSpeed);
    }
}
