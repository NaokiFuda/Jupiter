using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField, Tooltip("チャージするときに使用するキーを指定してください")] string _chargeKey;
    [SerializeField, Tooltip("リリースする際にしようするキーを指定してください")] string [] _releaseKey;
    [SerializeField, Tooltip("上の角度に設定するキーを指定してください")] string _highKey;
    [SerializeField, Tooltip("真ん中の角度に設定するキーを指定してください")] string _midKey;
    [SerializeField, Tooltip("下の角度に設定するキーを指定してください")] string _lowKey;
    [SerializeField, Tooltip("はじき入力のインターバルに対して評価する三段階の数値を指定してください")] float[] _resultPaturn;
    [SerializeField, Tooltip("パワーチャージの最大値を設定してください")] float _maxPower = 3;
    [SerializeField] Animator _animator;
    Result _result;
    Angle _angle;
    float _time;
    float _chargeTime;
    float _power;
    bool _angleSet = true;
    bool _charge;
    bool _timeRec;
    bool _end;
    void Update()
    {
        if (!_end)
        {
            if (_angleSet)
            {
                _angle = Set();
            }
            if (_timeRec)
            {
                _time += Time.deltaTime;
            }
            if (!_angleSet && Input.GetKey(_chargeKey))
            {
                Debug.Log("ChargeNow");
                _chargeTime += Time.deltaTime;
                _charge = true;
            }
            else if (!_angleSet && Input.GetKeyUp(_chargeKey))
            {
                Debug.Log("ChargeOut");
                _charge = false;
                _timeRec = true;
            }
            else if (!_angleSet && _timeRec && Input.GetKeyDown(_releaseKey[0]) || Input.GetKeyDown(_releaseKey[1]) || Input.GetKeyDown(_releaseKey[2])
                || Input.GetKeyDown(_releaseKey[3]) || Input.GetKeyDown(_releaseKey[4]))
            {
                Debug.Log("Shoots");
                _timeRec = false;
                End();
            }
        }
       
    }
    void End()
    {
        float _power = PowerCount(_chargeTime);

        for (int i = 0; i < _resultPaturn.Length; i++)
            {
                if (_time > _resultPaturn[i])
                {
                    continue;
                }
                _result = (Result)i;
                break;
            }
            Debug.Log(_angle);
            Debug.Log(_time);
            Debug.Log(_result);
            Debug.Log(_power);
       
           _end = true;

           // InGameManager.Instance.(_angle, _result, _power);  
    }
    Angle Set()
    {
        if (Input.GetKeyDown(_highKey))
        {
            _angleSet = false;
            Debug.Log("AngleSetUP");
            return Angle.high;
        }
        else if (Input.GetKeyDown(_midKey))
        {
            _angleSet = false;
            Debug.Log("AngleSetMID");
            return Angle.mid;  
        }
        else if (Input.GetKeyDown(_lowKey))
        {
            _angleSet = false;
            Debug.Log("AngleSetLOW");
            return Angle.low;
        }
        return Angle.low;
    }
    float PowerCount(float power)
    {
        if(power > _maxPower)
        {
            power = _maxPower;
        }
        float pow = power;
        
        return pow;
    }
    private void LateUpdate()
    {
        if (_animator)
        {
            _animator.SetBool("Angle", _angleSet);
            _animator.SetBool("Cherge", _charge);
            _animator.SetBool("End", _end);
        }
    }
}

public enum Angle
{
    high,
    mid,
    low
}
public enum Result
{
    ultimate,
    great,
    faild
}
