using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject inventoryImage;
    [SerializeField] Transform inventoryArea;
    [SerializeField] Inventory inventory;
    List<GameObject> inventoryImageList = new List<GameObject>();
    List<TextMeshProUGUI> InvNameList = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> InvStackList = new List<TextMeshProUGUI>();
    void Start()
    {
        for (int i = 0; i < 14; i++)
        {
            inventoryImageList.Add(Instantiate(inventoryImage, inventoryArea));
            InvNameList.Add(inventoryImageList[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>());
            InvStackList.Add(inventoryImageList[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>());
        }
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            string[] nameArr = inventory.InventoryUIName();
            int[] stackArr = inventory.InventoryUIStack();

            for (int i = 0; i < nameArr.Length; i++)
            {
                InvNameList[i].text = nameArr[i];
                InvStackList[i].text = stackArr[i].ToString();
            }
        }
    }
}
