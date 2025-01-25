using UnityEngine;

public class PlayerHealthSystem : MonoSingleton<PlayerHealthSystem>
{
    public int Health = 100;
    public int Stamina = 0;
    public int Soap = 0;
    public int Water = 0;

    private void Start()
    {
        UIManager.Instance.RefreshUI(Health, Soap, Water);
    }
    public void DecreaseHealth(int health)
    {
        Health -= health;
        if (Health <= 0) 
        {
            Debug.Log("dead");
            Debug.Log("Open dead screen");
        }
        UIManager.Instance.RefreshUI(Health, Soap, Water);
    }

    public void DecreaseStamina(int stamina) 
    {
        if (Stamina + stamina <= 0) 
        {
            Stamina -= stamina;
        }
        UIManager.Instance.RefreshUI(Health, Soap, Water);
    }

    public void AddWater(int water)
    {
        Water += water;
        GetStamina();
        UIManager.Instance.RefreshUI(Health, Soap, Water);
    }

    public void AddSoap(int soap)
    {
        Soap += soap;
        GetStamina();
        UIManager.Instance.RefreshUI(Health,Soap,Water);
    }

    private void GetStamina()
    {
        if (Soap >= 1 && Water >= 1 && Stamina == 0)
        {
            Soap -= 1;
            Water -= 1;
            Stamina = 100;
        }
    }
}
