using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterParameter")]

public class CharacterManager : ScriptableObject
{
    public List<Character> character;
    public List<Item> item;
    public List<Rod> rod;
    
}
[System.Serializable]
public class Character
{
    [Tooltip("名前です"),SerializeField] public string name;
    [Tooltip("テクニック"), SerializeField] public float technic;
    [Tooltip("パワー"), SerializeField] public float power;
    [Tooltip("幸運値"), SerializeField] public float Luc;
    //追加可能
}
[System.Serializable]
public class Item
{
    [Tooltip("名前です"), SerializeField]public string name;
    //飛ばす物の内容次第で追加予定
}
[System.Serializable]
public class Rod
{
    [Tooltip("名前です"), SerializeField] public string name;
    [Tooltip("しなり"), SerializeField] public float rodBend;
    [Tooltip("リールを巻く速度"), SerializeField] public float rodRollSpeed;
    [Tooltip("竿を振る強さ"), SerializeField] public float rodPower;
    //追加可能
}
