using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;
using UnityEngine.EventSystems;

public class PlayerItemSelect : MonoBehaviour, IDropHandler
{
    public ItemType expectedType;

    public GameObject[] SuperiorCubierto;

    public GameObject BotasCubierto;

    public GameObject Espada;

    public GameObject Martillo;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            if (inventoryItem.item.type == expectedType)
            {
                inventoryItem.parentAfterDrag = transform;
                if(inventoryItem.item.name == "Superior")
                {
                    for(int i = 0; i < SuperiorCubierto.Length; i++)
                    {
                        SuperiorCubierto[i].SetActive(true);
                    }  
                }

                else if (inventoryItem.item.name == "Botas")
                {
                    BotasCubierto.SetActive(true);  
                }

                else if (inventoryItem.item.name == "Espada")
                {
                    Espada.SetActive(true); 
                }

                else if (inventoryItem.item.name == "Martillo")
                {
                    Martillo.SetActive(true);
                }
            }
        }
    }
}