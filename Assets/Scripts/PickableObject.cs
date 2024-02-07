using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    
    public InventoryController inventoryController;
    public Item itemToPick;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inventoryController.AddItem(itemToPick);
            Destroy(gameObject);          
        }
    }
}
