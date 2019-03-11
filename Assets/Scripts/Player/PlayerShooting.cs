using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private LayerMask amMask;
    [SerializeField] private LayerMask agMask;
    [SerializeField] private LayerMask taserMask;
    [SerializeField] private float cooldown;

    [SerializeField] private GameObject antiGravitySpot;

    public Text debugGunMode;

    public enum GunMode { AM, AG };
    public GunMode gunMode;

    Camera cam;
    PlayerZoomController interaction;

    float currentModeIndex;
    float nextShotTime;

    [HideInInspector] public bool hasGravityBlueprint;

    private void Awake()
    {
        cam = Camera.main;
        interaction = GetComponent<PlayerZoomController>();
        gunMode = GunMode.AM;
        currentModeIndex = 0;
        debugGunMode.text = "Anti-Matter Mode";
        //SwitchThroughGunModes();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && hasGravityBlueprint)
        {
            SwitchThroughGunModes();
        }

        if (interaction.isZoom && GameManager.instance.CanShoot)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                switch (gunMode)
                {
                    case GunMode.AM:
                        ShootAM();
                        break;
                    case GunMode.AG:
                        ShootAG();
                        break;
                }
            }
        }
    }

    private void ShootAM()
    {
        if (Time.time > nextShotTime)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, amMask))
            {
                hit.transform.gameObject.SetActive(false);
                //Debug.Log(hit.transform.name + " was shot");
            }

            nextShotTime = Time.time + cooldown;
        }
    }

    private void ShootAG()
    {
        if (Time.time > nextShotTime)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
            {
                GameObject agSpot = Instantiate(antiGravitySpot, hit.point, Quaternion.identity);

                //Debug.Log(hit.transform.name + " was shot");
            }

            nextShotTime = Time.time + cooldown;
        }
    }

    private void SwitchThroughGunModes()
    {
        if (currentModeIndex < 1)
            currentModeIndex++;
        else
            currentModeIndex = 0;

        switch (currentModeIndex)
        {
            case 0:
                gunMode = GunMode.AM;
                debugGunMode.text = "Anti-Matter Mode";
                break;
            case 1:
                gunMode = GunMode.AG;
                debugGunMode.text = "Anti-Gravity Mode";
                break;
        }
    }
}
