using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItemButton : MonoBehaviour
{
    [SerializeField] private InventoryItemData itemData;
    [SerializeField] private TextMeshProUGUI buttonNameText;

    Button itemButton;

    InventoryUI inventoryUI;

    private void Awake()
    {
        inventoryUI = FindObjectOfType<InventoryUI>();
        buttonNameText = GetComponentInChildren<TextMeshProUGUI>();
        itemButton = GetComponent<Button>();
        itemButton.onClick.AddListener(delegate { OnClickInventoryButton(); });
    }

    public void Init(InventoryItemInteractable item)
    {
        InventoryItemData _itemData = item.data;
        itemData = _itemData;
        Debug.Log(_itemData);
        buttonNameText.SetText(_itemData.objectDescriptionTitle);
    }

    public void OnClickInventoryButton()
    {
        inventoryUI.UpdateInventoryUI(itemData);
    }

}
