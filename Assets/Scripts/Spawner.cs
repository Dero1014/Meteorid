using System.Collections;
using System.Collections.Generic;
using TimeFunctions;
using UnityEngine;

[System.Serializable]
public struct Percentage
{
    public float Vertical;
    public float Horizontal;
}


public class Spawner : MonoBehaviour
{
    [SerializeField]
    float _spawnTimer;

    [SerializeField]
    Percentage _percentage;

    TimerFunctions _t1 = new TimerFunctions();

    void Start()
    {
        
    }

    void Update()
    {
    }
}
