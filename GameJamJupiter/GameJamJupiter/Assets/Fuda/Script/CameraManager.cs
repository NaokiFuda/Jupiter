using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Vector3 defPos = new Vector3(-4.3f, 1.28f, -21f);
    Vector3 targetObjPos;
    GameObject targetObj;
    bool isFishing;
    [SerializeField] float maxRange = -100;
    [SerializeField] float minRange = -20;

    private void Start()
    {
        transform.position = defPos;
    }
    private void ResetPos()
    {
        transform.position = defPos;
    }
    private void Update()
    {
        if (isFishing)
        {
            FollowObj();
        }
        
        if (InGameState.Start == cameraState)
        {
            isFishing = false;
            ResetPos();
        }
        else if (InGameState.Fishing == cameraState && transform.position.z <= minRange)
        {
            ZoomIn();
            isFishing = true;
        }
        else if(InGameState.ReleaseUP == cameraState && transform.position.z >= maxRange)
        {
            ZoomOut();
        }
        else if (InGameState.ReleaseDawn == cameraState && transform.position.z <= minRange)
        {
            ZoomIn();
        }
        else if (InGameState.ReleaseEnd == cameraState && transform.position.z <= minRange)
        {
            ZoomIn();
        }
    }
    private void OnEnable()
    {
        InGameManager.Instance.OnStateChanged += CameraType;
        InGameManager.Instance.OnCameraTargetChanged += GameObjPos;
    }
    //デリゲートを使ってるらしい。要勉強。
    private void OnDisable()
    {
        InGameManager.Instance.OnStateChanged -= CameraType;
        InGameManager.Instance.OnCameraTargetChanged -= GameObjPos;
    }
    
    public void GameObjPos(GameObject a)  
    {
        targetObjPos = a.transform.position;
        targetObj = a;
    }
    InGameState cameraState;
    public void CameraType(InGameState a)
    {
        cameraState = a;
    }

    private void ZoomIn()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.01f);
    }
    private void ZoomOut()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.01f);
    }
    private void FollowObj()
    {
        transform.position = new Vector3(targetObjPos.x, targetObjPos.y, transform.position.z);
    }
}
