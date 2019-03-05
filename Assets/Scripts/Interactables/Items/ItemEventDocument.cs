using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEventDocument : Interactable
{
    public Interactable controlPanel;

    public override void Interact()
    {
        InventoryManager.instance.AddItem(this);
        GameManager.instance.HasLog2 = true;
        MakeControlPanelInteractable();
        Destroy(gameObject);
    }

    private void MakeControlPanelInteractable()
    {
        controlPanel.isInteractable = true;
    }
}
