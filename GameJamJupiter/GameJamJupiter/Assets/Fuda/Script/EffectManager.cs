using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EffectManager : MonoBehaviour
{
    FlyPreparationState _effectState;
    InGameState _inGameState;
    GameObject _targetObj;
    [SerializeField]GameObject[] _effectList;
    Animator anim;
    bool isLanded;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        InGameManager.Instance.OnFlyPreparationStateChanged += EffectState;
        InGameManager.Instance.OnStateChanged += CameraType;
        InGameManager.Instance.OnCameraTargetChanged += CameraTergetObj;
    }

    private void OnDisable()
    {
        InGameManager.Instance.OnFlyPreparationStateChanged -= EffectState;
        InGameManager.Instance.OnStateChanged -= CameraType;
        InGameManager.Instance.OnCameraTargetChanged -= CameraTergetObj;
    }
    private void CameraType(InGameState inGameState)
    {
        _inGameState = inGameState;
    }
    void EffectState(FlyPreparationState state)
    {
        _effectState = state;
    }
    public void CameraTergetObj(GameObject targetGameObject)
    {
        _targetObj = targetGameObject;
    }
    private void Update()
    {
        if(_effectState == FlyPreparationState.Set)
        {
            // 釣り糸垂らしたときのエフェクトはなしっぽい？追加されたらここに
        }
        else if (_effectState == FlyPreparationState.Fire)
        {
            Fishing();
        }

        if (_inGameState == InGameState.Start && isLanded)
        {
            isLanded = false;
        }
        else if (_inGameState == InGameState.ReleaseDawn)
        {
            Burned();
        }
        else if (_inGameState == InGameState.ReleaseEnd)
        {
            if (!isLanded)
            {
                isLanded = true;
                Landed();
            }
            
        }

    }
    void Fishing()
    {
        anim.ResetTrigger("isFinshing");
        anim.SetTrigger("isFinshing");
    }
    void Landed()
    {
        _effectList[2].transform.position = _targetObj.transform.position;

        anim.ResetTrigger("isFinshing");
        anim.SetTrigger("isFinshing");

        if (anim.GetBool("isFalling"))
        {
            anim.SetBool("isFalling", false);
        }
    }
    Vector3 lastPos;
    float angle;
    void Burned()
    {
        _effectList[1].transform.position = _targetObj.transform.position;
        if(lastPos != _targetObj.transform.position)
        {
            angle = Vector3.Angle(_targetObj.transform.position - lastPos, Vector3.down); 
        }
        //落下物の移動したベクトルが下方向のベクトルとなす角度回転させた姿勢を維持する
        _effectList[2].transform.rotation = Quaternion.Euler(0,0,angle);
        
        if (!anim.GetBool("isFalling"))
        {
            anim.SetBool("isFalling", true);
        }
        lastPos = _targetObj.transform.position;
    }
}
