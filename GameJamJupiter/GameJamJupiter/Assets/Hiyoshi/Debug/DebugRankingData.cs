using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRankingData : MonoBehaviour
{
    public void DebugSave()
    {
        RankingDataListClass rankingDataListClass = new RankingDataListClass()
        {
            rankingDataClassList = new List<RankingDataClass>(3)
            {
                new RankingDataClass() { name = "a", score = 100 },
                new RankingDataClass() { name = "b", score = 200 },
                new RankingDataClass() { name = "c", score = 300 }
            }
        };
        GameManager.Instance.RankingDataList = rankingDataListClass;
        GameManager.Instance.SortRanking();
        GameManager.Instance.SaveRankingData();
    }
    public void DebugLoad()
    {
        GameManager.Instance.LoadRankingData();
        string tmp = $"{GameManager.Instance.RankingDataList.rankingDataClassList[0].name} {GameManager.Instance.RankingDataList.rankingDataClassList[0].score}" +
                     $"\n{GameManager.Instance.RankingDataList.rankingDataClassList[1].name} {GameManager.Instance.RankingDataList.rankingDataClassList[1].score}" +
                     $"\n{GameManager.Instance.RankingDataList.rankingDataClassList[2].name} {GameManager.Instance.RankingDataList.rankingDataClassList[2].score}";
        Debug.Log(tmp);
    }

    public void DebugDeleteRanking()
    {
        PlayerPrefs.DeleteAll();
        GameManager.Instance.LoadRankingData();
        Debug.Log("Delete");
    }
}
