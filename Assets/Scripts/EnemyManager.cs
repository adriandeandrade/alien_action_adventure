using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public void WakeUpAllRobots()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        if(enemies != null)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.WakeUp();
            }
        }
    }
}
