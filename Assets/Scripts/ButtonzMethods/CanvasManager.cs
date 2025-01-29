using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject startCanvas; // Start Canvas'ýný buraya sürükleyip býrakýn
    public GameObject StoryPanel;
    public GameObject GamePanel;
    public GameObject MenuPanel;
    public GameObject CreditsPanel;

    public Button soundButton; // Ses butonunu buraya sürükleyip býrakýn
    public Sprite soundOnSprite; // Ses açýk olduðunda gösterilecek sprite
    public Sprite soundOffSprite; // Ses kapalý olduðunda gösterilecek sprite

    public bool isGamePaused;

    private bool isSoundOn = true; // Sesin açýk olup olmadýðýný tutan deðiþken

    private void Start()
    {
        CreditsPanel.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 0)
            MenuPanel.SetActive(true);
        else
            MenuPanel.SetActive(false);
        if (StoryPanel != null)
            StoryPanel.SetActive(false);
            
    }

    public void ShowStartCanvas()
    {
        startCanvas.SetActive(true);
        GamePanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void ShowStoryCanvas()
    {
        MenuPanel.SetActive(false);
        StoryPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void ShowGameCanvas()
    {
        startCanvas.SetActive(false);
        StoryPanel.SetActive(false);
        GamePanel.SetActive(true);
        CreditsPanel.SetActive(false);
        PlayerController.Instance.enabled = true;
    }

    public void ShowCreditsPanel()
    {
        CreditsPanel.SetActive(!CreditsPanel.activeSelf);

    }
    public void ToggleSettingsPanel(GameObject settingsPanel)
    {
        if (!settingsPanel.activeSelf)
        {
            isGamePaused = true;
        }
        else
        {
            isGamePaused = false;
        }
        // Settings panelini açýp kapatmak için
        bool isSettingsActive = !settingsPanel.activeSelf;
        settingsPanel.SetActive(isSettingsActive);

        // Oyunu durdur veya devam ettir
        Time.timeScale = isSettingsActive ? 0 : 1;

        if(GamePanel != null)
            GamePanel.SetActive(!isSettingsActive);
    }

    public void ToggleSound()
    {
        // Tüm AudioSource bileþenlerini bul
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // Ses durumunu tersine çevir
        isSoundOn = !isSoundOn;

        // Tüm AudioSource bileþenlerini aç veya kapat
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.enabled = isSoundOn;
        }

        // Butonun sprite'ýný güncelle
        soundButton.image.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
    }
}