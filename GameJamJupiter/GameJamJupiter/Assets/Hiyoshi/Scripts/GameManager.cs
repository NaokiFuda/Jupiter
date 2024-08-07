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
    private string _playerName = null; //プレイヤー名
    private int _playerScore = 0; //インゲーム内で獲得したスコア
    private int _selectedCharactorID = 0; //プレイヤーが使うキャラクターのID
    static private int _rankNum = 10; //ランキングの順位を何位まで記憶するか
    //private int _selectedRodID;

    private RankingDataListClass _rankingDataListClass = new RankingDataListClass()
    {
        rankingDataClassList = new List<RankingDataClass>(_rankNum + 1)
        {
            new RankingDataClass() { name = "", score = 0 },
            new RankingDataClass() { name = "", score = 0 },
            new RankingDataClass() { name = "", score = 0 },
            new RankingDataClass() { name = "", score = 0 },
            new RankingDataClass() { name = "", score = 0 },
            new RankingDataClass() { name = "", score = 0 },
            new RankingDataClass() { name = "", score = 0 },
            new RankingDataClass() { name = "", score = 0 },
            new RankingDataClass() { name = "", score = 0 },
            new RankingDataClass() { name = "", score = 0 },
            new RankingDataClass() { name = "", score = 0 },
        }
    };

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
        set { _selectedCharactorID = value; }
    }

    // public int SelectedRodID
    // {
    //     get => _selectedRodID;
    //     set
    //     {
    //         _selectedRodID = value;
    //     }
    // }
    public int RankNum
    {
        get => _rankNum;
    }

    public RankingDataListClass RankingDataList
    {
        get => _rankingDataListClass;
        set => _rankingDataListClass = value;
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
        LoadRankingData(); //スタート時にランキングデータを読み込む
    }

    public void LoadRankingData() //ランキングのデータを読み込む
    {
        string json = PlayerPrefs.GetString("RankingData");
        if (json != "")
        {
            RankingDataList = JsonUtility.FromJson<RankingDataListClass>(json);
        }
        else
        {
            RankingDataList = new RankingDataListClass()
            {
                rankingDataClassList = new List<RankingDataClass>(_rankNum + 1)
                {
                    new RankingDataClass() { name = "", score = 0 },
                    new RankingDataClass() { name = "", score = 0 },
                    new RankingDataClass() { name = "", score = 0 },
                    new RankingDataClass() { name = "", score = 0 },
                    new RankingDataClass() { name = "", score = 0 },
                    new RankingDataClass() { name = "", score = 0 },
                    new RankingDataClass() { name = "", score = 0 },
                    new RankingDataClass() { name = "", score = 0 },
                    new RankingDataClass() { name = "", score = 0 },
                    new RankingDataClass() { name = "", score = 0 },
                    new RankingDataClass() { name = "", score = 0 },
                }
            };
        }
    }

    public void SaveRankingData() //ランキングのデータを保存する
    {
        string json = JsonUtility.ToJson(RankingDataList);
        PlayerPrefs.SetString("RankingData", json);
    }

    /// <summary>
    /// ランキングを降順（スコアが多い順）に並べ替える
    /// </summary>
    public void SortRanking()
    {
        _rankingDataListClass.rankingDataClassList = _rankingDataListClass.rankingDataClassList
            .OrderByDescending(x => x.score)
            .ToList();
    }

    /// <summary>
    /// ランキングに現在のプレイヤー名とスコアを追加する
    /// </summary>
    public void AddRankingData()
    {
        _rankingDataListClass.rankingDataClassList[10] = new RankingDataClass() { name = _playerName, score = Score };
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
public class RankingDataListClass
{
    public List<RankingDataClass> rankingDataClassList;
}