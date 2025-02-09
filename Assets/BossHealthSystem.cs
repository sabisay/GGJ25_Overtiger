using UnityEngine;
using UnityEngine.UI;

public class BossHealthSystem : MonoSingleton<BossHealthSystem>
{
    public float Health = 100;
    public Slider HealthBar;
    public AudioSource _audio;

    private void Start()
    {
        Time.timeScale = 1.0f;
        _audio.Play();
    }

    private void Update()
    {
        if(Health <= 0) 
        {
            Time.timeScale = 0;
            _audio.Pause();
        }
    }
    public void DecreaseHealth(int _health)
    {
        Health = Health - _health;
        HealthBar.value = Health;

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
            collision.gameObject.SetActive(false);
        }
    }

}
