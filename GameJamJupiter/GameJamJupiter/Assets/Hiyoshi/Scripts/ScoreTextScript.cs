using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// リザルトでスコアを表示させるスクリプト
/// </summary>
public class ScoreTextScript : MonoBehaviour
{
    private Text _scoreText;

    private void Awake()
    {
        _scoreText = this.gameObject.GetComponent<Text>();
    }
    private void Start()
    {
        _scoreText.text = GameManager.Instance.Score.ToString();
    }
}
