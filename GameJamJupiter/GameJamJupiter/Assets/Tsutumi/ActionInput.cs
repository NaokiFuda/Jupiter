using System.Collections.Generic;
using UnityEngine;

public class ActionInput : MonoBehaviour
{
    private List<string> _actionKye;
    private List<string> _actionKye2;

    private void Start()
    {
        _actionKye = GameManager.Instance._actionKye;
        _actionKye2 = GameManager.Instance._actionKye2;
    }

    void Update()
    {
        if (IsKeyDawnActionKyeDown(_actionKye)) //stringで通るのか
        {
            InGameManager.Instance.OnInputAction1Dawn();
        }

        if (IsKeyDawnActionKyeDown(_actionKye2))
        {
            InGameManager.Instance.OnInputAction2Dawn();
        }

        if (IsKeyDawnActionKyeUp(_actionKye))
        {
            InGameManager.Instance.OnInputAction1Up();
        }

        if (IsKeyDawnActionKyeUp(_actionKye2))
        {
            InGameManager.Instance.OnInputAction2Up();
        }
    }

    bool IsKeyDawnActionKyeDown(List<string> actionKye) //これいけるんだスゲー
    {
        foreach (string key in actionKye)
        {
            if (Input.GetKeyDown(key))
            {
                return true;
            }
        }

        return false;
    }

    bool IsKeyDawnActionKyeUp(List<string> actionKye) 
    {
        foreach (string key in actionKye)
        {
            if (Input.GetKeyUp(key))
            {
                return true;
            }
        }

        return false;
    }
}