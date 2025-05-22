using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    [SerializeField] InventoryUI inventoryUIScript;
    [SerializeField] GameObject inventoryUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(inventoryUI.activeSelf == false)
            {
                inventoryUIScript.UpdateInventory();
                inventoryUI.SetActive(true);                
            }
            else
            {
                inventoryUI.SetActive(false);
            }
        }
    }
}
