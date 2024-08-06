using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Sponer : MonoBehaviour
{
    FlyPreparationState _flyPreparationState;
    [SerializeField] bool _AnglePositive = false;
    [SerializeField] int _AngleCount = 0;
    [SerializeField] float _coolTime = 1.0f; // クールタイムの間隔を秒単位で指定
    private bool _canRotate = true;

    private void Start()
    {
        InGameManager.Instance.FlyPreparationState = FlyPreparationState.Angle;
    }

    private void Update()
    {
        if (_flyPreparationState == FlyPreparationState.Angle && _canRotate)
        {
            Debug.Log("DebugLog");

            FlyAngleRotation();
            StartCoroutine(CoolTimeCoroutine());
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
    }

    private void FlyAngleRotation()
    {
        if (_AnglePositive && _AngleCount < 180)
        {
            _AngleCount += 1;
        }
        else if (!_AnglePositive && _AngleCount > 0)
        {
            _AngleCount -= 1;
        }
        else if (_AnglePositive && _AngleCount == 180)
        {
            _AnglePositive = false;
        }
        else if (!_AnglePositive && _AngleCount == 0)
        {
            _AnglePositive = true;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, _AngleCount));
    }

    private IEnumerator CoolTimeCoroutine()
    {
        _canRotate = false;
        yield return new WaitForSeconds(_coolTime);
        _canRotate = true;
    }
}