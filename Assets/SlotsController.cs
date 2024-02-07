using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsController : MonoBehaviour
{
    public GameObject[] slots;

    public string[] childSlotNames;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            SlotsReview();
        }
    }

    public void SlotsReview()
    {
        // Inicializa el arreglo para almacenar los nombres de los hijos
        childSlotNames = new string[slots.Length];


        for (int i = 0; i < slots.Length; i++)
        {
            // Obt�n el componente InventoryItem del hijo si existe
            InventoryItem inventoryItem = slots[i].GetComponentInChildren<InventoryItem>();

            // Si se encuentra un componente InventoryItem, obt�n su nombre, de lo contrario, establece el nombre en null
            childSlotNames[i] = inventoryItem != null ? inventoryItem.item.name : "null";

        }

        Debug.Log(string.Join(", ", childSlotNames));

        // Obtener el diccionario con los elementos espec�ficos y sus �ndices
        Dictionary<string, int> itemsDict = GetSpecificItems(childSlotNames);

        // Imprimir el diccionario
        foreach (var kvp in itemsDict)
        {
            Debug.Log($"Item: {kvp.Key}, Posici�n: {kvp.Value}");
        }
    }

    private Dictionary<string, int> GetSpecificItems(string[] childSlotNames)
    {
        Dictionary<string, int> itemsDict = new Dictionary<string, int>();

        for (int i = 0; i < childSlotNames.Length; i++)
        {
            // Verificar si el nombre del slot no es null o vac�o
            if (!string.IsNullOrEmpty(childSlotNames[i]))
            {
                // Si el nombre del slot es "Espada", "Martillo", "Superior" o "Botas",
                // agregarlo al diccionario junto con su �ndice correspondiente
                if (childSlotNames[i] == "Espada" ||
                    childSlotNames[i] == "Martillo" ||
                    childSlotNames[i] == "Superior" ||
                    childSlotNames[i] == "Botas")
                {
                    itemsDict.Add(childSlotNames[i], i);
                }
            }
            else
            {
                // Si el nombre del slot es null o vac�o, agregarlo al diccionario junto con su �ndice correspondiente
                itemsDict.Add("null", i);
            }
        }

        return itemsDict;
    }
}