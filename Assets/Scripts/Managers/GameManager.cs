using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private void Start()
    {
        PlayerController.Instance.enabled = false;
        StartCoroutine(WaitForStart());
        DontDestroyOnLoad(gameObject);
    }
    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(2);
        PlayerController.Instance.enabled = true;
    }
}
