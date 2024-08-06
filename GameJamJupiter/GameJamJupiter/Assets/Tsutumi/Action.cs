using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField, TooltipAttribute("チャージするときに使用するキーを指定してください")] string _chargeKey;
    [SerializeField, TooltipAttribute("リリースする際にしようするキーを指定してください")] string [] _releaseKey;
    [SerializeField, TooltipAttribute("上の角度に設定するキーを指定してください")] string _highKey;
    [SerializeField, TooltipAttribute("真ん中の角度に設定するキーを指定してください")] string _midKey;
    [SerializeField, TooltipAttribute("下の角度に設定するキーを指定してください")] string _lowKey;
    [SerializeField, TooltipAttribute("はじき入力のインターバルに対して評価する三段階の数値を指定してください")] float[] _resultPaturn;
    [SerializeField, TooltipAttribute("パワーチャージの最大値を設定してください")] float _maxPower = 3;
    [SerializeField] Animator _animator;
    Result _result;
    Angle _angle;
    float _time;
    float _chargeTime;
    float _power;
   public bool _angleSet = true;
   public bool _charge;
   public bool _timeRec;
   public bool _end;
    void Update()
    {
        if (_angleSet)
        {
            _angle = Set();
        }
        if (_timeRec)
        {
            _time += Time.deltaTime;
        }
        if (!_angleSet&&Input.GetButton(_chargeKey))
        {
            _chargeTime += Time.deltaTime;
            _charge = true;
        }
        else if (!_angleSet&& Input.GetButtonUp(_chargeKey))
        {
            _charge = false;
            float _power = PowerCount(_chargeTime);
            _timeRec = true;
        }
        else if (!_angleSet&& _timeRec && Input.GetButtonDown(_releaseKey[0])|| Input.GetButtonDown(_releaseKey[1]) || Input.GetButtonDown(_releaseKey[2]) 
            || Input.GetButtonDown(_releaseKey[3]) || Input.GetButtonDown(_releaseKey[4]) || Input.GetButtonDown(_releaseKey[4]))
        {
            _timeRec = false;
            _end = true;
        }

        if (_end)
        {
            for(int i = 0; i < _resultPaturn.Length; i++)
            {
             if(_time > _resultPaturn[i])
                {
                    continue;
                }
                _result = (Result)i;
                break;
            }
        }
    }
    Angle Set()
    {
        if (Input.GetButtonDown(_highKey))
        {
            _angleSet = false;
            return Angle.high;
        }
        else if (Input.GetButtonDown(_midKey))
        {
            _angleSet = false;
            return Angle.mid;  
        }
        else if (Input.GetButtonDown(_lowKey))
        {
            _angleSet = false;
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
