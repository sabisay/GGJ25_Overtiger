using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoSingleton<PlayerBullet>
{
    public float speed = 15f;
    private Vector3 _movement;
    private float waitTime = 3f;

    public void Fire(Vector3 direction)
    {
        _movement = direction * Time.deltaTime * speed;
        PlayerHealthSystem.Instance.RefreshUIforBullet();
    }
    
    private void Update()
    {
        transform.position += _movement;
    }

    private void OnEnable()
    {
        StartCoroutine(Deactive(waitTime));
    }

    IEnumerator Deactive(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyShooter>().Die();
            Deactive(0.1f);
        }
    }
}
