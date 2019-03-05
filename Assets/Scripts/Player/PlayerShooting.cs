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

    public Text debugGunMode;

    public enum GunMode { AM, AG, Taser };
    public GunMode gunMode;

    Camera cam;
    Interaction interaction;

    float currentModeIndex;

    float nextShotTime;

    private void Awake()
    {
        cam = Camera.main;
        interaction = GetComponent<Interaction>();
    }

    private void Update()
    {
        SwitchThroughGunModes();

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
                    case GunMode.Taser:
                        ShootTaser();
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
                Debug.Log(hit.transform.name + " was shot");
            }

            nextShotTime = Time.time + cooldown;
        }
    }

    private void ShootAG()
    {
        if (Time.time > nextShotTime)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, agMask))
            {
                Rigidbody rBody = hit.transform.GetComponent<Rigidbody>();

                if (!rBody.isKinematic)
                    rBody.isKinematic = true;
                else
                    rBody.isKinematic = false;

                Debug.Log(hit.transform.name + " was shot");
            }

            nextShotTime = Time.time + cooldown;
        }
    }

    private void ShootTaser()
    {
        if (Time.time > nextShotTime)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, taserMask))
            {
                Debug.Log(hit.transform.name + " was shot");
            }

            nextShotTime = Time.time + cooldown;
        }
    }

    private void SwitchThroughGunModes()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (currentModeIndex < 2)
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
                case 2:
                    gunMode = GunMode.Taser;
                    debugGunMode.text = "Taser Mode";
                    break;
            }
        }
    }
}
