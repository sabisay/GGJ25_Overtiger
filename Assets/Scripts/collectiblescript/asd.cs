using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Ses efekti i�in (iste�e ba�l�)

    private int soapCount = 0;
    private int waterCount = 0;
    void Start()
    {
        // Gerekli ba�lang�� ayarlar�n� burada yapabilirsiniz
    }

    void Update()
    {
        // �zel bir animasyon veya d�n�� efekti eklemek isterseniz, bunu burada yapabilirsiniz.
        // �rne�in: S�rekli yava��a d�nme
  
    }

    // �arp��ma tespiti
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Oyuncu etiketi kontrol�
        if (other.CompareTag("sabun"))
        {
            soapCount++;

            // �ste�e ba�l�: Skor art�rma
            // Skor sistemi varsa buradan g�ncelleyebilirsiniz.
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
