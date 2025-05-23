using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Interaction : MonoBehaviour
{
    [SerializeField] float maxHitDistance;
    [SerializeField] LayerMask mask;
    [SerializeField] GameObject InteractUI;
    [SerializeField] TextMeshProUGUI InteractText;
    [SerializeField] Inventory inventory;
    [SerializeField] InventoryUI inventoryUI;
    float searchRate = 0.5f;
    float lastSearchTime = 0;
    GameObject curInteractGameObject;
    Camera cam;
    IInteractableObject interactableObject;
    public void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (InteractUI.activeSelf == true && Input.GetKeyDown(KeyCode.E))
        {
            inventory.AddInventory(curInteractGameObject.GetComponent<ItemObject>().itemData);
            curInteractGameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (Time.time - lastSearchTime > searchRate && inventoryUI.gameObject.activeSelf == false)
        {
            lastSearchTime = Time.time;
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxHitDistance, mask) == true)
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    interactableObject = hit.collider.GetComponent<IInteractableObject>();
                    ShowUI();                    
                }
            }
            else
            {
                curInteractGameObject = null;
                InteractUI.SetActive(false);
            }
        }
    }

    void ShowUI()
    {
        InteractUI.SetActive(true);
        InteractText.text = interactableObject.getObjectData();
    }
}
