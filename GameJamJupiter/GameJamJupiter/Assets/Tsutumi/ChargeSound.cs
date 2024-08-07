using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSound : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource _audio;
    [SerializeField] float _maxPitch = 10;
    [SerializeField] float _fixedUpPitch = 0.01f;
    void Start()
    {
        _audio = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        _audio.pitch += _fixedUpPitch;
        if(_audio.pitch >= _maxPitch)
        {
            _audio.pitch = _maxPitch;
        }
    }
}
