using UnityEngine;

public interface InteractableObject
{
    string getObjectData();
}

public class ItemObject : MonoBehaviour, InteractableObject
{
    public ItemData itemData;

    public string getObjectData()
    {
        return $"{itemData.itemName}\n{itemData.description}";
    }
}
