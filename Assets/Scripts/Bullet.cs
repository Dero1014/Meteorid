using System.Collections;
using System.Collections.Generic;
using TimeFunctions;
using UnityEngine;

public class Bullet : MoveObject
{
    [SerializeField]
    float _setTimer;

    TimerFunctions _t1 = new TimerFunctions();

    void Update()
    {
        Forward();
        if (_t1.Timer(_setTimer))
        {
            print("ready");
            ReturnToPool();
        }
    }

    void ReturnToPool()
    {
        BulletPool.instance.AddToPool(gameObject);
    }

}
