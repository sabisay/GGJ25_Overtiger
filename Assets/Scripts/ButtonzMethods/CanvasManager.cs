using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject startCanvas; // Start Canvas'�n� buraya s�r�kleyip b�rak�n
    public GameObject GamePanel;

    public Button soundButton; // Ses butonunu buraya s�r�kleyip b�rak�n
    public Sprite soundOnSprite; // Ses a��k oldu�unda g�sterilecek sprite
    public Sprite soundOffSprite; // Ses kapal� oldu�unda g�sterilecek sprite

    private bool isSoundOn = true; // Sesin a��k olup olmad���n� tutan de�i�ken

    private void Start()
    {
        Time.timeScale = 0;
        // Oyun ba�lad���nda Start Canvas'�n� aktif, Game Canvas'�n� pasif yap
        startCanvas.SetActive(true);
        GamePanel.SetActive(false);

        // Ses butonuna t�klama olay�n� ekle
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
        // Settings panelini a��p kapatmak i�in
        settingsPanel.SetActive(!settingsPanel.activeSelf);
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