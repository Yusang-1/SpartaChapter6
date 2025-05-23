using UnityEngine;

public class UIManager : MonoBehaviour
{    
    public InventoryUI inventoryUIScript;
    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject UseItemUI;

#region ½Ì±ÛÅæ ±¸Çö
    private static UIManager instance;
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
#endregion

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
