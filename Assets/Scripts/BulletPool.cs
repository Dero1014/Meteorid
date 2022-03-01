using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : Pool
{

    #region Singleton
    // Singleton start //
    public static BulletPool instance;
    void Awake()
    {
        instance = this;
    }
    // Singleton end //
    #endregion

}
