using UnityEngine;
/// <summary>
/// ゲームシーンに居るクラスです インゲームを管理します
/// IngameMAnager.Instance で呼び出して下さい
/// </summary>
[DefaultExecutionOrder(-100)]
public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance = null;
    
    void Awake()
    {
        Instance = this;
    }
    
}