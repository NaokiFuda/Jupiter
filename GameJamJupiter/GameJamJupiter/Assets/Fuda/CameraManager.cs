using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] InGameManager ingameManager;
    [SerializeField] Vector3 defPos;

    private void Start()
    {
        transform.position = defPos;
    }
    private void OnEnable()
    {
        InGameManager.Instance.OnStateChanged += CameraType;
    }

    private void OnDisable()
    {
        InGameManager.Instance.OnStateChanged -= CameraType;
    }

    public void CameraType(InGameState a)
    {
        if (InGameState.Fishing == a)
        {
            ZoomedIn();
        }
        else if (InGameState.Release == a)
        {
            ZoomOut();
        }
    }

    void ZoomIn()
    {
        transform.position 
    }
    void ZoomOut()
    {

    }
}
