using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordText;
    public GameObject[] Hpicon;
    float surviveTime = 0f;
    public bool isGameOver;
    public static int level = 0;
    public static int characterId = 0;
    private void Start()
    {
        isGameOver = false;
        surviveTime = 0f;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "시간: " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    public void EndGame()
    {
        isGameOver = true;
        gameoverText.SetActive(true);

        float BestTime = PlayerPrefs.GetFloat("BestTime");
        if (surviveTime > BestTime)
        {
            BestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", BestTime);
        }
        recordText.text = "최고 기록: " + (int)BestTime;
        Bullet[] bullets = FindObjectsByType<Bullet>(FindObjectsSortMode.None);
        foreach (Bullet bullet in bullets)
        {
            Destroy(bullet.gameObject);
        }
    }

    public void HealthUpdate(int hp)
    {

        for (int i = 0; i < Hpicon.Length; i++)
        {
            Hpicon[i].SetActive(i < hp);
        }
    }
}
