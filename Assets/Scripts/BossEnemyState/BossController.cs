using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public enum BossState
    {
        Idle,
        Attack1, // Hareketli Platformlar
        Attack2, // Ateş Topları
        Attack3, // Zıplayan Objeler
        Rest
    }

    public BossState currentState = BossState.Idle;
    public Transform player;
    public GameObject platformPrefab;
    public GameObject fireballPrefab;
    public GameObject bouncingObjectPrefab;
    public float restDuration = 4f;
    public float attackDuration = 3f;

    public Transform[] SpawnPointsForMovingPlatform;
    public Transform[] SpawnPointsFireball;
    public Transform[] SpawnPointsForBouncing;

    public float movingPlatformSpeed = 4f;
    public float fireballSpeed = 4f;
    public float bouncingSpeed = 4f;

    private float restTimer = 0f;
    private float attackTimer = 0f;
    private int attackIndex = 0;

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
            case BossState.Attack3:
                Attack3State();
                break;
            case BossState.Rest:
                RestState();
                break;
        }
    }

    void IdleState()
    {
        // Saldırıya geç
        if (player != null)
        {
            currentState = (BossState)(attackIndex + 1); // Sıradaki saldırıyı başlat
            attackTimer = 0f;
        }
    }

    void Attack1State()
    {
        // Hareketli platformlar oluştur
        if (attackTimer == 0f)
        {
            SpawnMovingPlatforms();
        }

        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDuration)
        {
            currentState = BossState.Rest;
            attackIndex = (attackIndex + 1) % 4; // Sıradaki saldırıyı ayarla
        }
    }

    void Attack2State()
    {
        // Ateş topları oluştur
        if (attackTimer == 0f)
        {
            SpawnFireballs();
        }

        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDuration)
        {
            currentState = BossState.Rest;
            attackIndex = (attackIndex + 1) % 4; // Sıradaki saldırıyı ayarla
        }
    }

    void Attack3State()
    {
        // Zıplayan objeler fırlat
        if (attackTimer == 0f)
        {
            SpawnBouncingObjects();
        }

        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDuration)
        {
            currentState = BossState.Rest;
            attackIndex = (attackIndex + 1) % 4; // Sıradaki saldırıyı ayarla
        }
    }

    void RestState()
    {
        restTimer += Time.deltaTime;
        if (restTimer >= restDuration)
        {
            restTimer = 0f;
            currentState = BossState.Idle;
        }
    }

    void SpawnMovingPlatforms()
    {
        


    }

    IEnumerator WaitForOther()
    {
        Transform randomTransform = FindRandomObjectFromArray(1, SpawnPointsForMovingPlatform);
        StartCoroutine(SpawnMovingPlatformWithVelocity(randomTransform));
        yield return new WaitForSeconds(2f);

        Transform randomTransform2 = FindRandomObjectFromArray(1, SpawnPointsForMovingPlatform);
        while (randomTransform == randomTransform2)
        {
            randomTransform2 = FindRandomObjectFromArray(1, SpawnPointsForMovingPlatform);
        }
        StartCoroutine(SpawnMovingPlatformWithVelocity(randomTransform));
        yield return new WaitForSeconds(2f);

        Transform randomTransform3 = FindRandomObjectFromArray(1, SpawnPointsForMovingPlatform);
        while (randomTransform == randomTransform2 || randomTransform == randomTransform3
            || randomTransform2 == randomTransform3)
        {
            randomTransform3 = FindRandomObjectFromArray(1, SpawnPointsForMovingPlatform);
        }
        StartCoroutine(SpawnMovingPlatformWithVelocity(randomTransform));
        yield return new WaitForSeconds(2f);
    }
    IEnumerator WaitForOther2()
    {
        Transform randomTransform = FindRandomObjectFromArray(1, SpawnPointsFireball);
        StartCoroutine(SpawnFireball(randomTransform));
        yield return new WaitForSeconds(2f);

        Transform randomTransform2 = FindRandomObjectFromArray(1, SpawnPointsFireball);
        while (randomTransform == randomTransform2)
        {
            randomTransform2 = FindRandomObjectFromArray(1, SpawnPointsFireball);
        }
        StartCoroutine(SpawnFireball(randomTransform));
        yield return new WaitForSeconds(2f);

        Transform randomTransform3 = FindRandomObjectFromArray(1, SpawnPointsFireball);
        while (randomTransform == randomTransform2 || randomTransform == randomTransform3
            || randomTransform2 == randomTransform3)
        {
            randomTransform3 = FindRandomObjectFromArray(1, SpawnPointsFireball);
        }
        StartCoroutine(SpawnFireball(randomTransform));
        yield return new WaitForSeconds(2f);
    }

    IEnumerator WaitForOther3()
    {
        Transform randomTransform = FindRandomObjectFromArray(1, SpawnPointsFireball);
        StartCoroutine(SpawnBouncingObject(randomTransform));
        yield return new WaitForSeconds(2f);

        Transform randomTransform2 = FindRandomObjectFromArray(1, SpawnPointsFireball);
        while (randomTransform == randomTransform2)
        {
            randomTransform2 = FindRandomObjectFromArray(1, SpawnPointsFireball);
        }
        StartCoroutine(SpawnBouncingObject(randomTransform));
        yield return new WaitForSeconds(2f);

        Transform randomTransform3 = FindRandomObjectFromArray(1, SpawnPointsFireball);
        while (randomTransform == randomTransform2 || randomTransform == randomTransform3
            || randomTransform2 == randomTransform3)
        {
            randomTransform3 = FindRandomObjectFromArray(1, SpawnPointsFireball);
        }
        StartCoroutine(SpawnBouncingObject(randomTransform));
        yield return new WaitForSeconds(2f);
    }

    IEnumerator SpawnMovingPlatformWithVelocity(Transform spawnTransform)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject gameObject = Instantiate(platformPrefab, spawnTransform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Rigidbody2D>().linearVelocityY = -3f * Time.deltaTime * movingPlatformSpeed;
    }

    Transform FindRandomObjectFromArray(int count,Transform[] transform) 
    {
        for (int i = 0; i < count; i++)
        {
            Transform t = transform[Random.Range(0,transform.Length)];
            return t;
        }
        return default(Transform);
    }

    void SpawnFireballs()
    {
        StartCoroutine(WaitForOther2());
    }
    IEnumerator SpawnFireball(Transform spawnTransform)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject gameObject = Instantiate(fireballPrefab, spawnTransform.position, Quaternion.identity);
        Vector3 direction = player.transform.position - gameObject.transform.position;
        gameObject.GetComponent<Bullet>().SetDirection(direction);
        gameObject.GetComponent<Bullet>().SetInitialPosition(gameObject.transform);
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2();
    }

    void SpawnBouncingObjects()
    {
        StartCoroutine (WaitForOther2());
    }
    IEnumerator SpawnBouncingObject(Transform spawnTransform)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject gameObject = Instantiate(bouncingObjectPrefab, spawnTransform.position, Quaternion.identity);
    }
}