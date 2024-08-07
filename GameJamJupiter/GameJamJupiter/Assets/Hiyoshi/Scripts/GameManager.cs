using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ゲーム全体のデータを管理するスクリプト
/// </summary>
/// GameManager.Instanceで呼び出し
[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private string _playerName; //プレイヤー名
    private int _playerScore = 0; //インゲーム内で獲得できるスコア
    private int _selectedCharactorID; //プレイヤーが使うキャラクターのID
    //private int _selectedRodID;
    private List<RankingDataClass> _rankingDataClasses = new List<RankingDataClass>(4);
    private RankingDataList _rankingDataList = new RankingDataList();
    [SerializeField] public List<string> _actionKye ;
    [SerializeField] public List<string> _actionKye2;

    public string Playername
    {
        get => _playerName;
        set => _playerName = value;
    }
    public int Score
    {
        get => _playerScore;
        set => _playerScore = value;
    }
    public int SelectedCharacterID
    {
        get => _selectedCharactorID;
        set
        {
            _selectedCharactorID = value;
        }
    }
    // public int SelectedRodID
    // {
    //     get => _selectedRodID;
    //     set
    //     {
    //         _selectedRodID = value;
    //     }
    // }

    public RankingDataList RankingDataList
    {
        get => _rankingDataList;
        set => _rankingDataList = value;
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

    private void Start()
    {
        LoadRankingData();//スタート時にランキングデータを読み込む
    }

    public void LoadRankingData() //ランキングのデータを読み込む
    {
        string json = PlayerPrefs.GetString("RankingData");
        RankingDataList = JsonUtility.FromJson<RankingDataList>(json);
    }
    public void SaveRankingData() //ランキングのデータを保存する
    {
        string json = JsonUtility.ToJson(RankingDataList);
        PlayerPrefs.SetString("RankingData",json);
    }
    /// <summary>
    /// ランキングを降順（スコアが多い順）に並べ替える
    /// </summary>
    public void SortRanking()
    {
        _rankingDataList.rankingDataClassList = _rankingDataList.rankingDataClassList
            .OrderByDescending(x => x.score)
            .ToList();
    }

    /// <summary>
    /// ランキングに現在のプレイヤー名とスコアを追加する
    /// </summary>
    public void AddRankingData()
    {
        _rankingDataList.rankingDataClassList.Add(new RankingDataClass(){name = _playerName, score = Score});
        SortRanking();
    }
}
[Serializable]
public class RankingDataClass
{
    public string name;
    public int score;
}
[Serializable]
public class RankingDataList
{
    public List<RankingDataClass> rankingDataClassList;
}