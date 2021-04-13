using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        App.gameManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadScene("UIScene");
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        operation.allowSceneActivation = false;
        while(!operation.isDone)
        {
            if(operation.progress >= 0.9f && !operation.allowSceneActivation)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }

        // scene is loaded
        Debug.Log("scene " + sceneName + " loaded");
    }
}
