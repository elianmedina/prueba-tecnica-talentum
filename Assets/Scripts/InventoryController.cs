using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{

    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public PlayerItemSelect[] playerItemSelects;

    public void AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    public void AddItemForSpecificSlot(Item item, int slotIndex)
    {
        InventorySlot slot = inventorySlots[slotIndex];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot == null)
        {
            SpawnNewItem(item, slot);
            return;
        }
    }

    public void AddItemForSpecificPlayerSlot(Item item, int slotIndex)
    {
        PlayerItemSelect slot = playerItemSelects[slotIndex];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot == null)
        {
            SpawnNewPlayerItem(item, slot);
            return;
        }
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGO = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGO.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    void SpawnNewPlayerItem(Item item, PlayerItemSelect slot)
    {
        GameObject newItemGO = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGO.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

}
