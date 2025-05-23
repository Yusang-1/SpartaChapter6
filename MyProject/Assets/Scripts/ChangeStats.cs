using UnityEngine;

public class ChangeStats : MonoBehaviour, IInterfaceStats
{
    StatsCoroutine statsCoroutine;

    public void Start()
    {
        statsCoroutine = GetComponent<StatsCoroutine>();
    }
    public void ChangeStatCoroutine(float time, float amount, int type)
    {
        statsCoroutine.DoCorountine(time, amount, type);
    }

    public float ChangeStat(float energe, float healRate)
    {
        return energe += healRate;
    }

    public float LimitValue(float energe, float min, float max)
    {
        return Mathf.Clamp(energe, min, max);
    }
}
