﻿using System.Collections;
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

    public void ReturnToMenu()
    {
        // unload active level
        UnloadScene(SceneManager.GetActiveScene().name);
        App.screenManager.Show<MenuScreen>();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    public void UnloadScene(string sceneName)
    {
        StartCoroutine(UnloadSceneCoroutine(sceneName));
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

        if(sceneName != "UIScene")
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            App.screenManager.Show<IngameScreen>();
        }
    }

    IEnumerator UnloadSceneCoroutine(string sceneName)
    {
        AsyncOperation operation = SceneManager.UnloadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
        // scene is unloaded
        Debug.Log("scene " + sceneName + " unloaded");
    }
}