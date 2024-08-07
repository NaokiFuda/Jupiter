using UnityEngine;
using UnityEngine.SceneManagement;
//シーンを変えるスクリプト
public class SceneMoveScript : MonoBehaviour
{
    //unityの file => buildSetting 内のシーンのインデックス番号に対応したシーンを読み込んでいる。
    [SerializeField] private int sceneIndexNum;
    public void SceneMove()
    {
        SceneManager.LoadScene(sceneIndexNum);
    }
}
