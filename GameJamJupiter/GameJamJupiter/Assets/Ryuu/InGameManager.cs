using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

/// <summary>
/// ゲームシーンに居るクラスです インゲームを管理します
/// IngameMAnager.Instance で呼び出して下さい
/// </summary>
[DefaultExecutionOrder(-100)]
public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance = null;

    private int _characterID = 0;
    [SerializeField] private int _itemID = 0;
    private int _rodID = 0;
    private InGameState _state;

    public InGameState State
    {
        get => _state;
        set
        {
            _state = value;
            OnStateChanged?.Invoke(_state);
        }
    }

    private GameObject _item;
    private GameObject _camera;


    public Action<InGameState> OnStateChanged;


    


    
    public void ZoomedIn()
    {
        _camera.transform.position = new Vector3(0, 0, -10);
    }
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
    ReleaseUP,
    ReleaseDawn,
    ReleaseEnd
}