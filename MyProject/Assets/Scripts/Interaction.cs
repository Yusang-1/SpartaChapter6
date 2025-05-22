using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    [SerializeField] float maxHitDistance;
    [SerializeField] LayerMask mask;
    [SerializeField] GameObject InteractUI;
    [SerializeField] TextMeshProUGUI InteractText;
    float searchRate = 0.5f;
    float lastSearchTime = 0;
    GameObject curInteractGameObject;
    Camera cam;
    IInteractableObject interactableObject;
    public void Start()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {       
        if(Time.time - lastSearchTime > searchRate)
        {
            lastSearchTime = Time.time;
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxHitDistance, mask) == true)
            {
                if(hit.collider.gameObject != curInteractGameObject)
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
