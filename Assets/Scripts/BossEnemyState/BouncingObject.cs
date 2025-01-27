using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    public float initialSpeed = 5f; // Ba�lang�� h�z�
    public float bounceForce = 3f; // Z�plama kuvveti
    public float lifetime = 5f; // Objenin ya�am s�resi
    public int damage = 1; // Oyuncuya verilecek hasar

    private Rigidbody2D rb;
    private float lifeTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeTimer = 0f;

        // Rastgele bir y�nde ba�lang�� h�z� ver
        Vector2 direction = new Vector2(2, Random.Range(-3f, 3f)).normalized;
        rb.linearVelocity = direction * initialSpeed;
    }

    void Update()
    {
        // Ya�am s�resini kontrol et
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Yere �arpt���nda z�pla
        if (collision.collider.CompareTag("Ground"))
        {
            Vector2 bounceDirection = Vector2.Reflect(rb.linearVelocity.normalized, collision.contacts[0].normal);
            rb.linearVelocity = bounceDirection * bounceForce;
        }

        // Oyuncuya �arpt���nda hasar ver
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Bouncing object hit the player!");
            PlayerHealthSystem.Instance.DecreaseHealth(25);
            Destroy(gameObject);
        }
    }
}