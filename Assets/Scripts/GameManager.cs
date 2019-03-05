using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gunPrefab;

    bool hasLog2;
    bool hasGun;
    bool canShoot;

    #region Properties
    public bool HasLog2
    {
        get
        {
            return hasLog2;
        }

        set
        {
            hasLog2 = value;
        }
    }
    public bool HasGun
    {
        get
        {
            return hasGun;
        }

        set
        {
            hasGun = value;
        }
    }
    public bool CanShoot
    {
        get
        {
            return canShoot;
        }

        set
        {
            canShoot = value;
        }
    }
    #endregion

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        
    }

    public void GetGun()
    {
        gunPrefab.SetActive(true);
        hasGun = true;
        canShoot = true;
    }
}
