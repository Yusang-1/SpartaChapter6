using System.Collections;
using UnityEngine;

public class StatsCoroutine : MonoBehaviour, InterfaceStats
{
    [SerializeField] StatUI statUI;
    IEnumerator coroutine;

    public void DoCorountine()
    {
        if(coroutine == null)
        {
            coroutine = cHeal();
        }
        else
        {
            StopCoroutine(coroutine);
            coroutine = cHeal();
        }
        StartCoroutine(coroutine);
    }
    public IEnumerator cHeal()
    {
        statUI.UIBlink(10, 2);
        for (float g = 0f; g < 600; g++)
        {
            ContinuousHeal(ref StatsManager.Instance.playerStats.curStamina, 0.2f);
            LimitValue(ref StatsManager.Instance.playerStats.curStamina, StatsManager.Instance.playerStats.MaxStamina);
            yield return null;
        }
        statUI.UIBlinkStop();
    }

    public void ContinuousHeal(ref float energe, float healRate)
    {
        energe += healRate;
    }

    public void MomentaryHeal(ref float energe, float healRate)
    {
        energe += healRate;
    }

    public void LimitValue(ref float energe, float max)
    {
        if (energe > max)
        {
            energe = max;
        }
    }
}
