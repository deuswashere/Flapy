using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Mevcut Skor")]
    public int score = 0;
    public TMP_Text scoreText;

    [Header("Yüksek Skor (High Score)")]
    private int highScore = 0;                   // Daha önce kaydedilmiþ en yüksek skor
    public TMP_Text highScoreText;               // Ekranda göstermek için TMP alaný

    [Header("Oyun Sonu UI")]
    public GameObject gameOverUI;

    private bool isGameOver = false;

    // PlayerPrefs anahtar adý
    private const string HighScoreKey = "HighScore";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }

    void Start()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        score = 0;

        // Mevcut skoru ekranda "0" olarak baþlat
        if (scoreText != null)
            scoreText.text = "0";
        else
            Debug.LogWarning("scoreText atamasý yapýlmamýþ! Inspector'da atamayý unutma.");

        // Kaydedilmiþ yüksek skoru PlayerPrefs'ten yükle (yoksa varsayýlan 0)
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        // Yüksek skoru ekranda göster
        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore.ToString();
        else
            Debug.LogWarning("highScoreText atamasý yapýlmamýþ! Inspector'da atamayý unutma.");

        // Game Over paneli kapat
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
            Debug.Log("GameOver panel kapatýldý.");
        }
        else
        {
            Debug.LogWarning("gameOverUI atamasý yapýlmamýþ! Inspector'da atamayý unutma.");
        }
    }

    public void AddScore()
    {
        if (isGameOver) return;

        score++;
        if (scoreText != null)
            scoreText.text = score.ToString();

        // Ses çalma
        FindObjectOfType<SoundManager>().PlaySahur();

        // Eðer mevcut skor, kayýtlý yüksek skoru geçmiþse güncelle
        if (score > highScore)
        {
            highScore = score;

            // PlayerPrefs'e kaydet
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            PlayerPrefs.Save();

            // Yüksek skoru ekranda güncelle
            if (highScoreText != null)
                highScoreText.text = "High Score: " + highScore.ToString();
        }
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

    // Ýsteðe baðlý: Tüm skorlarý (mevcut ve yüksek) sýfýrlamak isterseniz kullanabilirsiniz.
    public void ResetScores()
    {
        // Mevcut skoru sýfýrla
        score = 0;
        if (scoreText != null)
            scoreText.text = "0";

        // Yüksek skoru sýfýrla ve PlayerPrefs'ten sil
        highScore = 0;
        PlayerPrefs.DeleteKey(HighScoreKey);
        if (highScoreText != null)
            highScoreText.text = "High Score: 0";
    }
}