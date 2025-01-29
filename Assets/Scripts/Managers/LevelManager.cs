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
        if (LoadingScreen == null)
            LoadingScreen = UIManager.Instance.LoadingScreen;
        if (LoadingBar == null)
            LoadingBar = UIManager.Instance.LoadingBar;
    }
    public void LoadScene(int levelIndex)
    {
        StartCoroutine(LoadSceneAsync(levelIndex));
    }

    IEnumerator LoadSceneAsync(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        if(LoadingScreen != null)
            LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            if(LoadingBar != null)
                LoadingBar.value = progressValue;
            yield return null;
        }
    }
}
