using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private TextMeshProUGUI itemButtonTitleText;

    public void UpdateInventoryUI(InventoryItemData itemData)
    {
        itemDescriptionText.SetText(itemData.objectDescription);
        itemButtonTitleText.SetText(itemData.objectDescriptionTitle);
    }
}
