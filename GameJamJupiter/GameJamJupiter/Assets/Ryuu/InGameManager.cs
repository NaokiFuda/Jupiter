using System;
using System.Threading.Tasks;
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
    private int _score = 0;

    

    private int _flyAngle;

    public int FlyAngle
    {
        get => _flyAngle;
        set
        {
            _flyAngle = value;
            OnFlyAngleChanged?.Invoke(value);
        }
    }

    public int FlyCharge
    {
        get => _flyCharge;
        set
        {
            _flyCharge = value;
            OnFlyChargeChanged?.Invoke(value);
        }
    }
    
    public int Score
    {
        get => _score;
        set => _score = value;
    }

    private int _flyCharge;
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
            OnStateChanged?.Invoke(value);
        }
    }

    public FlyPreparationState FlyPreparationState
    {
        get => _flyPreparationState;
        set
        {
            _flyPreparationState = value;
            OnFlyPreparationStateChanged?.Invoke(value);
        }
    }

    public Action<InGameState> OnStateChanged;
    public Action<FlyPreparationState> OnFlyPreparationStateChanged;
    public Action<GameObject> OnCameraTargetChanged;
    public Action OnInputAction1Dawn;
    public Action OnInputAction2Dawn;
    public Action OnInputAction1Up;
    public Action OnInputAction2Up;
    public Action<int> OnFlyAngleChanged;
    public Action<int> OnFlyChargeChanged;

    private bool _isCharging = false;

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
        if (FlyPreparationState == FlyPreparationState.Angle)
        {
            FlyPreparationState = FlyPreparationState.Charge;
        }
    }

    private void ActionUp1()
    {
        if (FlyPreparationState == FlyPreparationState.Charge)
        {
            FlyPreparationState = FlyPreparationState.Set;
            _isCharging = false;
        }
    }

    private void ActionUp2()
    {
        if (FlyPreparationState == FlyPreparationState.Set)
        {
            FlyPreparationState = FlyPreparationState.Fire;
        }
    }

    private void FlyPreparationStateAction(FlyPreparationState state)
    {
        if (state == FlyPreparationState.Angle)
        {
            State = InGameState.Fishing;
            Debug.Log("angle");
        }
        else if (state == FlyPreparationState.Charge)
        {
            Debug.Log("charge");
            ChargeCount();
        }
        else if (state == FlyPreparationState.Set)
        {
            Debug.Log("set");
            Debug.Log(FlyAngle);
        }
        else if (state == FlyPreparationState.Fire)
        {
            State = InGameState.ReleaseUP;

            Debug.Log("fire");
        }

        if (state == FlyPreparationState.Fire)
        {
            var item = Instantiate(_itemprefab, _spawnpoint.transform.position, Quaternion.identity);
            item.GetComponent<ItemScripta>().Throw(FlyAngle, FlyCharge);
            CameraTarget = item;
        }
    }

    private async void ChargeCount()
    {
        if (_isCharging)
            return;


        _isCharging = true;
        bool increasing = true;

        Debug.Log("1");


        while (FlyPreparationState == FlyPreparationState.Charge)
        {
            Debug.Log("2");
            if (increasing)
            {
                FlyCharge++;
                if (FlyCharge >= 100)
                    increasing = false;
            }
            else
            {
                FlyCharge--;
                if (FlyCharge <= 0)
                    increasing = true;
            }

            await Task.Delay(5); // 0.05秒毎に更新
            Debug.Log(FlyCharge);
        }

        _isCharging = false;
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