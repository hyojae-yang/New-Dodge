using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public int Hp = 3;
    public Rigidbody Rb;
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        bool isMoving = (xInput != 0 || zInput != 0) ? true : false;

        float xSpeed = xInput * Speed;
        float zSpeed = zInput * Speed;
        Vector3 direction = new Vector3(xSpeed, 0, zSpeed);
        Rb.linearVelocity = direction;

    }
}