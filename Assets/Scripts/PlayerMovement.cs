using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float _speed;

    Rigidbody2D rb;

    #region Singleton
    // Singleton start //
    public static PlayerMovement instance;
    void Awake()
    {
        instance = this;
    }
    // Singleton end //
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }

    public void MoveToTarget(Vector2 input)
    {
        Vector2 direction = ((transform.up * input.y) + (transform.right * input.x)).normalized;

        rb.velocity = direction * _speed;
    }

    public void RotateToTarget(Vector2 target)
    {
        Vector2 direction = target - (Vector2)transform.position;
        transform.up = direction;
    }

}
