using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;



    private void Update()
    {
            
    }

    private void GetDistanceFromPlayer()
    {

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
