using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputPlayerName : MonoBehaviour
{
    private InputField _inputField;
    private void Awake()
    {
        _inputField = this.GetComponent<InputField>();
    }

    public void UpdateName()
    {
        GameManager.Instance.Playername = _inputField.text;
    }
}
