using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

public class Sponer : MonoBehaviour
{
    FlyPreparationState _flyPreparationState;
    [SerializeField] bool _AnglePositive = false;
    [SerializeField] float _rotationSpeed = 10.0f; // 回転速度を指定
    [SerializeField] float _coolTime = 0.1f;       // クールタイムの間隔を秒単位で指定
    private bool _canRotate = true;

    private void Start()
    {
        InGameManager.Instance.FlyPreparationState = FlyPreparationState.Angle;
    }

    private void FixedUpdate()
    {
        if (_flyPreparationState == FlyPreparationState.Angle && _canRotate)
        {
            FlyAngleRotation();
            StartCoolTime();
        }
    }

    private void OnEnable()
    {
        InGameManager.Instance.OnFlyPreparationStateChanged += UpdateFlyPreparationState;
    }

    private void OnDisable()
    {
        InGameManager.Instance.OnFlyPreparationStateChanged -= UpdateFlyPreparationState;
    }

    private void UpdateFlyPreparationState(FlyPreparationState flyPreparationState)
    {
        _flyPreparationState = flyPreparationState;
        if (flyPreparationState == FlyPreparationState.Charge)
        {
            InGameManager.Instance.FlyAngle = (int)transform.eulerAngles.z;
        }
    }

    private void FlyAngleRotation()
    {
        float rotationAmount = _rotationSpeed * Time.deltaTime; // フレームごとの回転量を計算
        if (_AnglePositive)
        {
            if (transform.eulerAngles.z + rotationAmount < 180)
            {
                transform.Rotate(new Vector3(0, 0, rotationAmount));
            }
            else
            {
                _AnglePositive = false;
            }
        }
        else
        {
            if (transform.eulerAngles.z - rotationAmount > 0)
            {
                transform.Rotate(new Vector3(0, 0, -rotationAmount));
            }
            else
            {
                _AnglePositive = true;
            }
        }

        
    }

    private async void StartCoolTime()
    {
        _canRotate = false;
        await Task.Delay(TimeSpan.FromSeconds(_coolTime));
        _canRotate = true;
    }
}