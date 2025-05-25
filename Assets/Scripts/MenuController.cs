using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Ana Menü Paneli")]
    public GameObject mainMenuPanel;

    [Header("Ekran Panelleri")]
    public GameObject settingsPanel;
    public GameObject charactersPanel;

    // START tuþuna basýnca:
    public void StartGame()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        SceneManager.LoadScene("SampleScene");  // Sahne adýný birebir yazýn
    }

    // SETTINGS tuþuna basýnca:
    public void OpenSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);

        SceneManager.LoadScene("SettingsScene");
    }
    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

    }

    // CHARACTERS tuþuna basýnca:
    public void OpenCharacters()
    {
        if (charactersPanel != null)
            charactersPanel.SetActive(true);

        SceneManager.LoadScene("CharactersScene");
    }
    public void CloseCharacters()
    {
        if (charactersPanel != null)
            charactersPanel.SetActive(false);
    }
}