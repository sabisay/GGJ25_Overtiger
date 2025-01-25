using UnityEngine;

public class PlayerHealthSystem : MonoSingleton<PlayerHealthSystem>
{
    public int Health = 100;
    public int Soap = 0;
    public int Water = 0;

    public int BulletCount = 5;

    public GunScript GunScript;

    private void Start()
    {
        UIManager.Instance.RefreshUI(Health, Soap, Water, GunScript.Bullet);
    }
    public void DecreaseHealth(int health)
    {
        if (health > 0) 
        {
            Health -= health;
        }
        if (Health <= 0) 
        {
            Debug.Log("dead");
            Debug.Log("Open dead screen");
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
        if (Soap >= 1 && Water >= 1 && GunScript.Bullet == 0)
        {
            Soap -= 1;
            Water -= 1;
            GunScript.AddBullet(BulletCount);
        }
        UIManager.Instance.RefreshUI(Health, Soap, Water, GunScript.Bullet);
    }
}
