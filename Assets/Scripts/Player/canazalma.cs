using UnityEngine;

public class canazalma : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Oyuncu ile çarpýþmayý kontrol et
        if (collision.gameObject.CompareTag("Player")) // "Player" tag'ine sahip bir nesneyle çarpýþma
        {
            PlayerHealthSystem.Instance.DecreaseHealth(1); // 1 can azaltýlýr
            Debug.Log("Kalan Can: " + PlayerHealthSystem.Instance.Health);

        }
    }
}
