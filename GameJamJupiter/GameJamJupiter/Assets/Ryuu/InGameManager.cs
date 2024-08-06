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
    [SerializeField] private int _itemID = 0;
    private int _rodID = 0;
    private InGameState _state;
    private Result _result;
    private Angle _angle;
    private GameObject _cameraTarget;
    private GameObject _camera;

    public GameObject CameraTarget
    {
        get => _cameraTarget;
        set
        {
            _cameraTarget = value;
            OnCameraTargetChanged?.Invoke(_cameraTarget);
        }
    }

    public InGameState State
    {
        get => _state;
        set
        {
            _state = value;
            OnStateChanged?.Invoke(_state);
        }
    }

    public Action<InGameState> OnStateChanged;
    public Action<GameObject> OnCameraTargetChanged;

//バックグラウンド工場
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