using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyAction : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed= 10f;

    private Rigidbody2D rb2d;
    
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb2d.velocity += Vector2.up * _velocity;
            
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0 , rb2d.velocity.y * _rotationSpeed);
    }
}
