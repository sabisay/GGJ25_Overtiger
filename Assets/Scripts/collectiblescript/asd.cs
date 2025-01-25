using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Ses efekti için (isteðe baðlý)

    private int soapCount = 0;
    private int waterCount = 0;
    void Start()
    {
        // Gerekli baþlangýç ayarlarýný burada yapabilirsiniz
    }

    void Update()
    {
        // Özel bir animasyon veya dönüþ efekti eklemek isterseniz, bunu burada yapabilirsiniz.
        // Örneðin: Sürekli yavaþça dönme
  
    }

    // Çarpýþma tespiti
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Oyuncu etiketi kontrolü
        if (other.CompareTag("sabun"))
        {
            soapCount++;

            // Ýsteðe baðlý: Skor artýrma
            // Skor sistemi varsa buradan güncelleyebilirsiniz.
            // ScoreManager.instance.AddScore(scoreValue);

            // Nesneyi yok et
            Destroy(gameObject);
        }
        if (other.CompareTag("su"))
        {
            waterCount++;
            Destroy(gameObject);
        }
    }
}
