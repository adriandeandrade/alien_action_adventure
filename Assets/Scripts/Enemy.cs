using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float moveSpeed;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material eyeOn;
    [SerializeField] private Material eyeOff;


    public enum EnemyStates { SLEEP, AWAKE };
    public EnemyStates enemyState;

    vThirdPersonController player;
    Rigidbody rBody;
    NavMeshAgent agent;

    private void Awake()
    {
        enemyState = EnemyStates.SLEEP;
        player = FindObjectOfType<vThirdPersonController>();
        rBody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        meshRenderer.material = eyeOff;
    }

    private void Update()
    {
        RunStates();
    }

    private void RunStates()
    {
        switch (enemyState)
        {
            case EnemyStates.AWAKE:
                AwakeState();
                break;
            case EnemyStates.SLEEP:
                break;
        }
    }

    public void WakeUp()
    {
        enemyState = EnemyStates.AWAKE;
        meshRenderer.material = eyeOn;
    }

    private void AwakeState()
    {
        agent.destination = player.transform.position;

        //Vector3 movementDirection = player.gameObject.transform.position - transform.position;
        //Debug.Log(movementDirection.normalized);
        //rBody.velocity = movementDirection * moveSpeed;
        //transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            //Destroy(gameObject);
        }
        Debug.Log("Damage taken");
    }

    public void Sleep()
    {
        enemyState = EnemyStates.SLEEP;
        meshRenderer.material = eyeOff;
    }
}
