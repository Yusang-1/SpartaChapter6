using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] GameObject cameraPivot;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float maxSpeed;
    Rigidbody rigid;
    Rigidbody CameraRigid;
    bool isJump = false;
    Vector3 moveDirection;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        CameraRigid = cameraPivot.GetComponent<Rigidbody>();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        Move1();
        Rotation();
    }

    void FixedUpdate()
    {             
        if(Physics.Raycast(rigid.position, Vector3.down, 0.51f, 1 << 6))
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
        {
            rigid.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed == true && isJump == false)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
        }
    }

    void Rotation()
    {
        rigid.rotation = CameraRigid.rotation;
    }
}
