using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject[] BulletPrefab;
    public float spawnRatemin = 0.5f;
    public float spawnRatemax = 1.5f;
    private float spawnRate;
    private float timeAfterSpawn;
    Transform target;
    GameManager gameManager;
    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    private void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRatemin, spawnRatemax);
        target = FindFirstObjectByType<PlayerController>().transform;
    }
    private void Update()
    {
            timeAfterSpawn += Time.deltaTime;
            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;
                spawnRate = Random.Range(spawnRatemin, spawnRatemax);

                GameObject bullet = Instantiate(BulletPrefab[Random.Range(0, BulletPrefab.Length)], transform.position, transform.rotation);
                bullet.transform.LookAt(target);
            }
    }
}
