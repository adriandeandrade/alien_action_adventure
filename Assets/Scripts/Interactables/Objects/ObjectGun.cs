using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGun : Interactable
{
    public override void Interact()
    {
        InventoryManager.instance.AddItem(this);
        GameManager.instance.OnPickupGun.Invoke();
        Destroy(gameObject);
    }
}
