using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodSelectScript : MonoBehaviour
{
    [SerializeField] private int RodID;
    public void SelectRod()
    {
        GameManager.Instance.SelectedRodID = RodID;
    }
}
