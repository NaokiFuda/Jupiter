using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugItems : MonoBehaviour
{
    private void Start()
    {
        DebugItemsID();
        DebugPlayerName();
    }

    void DebugItemsID()
    {
        Debug.Log($"キャラ:{GameManager.Instance.SelectedCharacterID} Rod:{GameManager.Instance.SelectedRodID}");
    }

    void DebugPlayerName()
    {
        Debug.Log($"プレイヤー名「{GameManager.Instance.Playername}」");
    }
}
