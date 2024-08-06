using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScript : MonoBehaviour
{
    [SerializeField] private int characterID;
    public void SelectCharacter()
    {
        GameManager.Instance.SelectedCharacterID = characterID;
    }
}
