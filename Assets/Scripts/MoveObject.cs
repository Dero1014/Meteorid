using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField]
    float _fSpeed;

    public void Forward()
    {
        transform.position += (transform.up * _fSpeed);
    }
}
