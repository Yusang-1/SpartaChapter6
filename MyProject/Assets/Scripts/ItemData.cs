using UnityEngine;

public enum ItemTypeEnum
{
    Equipable,
    Consumable,
    Resources
}

public enum ConsumableTypeEnum
{
    Hp,
    Stamina
}
[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableTypeEnum type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string description;
    public ItemTypeEnum type;
    public GameObject dropPrefeb;

    [Header("Stack")]
    public bool isStackable;
    public int maxStack;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}
