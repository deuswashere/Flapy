using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    public Sprite[] characterSprites; // 4 sprite buraya atanacak
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        int index = CharacterSelector.selectedCharacterIndex;
        spriteRenderer.sprite = characterSprites[index];
    }
}
