using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateFall : MonoBehaviour
{
    public Transform groundCheck;
    private const float groundedRadius = 0.2f;
    public LayerMask groundMask;

    public bool isGrounded;
    bool canFall;
    Rigidbody rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        canFall = true;
    }

    private void FixedUpdate()
    {
        CheckForGround();
    }

    private void Update()
    {
        if(!isGrounded && canFall)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.down * 0.2f);
    }

    private void CheckForGround()
    {
        isGrounded = false;
        Collider[] groundColliders = Physics.OverlapSphere(groundCheck.position, groundedRadius, groundMask); // Check for ground using ground collision.

        for (int i = 0; i < groundColliders.Length; i++)
        {
            if (groundColliders[i].gameObject != this.gameObject) // Check if we arent colliding with ourselves.
            {
                isGrounded = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("AntiMatter"))
        {
            canFall = false;
            Debug.Log("trigger entered");
        }
    }
}
