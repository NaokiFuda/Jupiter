using UnityEngine;
using UnityEngine.UI;

public class RankingTextScript : MonoBehaviour
{
    private Text _rankingText;
    private void Awake()
    {
        _rankingText = GetComponent<Text>();
    }

    private void Start()
    {
        RankingToText();
    }

    public void RankingToText()
    {
        string tmp = $"{GameManager.Instance.RankingDataList.rankingDataClassList[0].name} {GameManager.Instance.RankingDataList.rankingDataClassList[0].score}" +
                     $"\n{GameManager.Instance.RankingDataList.rankingDataClassList[1].name} {GameManager.Instance.RankingDataList.rankingDataClassList[1].score}" +
                     $"\n{GameManager.Instance.RankingDataList.rankingDataClassList[2].name} {GameManager.Instance.RankingDataList.rankingDataClassList[2].score}";
        _rankingText.text = tmp;
    }
}
