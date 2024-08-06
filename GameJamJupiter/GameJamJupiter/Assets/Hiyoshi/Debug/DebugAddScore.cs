using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAddScore : MonoBehaviour
{
    public void AddScore(int addScore)
    {
        GameManager.Instance.Score += addScore;
        Debug.Log(GameManager.Instance.Score);
    }
}
