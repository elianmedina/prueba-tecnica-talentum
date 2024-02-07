using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite image;
    public ItemType type;

    public enum ItemType
    {
        Gun,
        Clothes
    }
}
