using System;
using UnityEngine;

/// <summary>
/// ゲームシーンに居るクラスです インゲームを管理します
/// IngameMAnager.Instance で呼び出して下さい
/// </summary>
[DefaultExecutionOrder(-99)]
public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance = null;
    private int _characterID = 0;
    private int _itemID = 0;
    private int _rodID = 0;
    private InGameState _state;
    private FlyPreparationState _flyPreparationState;

    private int _flyAngle;
    private float _flyCharge;
    private int _tecnic;

    private GameObject _cameraTarget;
    private GameObject _camera;
    [SerializeField] private GameObject _itemprefab;
    [SerializeField] private GameObject _spawnpoint;


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

    public FlyPreparationState FlyPreparationState
    {
        get => _flyPreparationState;
        set
        {
            _flyPreparationState = value;
            OnFlyPreparationStateChanged?.Invoke(_flyPreparationState);
        }
    }


    public Action<InGameState> OnStateChanged;
    public Action<FlyPreparationState> OnFlyPreparationStateChanged;
    public Action<GameObject> OnCameraTargetChanged;
    public Action OnInputAction1Dawn;
    public Action OnInputAction2Dawn;
    public Action OnInputAction1Up;
    public Action OnInputAction2Up;

    void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        OnStateChanged += InGameStateAction;
        OnInputAction1Dawn += ActionDawn1;
        OnInputAction1Up += ActionUp1;
        OnInputAction2Up += ActionUp2;
        OnFlyPreparationStateChanged += FlyPreparationStateAction;
    }

    private void OnDisable()
    {
        OnStateChanged -= InGameStateAction;
        OnInputAction1Dawn -= ActionDawn1;
        OnInputAction1Up -= ActionUp1;
        OnInputAction2Up -= ActionUp2;
        OnFlyPreparationStateChanged -= FlyPreparationStateAction;
    }

    private void InGameStateAction(InGameState state)
    {
        if (state == InGameState.Start)
        {
            Debug.Log("start");
        }
        else if (state == InGameState.Fishing)
        {
            Debug.Log("fishing");
        }
        else if (state == InGameState.ReleaseUP)
        {
            Debug.Log(" release up");
        }
        else if (state == InGameState.ReleaseDawn)
        {
            Debug.Log(" release dawn");
        }
        else if (state == InGameState.ReleaseEnd)
        {
            Debug.Log(" release end");
        }
    }


    private void ActionDawn1()
    {
        if (_flyPreparationState == FlyPreparationState.Angle)
        {
            _flyPreparationState = FlyPreparationState.Charge;
        }
    }

    private void ActionUp1()
    {
        if (_flyPreparationState == FlyPreparationState.Charge)
        {
            _flyPreparationState = FlyPreparationState.Set;
        }
    }

    private void ActionUp2()
    {
        if (_flyPreparationState == FlyPreparationState.Set)
        {
            _flyPreparationState = FlyPreparationState.Fire;
        }
    }

    private void FlyPreparationStateAction(FlyPreparationState state)
    {
        if (state == FlyPreparationState.Fire)
        {
            var item = Instantiate(_itemprefab, _spawnpoint.transform.position, Quaternion.identity);
            item.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,1));
        }
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

public enum FlyPreparationState
{
    Default,
    Angle,
    Charge,
    Set,
    Fire
}