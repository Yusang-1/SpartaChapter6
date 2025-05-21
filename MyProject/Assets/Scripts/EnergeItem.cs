using System.Collections;
using System.Threading;
using UnityEngine;

public class EnergeItem : MonoBehaviour, InterfaceStats
{
    [SerializeField] Material material;
    [SerializeField] StatUI statUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            material.color = new Color(material.color.r, material.color.g, material.color.b, 0);            
            StartCoroutine(cHeal());
            statUI.UIBlink(10, 2);
        }
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

    public IEnumerator cHeal()
    {
        for (float g = 0f; g < 600; g++)
        {
            ContinuousHeal(ref StatsManager.Instance.playerStats.curStamina, 0.2f);
            LimitValue(ref StatsManager.Instance.playerStats.curStamina, StatsManager.Instance.playerStats.MaxStamina);
            yield return null;
        }
        statUI.UIBlinkStop();
        Destroy(this.gameObject);
    }
}
