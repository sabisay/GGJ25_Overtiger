using System.Diagnostics;
using UnityEngine;

public class canazalma : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Oyuncu ile �arp��may� kontrol et
        if (collision.gameObject.CompareTag("Player1")) // "Player" tag'ine sahip bir nesneyle �arp��ma
        {
            PlayerHealthSystem.Instance.DecreaseHealth(1); // 1 can azalt�l�r
            UnityEngine.Debug.Log("Kalan Can: " + PlayerHealthSystem.Instance.Health);

        }
    }
}
