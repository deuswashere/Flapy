using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public TMP_Text scoreText;
    public GameObject gameOverUI;

    private bool isGameOver = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        score = 0;

        if (scoreText != null)
            scoreText.text = "0";

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
            Debug.Log("GameOver panel kapatýldý.");
        }
        else
        {
            Debug.LogWarning("GameOverUI atamasý yapýlmamýþ! Inspector'da atamayý unutma.");
        }
    }

    public void AddScore()
    {
        if (isGameOver) return;

        score++;
        if (scoreText != null)
            scoreText.text = score.ToString();
        FindObjectOfType<SoundManager>().PlaySahur();

    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Debug.Log("Game Over panel açýldý.");
        }
        else
        {
            Debug.LogWarning("GameOverUI atanmadýðý için panel açýlamadý.");
        }

        Debug.Log("Game Over oldu");
        FindObjectOfType<SoundManager>().PlayOhNo();

    }

    public void RestartGame()
    {
        Debug.Log("Restart çaðrýldý");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
