using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField, TooltipAttribute("�`���[�W����Ƃ��Ɏg�p����L�[���w�肵�Ă�������")] string _chargeKey;
    [SerializeField, TooltipAttribute("�����[�X����ۂɂ��悤����L�[���w�肵�Ă�������")] string [] _releaseKey;
    [SerializeField, TooltipAttribute("��̊p�x�ɐݒ肷��L�[���w�肵�Ă�������")] string _highKey;
    [SerializeField, TooltipAttribute("�^�񒆂̊p�x�ɐݒ肷��L�[���w�肵�Ă�������")] string _midKey;
    [SerializeField, TooltipAttribute("���̊p�x�ɐݒ肷��L�[���w�肵�Ă�������")] string _lowKey;
    [SerializeField, TooltipAttribute("�͂������͂̃C���^�[�o���ɑ΂��ĕ]������O�i�K�̐��l���w�肵�Ă�������")] float[] _resultPaturn;
    [SerializeField, TooltipAttribute("�p���[�`���[�W�̍ő�l��ݒ肵�Ă�������")] float _maxPower = 3;
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
