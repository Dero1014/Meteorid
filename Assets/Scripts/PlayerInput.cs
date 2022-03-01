using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    bool _shoot = false;

    Vector2 _mousePosition;
    Vector2 _inputDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        _inputDirection = new Vector2(x, y);

        if (Input.GetMouseButtonDown(0) == true)
            _shoot = true;

        PlayerAction.instance.Shoot(_shoot);
        _shoot = false;
    }

    private void FixedUpdate()
    {
        PlayerMovement.instance.RotateToTarget(_mousePosition);
        PlayerMovement.instance.MoveToTarget(_inputDirection);
    }
}
