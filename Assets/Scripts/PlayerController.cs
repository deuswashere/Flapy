using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;
    private bool isDead = false;

    // Kamera sınırları (dinamik atanacak)
    public float topLimit;
    public float bottomLimit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Kamera boyutuna göre yukarı ve aşağı sınırları otomatik ayarla
        Camera cam = Camera.main;
        bottomLimit = cam.transform.position.y - cam.orthographicSize;
        topLimit = cam.transform.position.y + cam.orthographicSize;
    }

    void Update()
    {
        if (isDead) return;

        // Oyuncu ekran dışına çıktıysa öl
        if (transform.position.y > topLimit || transform.position.y < bottomLimit)
        {
            Die();
        }

        // Tıklama/space ile zıplat
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * flapForce;
            FindObjectOfType<SoundManager>().PlayTung();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (isDead) return;
        Die();
    }

    void Die()
    {
        isDead = true;
        GameManager.Instance.GameOver();
    }
}
