using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;
    public int numberOfKeys2;
    public int coins;
    public int achievements;

    public void AddItem(Item itemToAdd)
    {
        // Is the item a key?
        if (itemToAdd.isKey)
        {
            numberOfKeys++;
        }
        if (itemToAdd.isKey2)
        {
            numberOfKeys2++;
        }
        else
        {
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}
