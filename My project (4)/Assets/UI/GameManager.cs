using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // WAJIB ADA untuk akses teks TMP

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public GameObject gameOverPanel;
    public TMP_Text scoreText; // <--- Variabel baru buat teks skor

    private bool isGameOver = false;
    private int currentScore = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // BARU: Reset skor jadi 0 saat mulai
        currentScore = 0;
        UpdateScoreUI();
    }

    void Update()
    {
        // Jika game over → tekan SPACE untuk restart
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return; // Kalau game over, gak bisa nambah skor

        currentScore += amount;
        UpdateScoreUI();
    }

    // BARU: Fungsi update tampilan teks
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    void RestartGame()
    {
        // reset normal speed
        Time.timeScale = 1f;

        // restart scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
