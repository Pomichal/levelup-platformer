using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public LoadingScreen loadingScreen;

    void Awake()
    {
        App.gameManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadScene("UIScene", null, false);
    }

    public void ReturnToMenu()
    {
        // unload active level
        UnloadScene(SceneManager.GetActiveScene().name);
        App.screenManager.Show<MenuScreen>();
    }

    public void LoadScene(string sceneName, CommandBase afterSceneLoadedCommand, bool setAsActive)
    {
        loadingScreen.StartLoading();
        StartCoroutine(LoadSceneCoroutine(sceneName, afterSceneLoadedCommand, setAsActive));
    }

    public void UnloadScene(string sceneName)
    {
        loadingScreen.StartLoading();
        StartCoroutine(UnloadSceneCoroutine(sceneName));
    }

    IEnumerator LoadSceneCoroutine(string sceneName, CommandBase afterSceneLoadedCommand, bool setAsActive)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        operation.allowSceneActivation = false;
        while(!operation.isDone)
        {
            loadingScreen.SetSlider(operation.progress);
            if(operation.progress >= 0.9f && !operation.allowSceneActivation)
            {
                operation.allowSceneActivation = true;
            }
            yield return new WaitForSeconds(.1f);
        }

        // scene is loaded
        Debug.Log("scene " + sceneName + " loaded");

        if(afterSceneLoadedCommand != null)
        {
            afterSceneLoadedCommand.Execute();
        }
        if(setAsActive)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }

        loadingScreen.LoadingFinished();

        //if(sceneName != "UIScene")
        //{
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            //App.screenManager.Show<IngameScreen>();
        //}
    }

    IEnumerator UnloadSceneCoroutine(string sceneName)
    {
        AsyncOperation operation = SceneManager.UnloadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            loadingScreen.SetSlider(operation.progress);
            yield return new WaitForSeconds(0.5f);
            //yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
        // scene is unloaded
        loadingScreen.LoadingFinished();
        Debug.Log("scene " + sceneName + " unloaded");
    }
}
