using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public int Hp = 3;
    public Rigidbody Rb;
    private bool isInvincible = false;
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
    public void Die(GameObject bulletTag)
    {
        if (isInvincible)
        {
            return;
        }
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        if (bulletTag.gameObject.tag == "Dibuff")
        {
            StartCoroutine(DibuffSlow());
            return;
        }
        Hp--;
        gameManager.HealthUpdate(Hp);
        if (Hp == 0)
        {
            gameManager.EndGame();
            gameObject.SetActive(false);
        }
    }
    IEnumerator DibuffSlow()
    {
        float originSpeed = Speed;
        Speed /= 2;
        yield return new WaitForSeconds(3f);
        Speed = originSpeed;
    }
    public void BuffHp()
    {
        if (Hp < 6)
        { Hp++; }
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.HealthUpdate(Hp);
    }
    public void BuffSpeed(int speedpoint)
    {
        Speed += speedpoint;
    }
    public void BuffisInvincible()
    {
        Transform buffEffect = transform.Find("Invincuble");
        if (buffEffect != null)
        {
            buffEffect.gameObject.SetActive(true);
        }
        isInvincible = true;
        Invoke("UnBuffisInvincible", 3f);
    }
    public void UnBuffisInvincible()
    {
        Transform buffEffect = transform.Find("Invincuble");
        if (buffEffect != null)
        {
            buffEffect.gameObject.SetActive(false);
        }
        isInvincible = false;
    }
}