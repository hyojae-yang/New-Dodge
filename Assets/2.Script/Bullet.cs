using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    Rigidbody bulletRigdbody;

    private void Start()
    {
        bulletRigdbody = GetComponent<Rigidbody>();
        bulletRigdbody.linearVelocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.Die(gameObject);
            }
            Destroy(gameObject);
        }
        if (other.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
