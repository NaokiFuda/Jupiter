using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] string _chargeKey;
    [SerializeField] string _releaseKey;
    [SerializeField] string _highKey;
    [SerializeField] string _midKey;
    [SerializeField] string _lowKey;
    [SerializeField] float[] _resultPaturn;
    Result _result;
    Angle _angle;
    float _time;
    float _chargeTime;
    float _power;
    bool _angleSet = true;
    bool _timeRec;
    bool _end;
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
        if (_angleSet == false &&Input.GetButton(_chargeKey))
        {
            _chargeTime += Time.deltaTime;
        }
        else if (_angleSet == false && Input.GetButtonUp(_chargeKey))
        {
            float _power = PowerCount(_chargeTime);
            _timeRec = true;
        }
        else if (_angleSet == false && _timeRec && Input.GetButtonDown(_releaseKey))
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
            (_result, _angle, _power);
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
        float pow = CharacterManager.power * power;
        return pow;
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
