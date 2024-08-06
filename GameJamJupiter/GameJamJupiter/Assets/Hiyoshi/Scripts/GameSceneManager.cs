using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private GameSceneManager _instance;
    public GameSceneManager Instance
    {
        get => _instance;
        private set
        {
            _instance = value;
        }
    }

    protected virtual void AwakeFunction()
    {
    }

    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this as GameSceneManager;
            DontDestroyOnLoad(gameObject);
            AwakeFunction();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SceneMove(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
