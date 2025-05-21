using UnityEngine;

public class StatUI : MonoBehaviour
{
    [SerializeField] RectTransform rectTransformHP;
    [SerializeField] RectTransform rectTransformStamina;
    void Start()
    {
        rectTransformHP = GameObject.Find("HP").GetComponent<RectTransform>();
        rectTransformStamina = GameObject.Find("Stamina").GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransformStamina.localScale = new Vector3(StatsManager.Instance.playerStats.curStamina / StatsManager.Instance.playerStats.MaxStamina,1,1);
    }
}
