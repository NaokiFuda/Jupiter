using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//シーンを変えるスクリプト
public class SceneMoveScript : MonoBehaviour
{
    //unityのfile => buildSetting内のシーンのインデックス番号に対応したシーンを読み込んでいる。
    [SerializeField] private int sceneIndexNum;
    public void SceneMove()
    {
        SceneManager.LoadScene(sceneIndexNum);
    }
}
