using System;
using UnityEngine;
/// <summary>
/// ゲームシーンに居るクラスです インゲームを管理します
/// IngameMAnager.Instance で呼び出して下さい
/// </summary>
[DefaultExecutionOrder(-100)]
public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance = null;
    
    private int _characterID = 0;
    private int _itemID = 0;
    private int _rodID = 0;
    private InGameState _state;
    private GameObject _item;
    private GameObject _camera;
    
    
    public Action<InGameState> OnStateChanged;
    
    
    


    
    
    //public void ATK(enum enum float)
    
    void Awake()
    {
        Instance = this;
    }
    
}
public enum InGameState
{
    Start,
    Fishing,
    Release,
}