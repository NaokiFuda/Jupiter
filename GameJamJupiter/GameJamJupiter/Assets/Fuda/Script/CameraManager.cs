using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
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

        if (InGameState.Fishing == _inGameState)
        {
            ZoomIn();
        }
        else if (InGameState.ReleaseUP == _inGameState)
        {
            ZoomOut();
        }
        else if (InGameState.ReleaseDawn == _inGameState)
        {
            ZoomIn();
        }
        else if (InGameState.ReleaseEnd == _inGameState)
        {
            ZoomOut();
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
        if (_camera.fieldOfView <= _minRange) return;
        _camera.fieldOfView -= _xoomSpeed;
    }

    private void ZoomOut()
    {
        if (_camera.fieldOfView >= _maxRange) return;
        _camera.fieldOfView += _xoomSpeed;
    }
}