using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム全体のデータを管理するスクリプト
/// </summary>
/// GameManager.Instanceで呼び出し
[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private string _playerName;
    private int _score = 0;
    private int _selectedCharactorID;
    private int _selectedRodID;
    private (string, int)[] _rankingData = new (string, int)[3];
    [SerializeField] public List<string> _actionKye ;
    [SerializeField] public List<string> _actionKye2;

    public string Playername
    {
        get => _playerName;
        set => _playerName = value;
    }
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

    public (string, int)[] RankingData
    {
        get => _rankingData;
        private set => _rankingData = value;
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
    void LoadRankingData()
    {
        string json = PlayerPrefs.GetString("RankingData", null);
        _rankingData = JsonUtility.FromJson<(string, int)[]>(json);
    }
    void SaveRankingData()
    {
        string json = JsonUtility.ToJson(_rankingData);
        PlayerPrefs.SetString("RankingData",json);
    }
}