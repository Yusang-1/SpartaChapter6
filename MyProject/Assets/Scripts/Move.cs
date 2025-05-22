using UnityEngine;
public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float maxSpeed;
    Rigidbody rigid;
    Camera cam;
    bool isJump = false;

    public float mouseSensitivity = 400f; //���콺����

    private float MouseY;
    private float MouseX;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Application.targetFrameRate = 60;
        cam = Camera.main;
    }

    private void Update()
    {
        Rotate();
    }

    void FixedUpdate()
    {
        Move1();
        Jump();       

        if(Physics.Raycast(rigid.position, Vector3.down, 1.5f, 1 << 6))
        {
            isJump = false;
        }
    }

    private void Move1()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(Vector3.forward * moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector3.left * moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(Vector3.back * moveSpeed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(Vector3.right * moveSpeed, ForceMode.Acceleration);
        }
    }

    void Jump()
    {
        if (isJump) return;

        if (Input.GetKey(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
        }
    }

    private void Rotate()
    {

        MouseX += Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;

        MouseY -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        MouseY = Mathf.Clamp(MouseY, -90f, 90f); //Clamp�� ���� �ּҰ� �ִ밪�� ���� �ʵ�����

        rigid.rotation = Quaternion.Euler(MouseY, MouseX, 0f);// �� ���� �Ѳ����� ���
    }    
}
