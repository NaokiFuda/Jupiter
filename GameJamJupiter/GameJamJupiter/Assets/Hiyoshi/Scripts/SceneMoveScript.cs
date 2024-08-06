using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveScript : MonoBehaviour
{
    [SerializeField] private int sceneIndexNum;
    public void SceneMove()
    {
        SceneManager.LoadScene(sceneIndexNum);
    }
}
