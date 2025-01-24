using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Ses efekti için (isteðe baðlý)
    public AudioClip collectSound;

    // Puanlama sistemi için (isteðe baðlý)
    public int scoreValue = 10;

    void Start()
    {
        // Gerekli baþlangýç ayarlarýný burada yapabilirsiniz
    }

    void Update()
    {
        // Özel bir animasyon veya dönüþ efekti eklemek isterseniz, bunu burada yapabilirsiniz.
        // Örneðin: Sürekli yavaþça dönme
        transform.Rotate(Vector3.forward * 50 * Time.deltaTime);
    }

    // Çarpýþma tespiti
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Oyuncu etiketi kontrolü
        if (other.CompareTag("Player"))
        {
            // Ýsteðe baðlý: Ses efekti çal
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // Ýsteðe baðlý: Skor artýrma
            // Skor sistemi varsa buradan güncelleyebilirsiniz.
            // ScoreManager.instance.AddScore(scoreValue);

            // Nesneyi yok et
            Destroy(gameObject);
        }
    }
}
