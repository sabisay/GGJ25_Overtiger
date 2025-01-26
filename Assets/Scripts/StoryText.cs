using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic; // TMPro namespace ekliyoruz

public class StoryText : MonoBehaviour
{
    public List<string> Stories;
    public TextMeshProUGUI textMeshPro; // TextMeshPro'yu buraya ekliyoruz
    private int currentIndex = 0;
    public GameObject menuCanvas;
    public GameObject pnael;

    void Start()
    {
        PlayerController.Instance.gameObject.SetActive(false);
        menuCanvas.SetActive(false);
        if (Stories.Count > 0)
        {
            textMeshPro.text = Stories[currentIndex]; // Ýlk metni ekrana yazdýrýyoruz
        }
    }

    void Update()
    {
        // Ekranýn herhangi bir yerine týklama algýlama (sol fare tuþu)
        if (Input.GetMouseButtonDown(0)) // 0: Sol fare tuþu
        {
            OnClick();
        }
    }

    public void OnClick()
    {
        if (currentIndex < Stories.Count - 1)
        {
            currentIndex++;
            textMeshPro.text = Stories[currentIndex]; // Sonraki metni ekrana yazdýrýyoruz
        }
        else
        {
            // Son metne gelindiðinde 2 saniye bekleyip kapanmayý baþlat
            StartCoroutine(CloseAfterDelay(1));
        }
    }

    public void CanvasClose()
    {
        menuCanvas.SetActive(true);
    }

    private IEnumerator CloseAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        menuCanvas.SetActive(true);
        Destroy(pnael);
    }
}
