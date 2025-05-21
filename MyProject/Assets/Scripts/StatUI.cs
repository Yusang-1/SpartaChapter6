using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    [SerializeField] RectTransform rectTransformHP;
    [SerializeField] RectTransform rectTransformStamina;
    [SerializeField] Image imageHP;
    private Color imageHPColor;
    [SerializeField] Image imageStamina;
    private Color imageStaminaColor;
    Coroutine coroutine;
    void Start()
    {
        rectTransformHP = GameObject.Find("HP").GetComponent<RectTransform>();
        rectTransformStamina = GameObject.Find("Stamina").GetComponent<RectTransform>();
        imageHP = GameObject.Find("HP").GetComponent<Image>();
        imageStamina = GameObject.Find("Stamina").GetComponent<Image>();
        imageHPColor = imageHP.color;
        imageStaminaColor = imageStamina.color;
    }

    void Update()
    {
        rectTransformStamina.localScale = new Vector3(StatsManager.Instance.playerStats.curStamina / StatsManager.Instance.playerStats.MaxStamina,1,1);
        rectTransformHP.localScale = new Vector3(StatsManager.Instance.playerStats.curHp / StatsManager.Instance.playerStats.MaxHp, 1, 1);
    }

    public void UIBlink(int time, int type)
    {
        coroutine = StartCoroutine(UIBlinkCouroutine(time,type));
    }
    public void UIBlinkStop()
    {
        StopCoroutine(coroutine);
        imageHP.color = imageHPColor;
        imageStamina.color= imageStaminaColor;
    }
    public IEnumerator UIBlinkCouroutine(int time, int type)
    {
        Image image = type == 1 ? imageHP : imageStamina;
        for (int i = 0; i < time*60; i++)
        {
            for(float f = 1f; f > 0.5f; f -= 0.01f)
            {
                Color c = image.color;
                c.a = f;
                image.color = c;
                yield return null;
            }
            yield return new WaitForSecondsRealtime(0.02f);

            for (float f = 1f; f > 0.5f; f -= 0.01f)
            {
                Color c = image.color;
                c.a = f;
                image.color = c;
                yield return null;
            }
        }
    }
}
