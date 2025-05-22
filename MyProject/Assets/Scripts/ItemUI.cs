using TMPro;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public ItemData itemData;
    public TextMeshProUGUI decriptionUIText;

    private void Start()
    {
        decriptionUIText = transform.parent.parent.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
    }
    public void ShowDescription()
    {
        decriptionUIText.text = $"{itemData.itemName}\n\n{itemData.description}";
    }
}
