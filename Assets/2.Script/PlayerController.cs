using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float speed = 5f;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
