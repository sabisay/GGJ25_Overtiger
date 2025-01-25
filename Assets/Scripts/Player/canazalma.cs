using UnityEngine;

public class canazalma : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Oyuncu ile �arp��may� kontrol et
        if (collision.gameObject.CompareTag("Player")) // "Player" tag'ine sahip bir nesneyle �arp��ma
        {
            PlayerHealthSystem.Instance.DecreaseHealth(1); // 1 can azalt�l�r
            Debug.Log("Kalan Can: " + PlayerHealthSystem.Instance.Health);

        }
    }
}
