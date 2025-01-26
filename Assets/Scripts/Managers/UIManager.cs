using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject DeadPanel;
    public GameObject LoadingScreen;
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

    public void OpenDeadScreen()
    {
        DeadPanel.SetActive(true);
    }

    public void RestartScene()
    {
        LevelManager.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
