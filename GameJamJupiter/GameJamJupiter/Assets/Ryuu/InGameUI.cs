using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] Slider powerSlider;

    int currentPower;

    private void Update()
    {
        if (Math.Abs(powerSlider.value - InGameManager.Instance.FlyCharge / 100f) > 0.01f )
        {
            powerSlider.value =  InGameManager.Instance.FlyCharge / 100f;
        }
    }
}