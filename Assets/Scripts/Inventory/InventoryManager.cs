using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Inventory Singleton
    public static InventoryManager instance;
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

    public List<GameObject> items;
    [SerializeField] private GameObject inventoryScreen;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject inventoryButtonPrefab;
    [SerializeField] private Transform scrollViewContentParent;

    bool inventoryActive;

    InventoryUI inventoryUI;

    private void Awake()
    {
        InitSingleton();
        inventoryUI = FindObjectOfType<InventoryUI>();
    }

    private void Start()
    {
        inventoryActive = false;
        inventoryScreen.SetActive(inventoryActive);
        Debug.Log("Inventory Exists");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void AddItem(InventoryItemInteractable itemToAdd)
    {
        InventoryItemData newItemData = itemToAdd.data;

        GameObject newButton = Instantiate(inventoryButtonPrefab, scrollViewContentParent);
        InventoryItemButton newButtonData = newButton.GetComponent<InventoryItemButton>();
        newButtonData.Init(itemToAdd);
        items.Add(newButton);
        Destroy(itemToAdd.gameObject);
        ToggleInventory();
        inventoryUI.UpdateInventoryUI(newItemData);
        
    }

    private void ToggleInventory()
    {
        inventoryActive = !inventoryActive;
        inventoryScreen.SetActive(inventoryActive);
        crosshair.SetActive(!inventoryActive);
        Cursor.lockState = inventoryActive ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = inventoryActive;
        float pause = inventoryActive ? 0f : 1f;
        Time.timeScale = pause;
    }
}
