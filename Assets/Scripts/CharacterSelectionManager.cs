using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    public void SelectCharacter(int index)
    {
        CharacterSelector.selectedCharacterIndex = index;
        SceneManager.LoadScene("SampleScene"); // Oyun sahnesinin adýný gir
    }
}
