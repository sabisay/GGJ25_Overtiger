using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject startCanvas; // Start Canvas'�n� buraya s�r�kleyip b�rak�n
    public GameObject StoryPanel;
    public GameObject GamePanel;
    public GameObject MenuPanel;

    public Button soundButton; // Ses butonunu buraya s�r�kleyip b�rak�n
    public Sprite soundOnSprite; // Ses a��k oldu�unda g�sterilecek sprite
    public Sprite soundOffSprite; // Ses kapal� oldu�unda g�sterilecek sprite

    public bool isGamePaused;

    private bool isSoundOn = true; // Sesin a��k olup olmad���n� tutan de�i�ken

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
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
    }

    public void ShowStoryCanvas()
    {
        MenuPanel.SetActive(false);
        StoryPanel.SetActive(true);
    }

    public void ShowGameCanvas()
    {
        startCanvas.SetActive(false);
        StoryPanel.SetActive(false);
        GamePanel.SetActive(true);
        PlayerController.Instance.enabled = true;
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
        // Settings panelini a��p kapatmak i�in
        bool isSettingsActive = !settingsPanel.activeSelf;
        settingsPanel.SetActive(isSettingsActive);

        // Oyunu durdur veya devam ettir
        Time.timeScale = isSettingsActive ? 0 : 1;

        // GamePanel'i a��p kapatmak i�in
        GamePanel.SetActive(!isSettingsActive);
    }

    public void ToggleSound()
    {
        // T�m AudioSource bile�enlerini bul
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // Ses durumunu tersine �evir
        isSoundOn = !isSoundOn;

        // T�m AudioSource bile�enlerini a� veya kapat
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.enabled = isSoundOn;
        }

        // Butonun sprite'�n� g�ncelle
        soundButton.image.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
    }
}