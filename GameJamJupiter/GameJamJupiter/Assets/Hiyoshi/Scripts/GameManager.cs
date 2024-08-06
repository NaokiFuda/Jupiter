using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム全体のデータを管理するスクリプト
/// </summary>
/// GameManager.Instanceで呼び出し
[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int _score = 0;
    private int _selectedCharactorID;
    private int _selectedRodID;

    public int Score
    {
        get => _score;
        set => _score = value;
    }

    public int SelectedCharacterID
    {
        get => _selectedCharactorID;
        set
        {
            _selectedCharactorID = value;
        }
    }

    public int SelectedRodID
    {
        get => _selectedRodID;
        set
        {
            _selectedRodID = value;
        }
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