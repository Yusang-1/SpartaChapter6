using UnityEngine;
using UnityEngine.InputSystem;
public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float maxSpeed;
    Rigidbody rigid;
    bool isJump = false;
    Vector3 moveDirection;
    public float mouseSensitivity = 400f; //마우스감도

    private float MouseY;
    private float MouseX;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        Move1();
        Rotate();
    }

    void FixedUpdate()
    {             
        if(Physics.Raycast(rigid.position, Vector3.down, 1.5f, 1 << 6))
        {
            isJump = false;
        }
    }    

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();

        if(dir != null)
        {
            moveDirection = new Vector3(dir.x, 0, dir.y);
        }
    }

    private void Move1()
    {
        if (moveDirection != Vector3.zero)
            rigid.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed == true && isJump == false)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
        }
    }

    private void Rotate()
    {

        MouseX += Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;

        MouseY -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        MouseY = Mathf.Clamp(MouseY, -90f, 90f); //Clamp를 통해 최소값 최대값을 넘지 않도록함

        rigid.rotation = Quaternion.Euler(MouseY, MouseX, 0f);// 각 축을 한꺼번에 계산
    }    
}
