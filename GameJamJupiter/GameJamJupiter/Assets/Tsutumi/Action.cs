using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] string _charge;
    [SerializeField] string _release;
    float  _time;
    bool _timeRec = false;  
      
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeRec)
        {
            _time += Time.deltaTime;
        }
        if (Input.GetButton(_charge))
        {

        }
        if (Input.GetButtonUp(_charge))
        {

        }
    }
   
}
