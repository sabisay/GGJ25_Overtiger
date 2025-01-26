using System.Collections;
using UnityEngine;

public class PlayerHealthSystem : MonoSingleton<PlayerHealthSystem>
{
    public AudioSource deathMusic;

    public int Health = 100;
    public int Soap = 0;
    public int Water = 0;

    public int BulletCount = 5;

    public GunScript GunScript;
    private PlayerController playerController;

    private void Start()
    {
        UIManager.Instance.RefreshUI(Health, Soap, Water, GunScript.Bullet);
        playerController = GetComponent<PlayerController>();
    }
    public void DecreaseHealth(int health)
    {
        if (Health > 0) 
        {
            Health -= health;
        }
        if (Health <= 0)
        {

            StartCoroutine(Dead());
        }
        UIManager.Instance.RefreshUI(Health, Soap, Water, GunScript.Bullet);
    }

    public void AddWater(int water)
    {
        Water += water;
        GetStamina();
        UIManager.Instance.RefreshUI(Health, Soap, Water, GunScript.Bullet);
    }

    public void AddSoap(int soap)
    {
        Soap += soap;
        GetStamina();
        UIManager.Instance.RefreshUI(Health,Soap,Water, GunScript.Bullet);
    }

    private void GetStamina()
    {
        if (Soap >= 1 && Water >= 1)
        {
            Soap -= 1;
            Water -= 1;
            GunScript.AddBullet(BulletCount);
        }
        UIManager.Instance.RefreshUI(Health, Soap, Water, GunScript.Bullet);
    }

    IEnumerator Dead()
    {
        //playerController.animator
        yield return new WaitForSeconds(0.1f);
        UIManager.Instance.OpenDeadScreen();

        deathMusic.Play();
        
        Time.timeScale = 0.0f;
    }
}
