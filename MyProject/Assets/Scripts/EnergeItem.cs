using UnityEngine;

public class EnergeItem : MonoBehaviour
{
    [SerializeField] ChangeStats changeStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            changeStats.ChangeStatCoroutine(10, 0.2f, 2);
            Destroy(this.gameObject);
        }
    }   
}
