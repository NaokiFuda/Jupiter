using System;
using UnityEngine;
using UnityEngine.UI;
// inputField内に入力されたプレイヤー名をGameManagerのplayerNameに保存させる
public class InputPlayerName : MonoBehaviour
{
    private InputField _inputField;//unityのUIのInputFieldという機能
    private void Awake()
    {
        _inputField = GetComponent<InputField>();
    }

    private void Start()
    {
        _inputField.text = GameManager.Instance.Playername;
    }


    public void UpdateName()//inputFieldの機能でfieldに入力された値が変わったらこのメソッドが行われる
    {
        GameManager.Instance.Playername = _inputField.text;
    }
}
