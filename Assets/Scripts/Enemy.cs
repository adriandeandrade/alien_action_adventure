﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float moveSpeed;

    public enum EnemyStates { SLEEP, AWAKE};
    public EnemyStates enemyState;

    public vThirdPersonController player;
    Rigidbody rBody;

    private void Awake()
    {
        enemyState = EnemyStates.SLEEP;
        player = FindObjectOfType<vThirdPersonController>();
        rBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RunStates();
    }

    private void RunStates()
    {
        switch(enemyState)
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
    }

    private void AwakeState()
    {
        Vector3 movementDirection = player.gameObject.transform.position - transform.position;
        Debug.Log(movementDirection.normalized);
        rBody.velocity = movementDirection * moveSpeed;
        transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Damage taken");
    }
}
