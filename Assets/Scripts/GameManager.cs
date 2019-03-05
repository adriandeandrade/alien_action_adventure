using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void InitSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    #endregion

    [SerializeField] private GameObject gunPrefab;

    [Header("Game Events and Triggers")]
    public UnityEvent OnPickupGun;

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
        InitSingleton();
    }

    private void InitalizeEvents()
    {
        if(OnPickupGun == null)
        {
            OnPickupGun = new UnityEvent();
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
