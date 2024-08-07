using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-10)]
public class RankingTextScript : MonoBehaviour
{
    [SerializeField] private Text[] rankingText;
    private void Start()
    {
        GameManager.Instance.AddRankingData();
        GameManager.Instance.SaveRankingData();
        GameManager.Instance.Score = 0; //Scoreをリセット
        RankingToText();
    }

    void RankingToText() //GameManager内のランキングデータをテキストに出力する
    {
        for (int i = 0; i < GameManager.Instance.RankNum; i++)
        {
            string tmp =
                $"{i + 1}位 : {GameManager.Instance.RankingDataList.rankingDataClassList[i].name.PadRight(10,' ')} スコア{GameManager.Instance.RankingDataList.rankingDataClassList[i].score.ToString("D5")}";
            rankingText[i].text = tmp;
        }
    }
}
