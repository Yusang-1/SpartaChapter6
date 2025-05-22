using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemData> inventoryItems = new List<ItemData>();
    [SerializeField] List<int> ItemStack = new List<int>();

    public void AddInventory(ItemData itemData)
    {
        int index;
        if (inventoryItems.Contains(itemData) == false)
        {
            inventoryItems.Add(itemData);
            ItemStack.Add(1);
        }
        else
        {
            index = inventoryItems.LastIndexOf(itemData);
            if (ItemStack[index] < itemData.maxStack)
            {
                ItemStack[index]++;
            }
            else
            {
                inventoryItems.Add(itemData);
                ItemStack.Add(1);
            }
        }
    }
}
