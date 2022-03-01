    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPool : Pool
{
    #region Singleton
    // Singleton start //
    public static MeteorPool instance;
    void Awake()
    {
        instance = this;
    }
    // Singleton end //
    #endregion
}
