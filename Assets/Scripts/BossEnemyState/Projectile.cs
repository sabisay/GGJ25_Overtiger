using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float followDuration = 2f;
    public float speed = 5f;
    private Transform player;
    private float timer = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < followDuration)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Karaktere çarptý, can azalt
            Debug.Log("Projectile hit the player!");
            Destroy(gameObject);
        }
    }
}