using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class StoryText : MonoBehaviour
{
    public List<string> Stories;
    public TextMeshProUGUI textMeshPro;
    private int currentIndex = 0;

    void Start()
    {
        if (Stories.Count > 0)
        {
            textMeshPro.text = Stories[currentIndex]; // �lk metni ekrana yazd�r�yoruz
        }
    }

    public void OnClick()
    {
        if (currentIndex < Stories.Count - 1)
        {
            currentIndex++;
            textMeshPro.text = Stories[currentIndex]; // Sonraki metni ekrana yazd�r�yoruz
        }
        else
        {
            // Son metne gelindi�inde 2 saniye bekleyip kapanmay� ba�lat
            StartCoroutine(CloseAfterDelay(2));
        }
    }

    private IEnumerator CloseAfterDelay(int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
