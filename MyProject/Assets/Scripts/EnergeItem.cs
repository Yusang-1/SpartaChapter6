using UnityEngine;

public class EnergeItem : MonoBehaviour, InterfaceStats
{        
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            MomentaryHeal(ref StatsManager.Instance.playerStats.curStamina, 20.0f);

        LimitValue(ref StatsManager.Instance.playerStats.curStamina, StatsManager.Instance.playerStats.MaxStamina);
        Destroy(this.gameObject);
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
        if(energe > max)
        {
            energe = max;
        }
    }
}
