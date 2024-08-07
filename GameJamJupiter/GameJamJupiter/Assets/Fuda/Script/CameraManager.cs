using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject _targetObj;
    private InGameState _inGameState;
    [SerializeField] private float _maxRange = -100;
    [SerializeField] private float _minRange = -20;
    [SerializeField] private float _minHight = 1.29f;
    [SerializeField] private float _xoomSpeed = 0.1f;
    [Tooltip("カメラの滑らかど"), SerializeField] private float _followIgnoreRange = 5;


    private void Update()
    {
        FolllowObj();

        if (InGameState.Fishing == _inGameState && transform.position.z <= _minRange)
        {
            ZoomIn();
        }
        else if (InGameState.ReleaseUP == _inGameState && transform.position.z >= _maxRange)
        {
            ZoomOut();
        }
        else if (InGameState.ReleaseDawn == _inGameState && transform.position.z <= _minRange)
        {
            ZoomIn();
        }
        else if (InGameState.ReleaseEnd == _inGameState && transform.position.z <= _minRange)
        {
            ZoomIn();
        }
    }

    //デリゲートを使ってるらしい。要勉強。
    private void OnEnable()
    {
        InGameManager.Instance.OnStateChanged += CameraType;
        InGameManager.Instance.OnCameraTargetChanged += CameraTergetObj;
    }

    private void OnDisable()
    {
        InGameManager.Instance.OnStateChanged -= CameraType;
        InGameManager.Instance.OnCameraTargetChanged -= CameraTergetObj;
    }

    public void CameraTergetObj(GameObject targetGameObject)
    {
        _targetObj = targetGameObject;
    }

    private void CameraType(InGameState inGameState)
    {
        _inGameState = inGameState;
    }

    private void FolllowObj()
    {
        // 差が5以内ならリターン
        if (Vector2.Distance(_targetObj.transform.position, transform.position) <= _followIgnoreRange) return;
        // それ以外の場合はターゲットオブジェクトを追跡
        transform.position = new Vector3(_targetObj.transform.position.x, _targetObj.transform.position.y + _minHight,
            transform.position.z);
    }

    private void ZoomIn()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + _xoomSpeed);
    }

    private void ZoomOut()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - _xoomSpeed);
    }
}