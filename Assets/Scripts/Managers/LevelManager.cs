using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoSingleton<LevelManager>
{
    public GameObject LoadingScreen;
    public Slider LoadingBar;

    private void Start()
    {
        LoadingScreen = UIManager.Instance.LoadingScreen;
    }
    public void LoadScene(int levelIndex)
    {
        SaveLoadManager.Instance.LoadGame();
        StartCoroutine(LoadSceneAsync(levelIndex));
    }

    IEnumerator LoadSceneAsync(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingBar.value = progressValue;
            yield return null;
        }
    }
}
