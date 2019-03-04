using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDocument : Interactable
{
    public override void Interact()
    {
        InventoryManager.instance.AddItem(this);
        Destroy(gameObject);
    }
}
