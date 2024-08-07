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
    public Sprite characterIcon;
    [Tooltip("���O�ł�"),SerializeField] public string name;
    [Tooltip("�e�N�j�b�N"), SerializeField] public float technic;
    [Tooltip("�p���["), SerializeField] public float power;
    [Tooltip("�K�^�l"), SerializeField] public float Luc;
    //�ǉ��\
}
[System.Serializable]
public class Item
{
    [Tooltip("���O�ł�"), SerializeField]public string name;
    //��΂����̓��e����Œǉ��\��
}
[System.Serializable]
public class Rod
{
    [Tooltip("���O�ł�"), SerializeField] public string name;
    [Tooltip("���Ȃ�"), SerializeField] public float rodBend;
    [Tooltip("���[�����������x"), SerializeField] public float rodRollSpeed;
    [Tooltip("�Ƃ�U�鋭��"), SerializeField] public float rodPower;
    //�ǉ��\
}
