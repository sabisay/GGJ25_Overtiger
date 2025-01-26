using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
