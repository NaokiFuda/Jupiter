using UnityEngine;
/// <summary>
/// ゲームシーンに居るクラスです インゲームを管理します
/// IngameMAnager.Instance で呼び出して下さい
/// </summary>
[DefaultExecutionOrder(-100)]
public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance = null;
    
    private int characterID = 0;
    private int itemID = 0;
    private int rodID = 0;
    
    
    //public void ATK(enum enum float)
    
    void Awake()
    {
        Instance = this;
    }
    
}
public enum InGameState
{
    
}