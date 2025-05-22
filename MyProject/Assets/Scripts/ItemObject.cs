using UnityEngine;

public interface IInteractableObject
{
    string getObjectData();
}

public class ItemObject : MonoBehaviour, IInteractableObject
{
    public ItemData itemData;

    public string getObjectData()
    {
        return $"{itemData.itemName}\n{itemData.description}";
    }
}
