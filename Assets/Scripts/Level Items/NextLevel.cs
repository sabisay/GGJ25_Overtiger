using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().buildIndex != 4)
                LevelManager.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
