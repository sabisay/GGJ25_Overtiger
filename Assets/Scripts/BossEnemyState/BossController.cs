using UnityEngine;

public enum BossState
{
    Idle,
    Attack1,
    Attack2,
    Rest
}
public class BossController : MonoBehaviour
{
    public BossState currentState = BossState.Idle;
    public Transform player;
    public float attack1Speed = 10f;
    public int attack1Count = 3;
    public float attack2ProjectileSpeed = 5f;
    public float attack2FollowDuration = 2f;
    public GameObject projectilePrefab;
    public float restDuration = 3f;

    private int attack1Counter = 0;
    private float restTimer = 0f;
    private Vector3 initialPosition;

    void Start()
    {
        if (player == null)
        {
            player = FindFirstObjectByType<PlayerController>().transform;
        }
        initialPosition = transform.position;
    }

    void Update()
    {
        switch (currentState)
        {
            case BossState.Idle:
                IdleState();
                break;
            case BossState.Attack1:
                Attack1State();
                break;
            case BossState.Attack2:
                Attack2State();
                break;
            case BossState.Rest:
                RestState();
                break;
        }
    }

    void IdleState()
    {
        // Karakterin konumunu belirle ve sald�r�ya ge�
        if (player != null)
        {
            currentState = BossState.Attack1;
        }
    }

    void Attack1State()
    {
        if (attack1Counter < attack1Count)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * attack1Speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, player.position) < 0.5f)
            {
                // Karaktere �arpt�, can azalt
                Debug.Log("Boss hit the player!");
                attack1Counter++;
                transform.position = initialPosition; // Ba�lang�� pozisyonuna d�n
            }
        }
        else
        {
            attack1Counter = 0;
            currentState = BossState.Attack2;
        }
    }

    void Attack2State()
    {
        // 6 adet obje olu�tur ve karaktere do�ru g�nder
        for (int i = 0; i < 6; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Vector3 direction = (player.position - transform.position).normalized;
            projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * attack2ProjectileSpeed;
        }

        currentState = BossState.Rest;
        restTimer = 0f;
    }

    void RestState()
    {
        restTimer += Time.deltaTime;
        if (restTimer >= restDuration)
        {
            currentState = BossState.Idle;
        }
    }
}