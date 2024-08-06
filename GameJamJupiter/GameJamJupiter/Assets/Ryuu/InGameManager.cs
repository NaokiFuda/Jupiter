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
    private Result _result;
    private Angle _angle;
    private float _pow;
    private GameObject _cameraTarget;
    private GameObject _camera;
    [SerializeField] private GameObject _itemprefab;

    public Result Result
    {
        get => _result;
        set => _result = value;
    }

    public Angle Angle
    {
        get => _angle;
        set => _angle = value;
    }

    public float Pow
    {
        get => _pow;
        set => _pow = value;
    }

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
    public Action<Angle, Result, float> OnResult;

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