using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPivot : MonoBehaviour
{
    Rigidbody rigid;
    [SerializeField] GameObject player;
    private float MouseY;
    private float MouseX;
    public float mouseSensitivity = 400f; //���콺����

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Rotate();
    }

    private void LateUpdate()
    {        
        rigid.MovePosition(player.transform.position);
    }

    private void Rotate()
    {
        MouseX += Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;

        MouseY -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        MouseY = Mathf.Clamp(MouseY, -90f, 90f); //Clamp�� ���� �ּҰ� �ִ밪�� ���� �ʵ�����

        rigid.rotation = Quaternion.Euler(MouseY, MouseX, 0f);// �� ���� �Ѳ����� ���        
    }
}
