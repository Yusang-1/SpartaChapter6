using UnityEngine;

public class JumpPanel : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    
    
    private void OnTriggerEnter(Collider other)
    {
        rigid = other.GetComponent<Rigidbody>();

        if(rigid != null)
        {
            rigid.AddForce(Vector3.up * 8, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        rigid = default;
    }
}
