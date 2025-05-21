using System.Collections;
using System.Threading;
using UnityEngine;

public class EnergeItem : MonoBehaviour
{
    [SerializeField] StatsCoroutine statsCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            statsCoroutine.DoCorountine();
            Destroy(this.gameObject);
        }
    }
   
}
