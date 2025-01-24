using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Ses efekti i�in (iste�e ba�l�)
    public AudioClip collectSound;

    // Puanlama sistemi i�in (iste�e ba�l�)
    public int scoreValue = 10;

    void Start()
    {
        // Gerekli ba�lang�� ayarlar�n� burada yapabilirsiniz
    }

    void Update()
    {
        // �zel bir animasyon veya d�n�� efekti eklemek isterseniz, bunu burada yapabilirsiniz.
        // �rne�in: S�rekli yava��a d�nme
        transform.Rotate(Vector3.forward * 50 * Time.deltaTime);
    }

    // �arp��ma tespiti
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Oyuncu etiketi kontrol�
        if (other.CompareTag("Player"))
        {
            // �ste�e ba�l�: Ses efekti �al
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // �ste�e ba�l�: Skor art�rma
            // Skor sistemi varsa buradan g�ncelleyebilirsiniz.
            // ScoreManager.instance.AddScore(scoreValue);

            // Nesneyi yok et
            Destroy(gameObject);
        }
    }
}
