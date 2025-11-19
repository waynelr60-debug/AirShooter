using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public GameObject gameOverPanel;

    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // Jika game over → tekan SPACE untuk restart
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        isGameOver = true;

        // tampilkan UI game over
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // berhentiin semua movement (optional)
        Time.timeScale = 0f;   // pause game
    }

    void RestartGame()
    {
        // reset normal speed
        Time.timeScale = 1f;

        // restart scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
