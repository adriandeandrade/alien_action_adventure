using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask enemyMask;
    public int damage;

    private void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            if(Input.GetKey(KeyCode.V))
            {
                Collider[] enemiesToDamage = Physics.OverlapSphere(attackPos.position, attackRange, enemyMask);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponentInParent<Enemy>().TakeDamage(damage);
                }
            }

            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
