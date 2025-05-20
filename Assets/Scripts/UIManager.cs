using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f; // Oyunu yeniden baþlatýrken zamaný sýfýrdan baþlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
