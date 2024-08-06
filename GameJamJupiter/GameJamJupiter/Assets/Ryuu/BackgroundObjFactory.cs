using System;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjFactory : MonoBehaviour
{
    
}

public class BackgroundList : ScriptableObject
{
    
}

[Serializable]
public class BackgroundObj : ScriptableObject
{
    [SerializeField] private GameObject obj ;
    
}