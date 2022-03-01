using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    Transform muzzle;

    #region Singleton
    // Singleton start //
    public static PlayerAction instance;
    void Awake()
    {
        instance = this;
    }
    // Singleton end //
    #endregion

    public void Shoot(bool shoot)
    {
        if (shoot)
        {
            GameObject bullet = BulletPool.instance.GetBullet();
            if (bullet != null)
            {
                bullet.transform.parent = null;
                bullet.transform.position = muzzle.position;
                bullet.transform.up = muzzle.up;
            }
        }
    }

}
