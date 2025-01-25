using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public Slider HealthBar;
    public TMP_Text SoapText;
    public TMP_Text WaterText;
    public TMP_Text BulletText;

    public void RefreshUI(int Health, int Soap, int Water,int Bullet)
    {
        // Health Bar Update
        HealthBar.value = Health;
        SoapText.text = Soap.ToString();
        WaterText.text = Water.ToString();
        BulletText.text = Bullet.ToString();
    }
}
