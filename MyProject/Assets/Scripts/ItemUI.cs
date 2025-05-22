using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public ItemData itemData;
    public TextMeshProUGUI decriptionUIText;
    [SerializeField] GameObject EquipButton;
    public Button btn;
    private void Start()
    {
        decriptionUIText = transform.parent.parent.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        EquipButton = transform.parent.parent.GetChild(2).GetChild(0).gameObject;
        
    }
    public void ShowDescription()
    {
        if (itemData != null)
            decriptionUIText.text = $"{itemData.itemName}\n\n{itemData.description}";
        btn = EquipButton.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(Equipped);
    }

    public void Equipped()
    {        
        UIManager.Instance.inventoryUIScript.DoEquip(gameObject.name[gameObject.name.Length-1] - 'A');
    }
}
