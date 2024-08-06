using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private int _score = 0;

    public static GameManager Instance
    {
        get => _instance;
        private set => _instance = value;
    }

    public int Score
    {
        get => _score;
        set => _score = value;
    }

    protected virtual void AwakeFunction()
    {
    }

    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this as GameManager;
            DontDestroyOnLoad(gameObject);
            AwakeFunction();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}