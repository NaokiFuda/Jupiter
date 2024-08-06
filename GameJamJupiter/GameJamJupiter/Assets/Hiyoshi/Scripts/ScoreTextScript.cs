using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    private Text _scoreText;
    private Text ScoreText
    {
        get => _scoreText;
        set
        {
            _scoreText = value;
        }
    }

    private void Awake()
    {
        _scoreText = this.gameObject.GetComponent<Text>();
    }

    private void Start()
    {
        ScoreText.text = GameManager.Instance.Score.ToString();
    }
}
