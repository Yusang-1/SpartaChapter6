using System.Collections;
using UnityEngine;

public class StatsCoroutine : MonoBehaviour, IInterfaceStats
{
    [SerializeField] StatUI statUI;
    IEnumerator coroutine;

    public void DoCorountine(float time, float amount, int type)
    {
        if(coroutine == null)
        {
            coroutine = cHeal(time, amount, type);
        }
        else
        {
            StopCoroutine(coroutine);
            coroutine = cHeal(time, amount, type);
        }
        StartCoroutine(coroutine);
    }
    public IEnumerator cHeal(float time, float amount, int type)
    {        
        statUI.UIBlink(10, type);
        for (float g = 0f; g < time * 60; g++)
        {
            float fValue = ChangeStat(StatsManager.Instance.playerStats.curStamina, amount);
            fValue = LimitValue(fValue,0, StatsManager.Instance.playerStats.MaxStamina);
            StatsManager.Instance.playerStats.curStamina = fValue;
            yield return null;
        }
        statUI.UIBlinkStop();
    }

    public float ChangeStat(float energe, float healRate)
    {
        return energe += healRate;
    }

    public float LimitValue(float energe,float min, float max)
    {
        return Mathf.Clamp(energe, min, max);
    }
}
