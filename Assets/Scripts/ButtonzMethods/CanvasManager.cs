using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject startCanvas; // Start Canvas'ýný buraya sürükleyip býrakýn
    public GameObject GamePanel;

    public Button soundButton; // Ses butonunu buraya sürükleyip býrakýn
    public Sprite soundOnSprite; // Ses açýk olduðunda gösterilecek sprite
    public Sprite soundOffSprite; // Ses kapalý olduðunda gösterilecek sprite

    private bool isSoundOn = true; // Sesin açýk olup olmadýðýný tutan deðiþken

    private void Start()
    {
        Time.timeScale = 0;
        // Oyun baþladýðýnda Start Canvas'ýný aktif, Game Canvas'ýný pasif yap
        startCanvas.SetActive(true);
        GamePanel.SetActive(false);

        // Ses butonuna týklama olayýný ekle
        soundButton.onClick.AddListener(ToggleSound);
    }

    public void ShowStartCanvas()
    {
        startCanvas.SetActive(true);
        GamePanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void ShowGameCanvas()
    {
        startCanvas.SetActive(false);
        GamePanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void ToggleSettingsPanel(GameObject settingsPanel)
    {
        // Settings panelini açýp kapatmak için
        settingsPanel.SetActive(!settingsPanel.activeSelf);
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