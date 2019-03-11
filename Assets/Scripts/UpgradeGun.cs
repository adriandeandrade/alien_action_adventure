using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeGun : MonoBehaviour
{
    public PlayerShooting playerShooting;

    public void UpgradeAMGun()
    {
        playerShooting.hasGravityBlueprint = true;
    }
}
