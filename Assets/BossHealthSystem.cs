using UnityEngine;

public class BossHealthSystem : MonoSingleton<BossHealthSystem>
{
    public float Health = 100;

    public void DecreaseHealth(int _health)
    {
        Health = Health - _health;

        if(Health <= 0)
        {
            UIManager.Instance.WinningScreen.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            DecreaseHealth(20);
            Debug.Log(Health);
            Destroy(gameObject);
        }
    }
}
