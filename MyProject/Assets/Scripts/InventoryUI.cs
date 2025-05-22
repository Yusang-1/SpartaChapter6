using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject inventoryImage;
    [SerializeField] Transform inventoryArea;
    [SerializeField] Inventory inventory;
    List<ItemUI> itemUI = new List<ItemUI>();
    public List<GameObject> inventoryImageList = new List<GameObject>();
    List<TextMeshProUGUI> InvNameList = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> InvStackList = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> InvEquippedList = new List<TextMeshProUGUI>();
    List<int> EquippedIndex = new List<int>();
    List<ItemData> itemDataList;
    void Start()
    {
        for (int i = 0; i < 14; i++)
        {
            inventoryImageList.Add(Instantiate(inventoryImage, inventoryArea));
            inventoryImageList[i].name = $"clone{(char)(i + 'A')}";
            InvNameList.Add(inventoryImageList[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>());
            InvStackList.Add(inventoryImageList[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>());
            InvEquippedList.Add(inventoryImageList[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>());
            itemUI.Add(inventoryImageList[i].GetComponent<ItemUI>());
        }

        gameObject.SetActive(false);
    }    

    public void UpdateInventory()
    {
        itemDataList = inventory.InventoryItemData();
        int[] stackArr = inventory.InventoryUIStack();

        for (int i = 0; i < itemDataList.Count; i++)
        {
            InvNameList[i].text = itemDataList[i].itemName;
            InvStackList[i].text = stackArr[i].ToString();
            itemUI[i].itemData = itemDataList[i];
            foreach(int index in EquippedIndex)
            {
                InvEquippedList[index].text = "E";
            }            
        }
    }

    public void DoEquip(int index)
    {
        if((int)itemUI[index].itemData.type != 2)
        {
            EquippedIndex.Add(index);
            UpdateInventory();
        }       
    }
}
