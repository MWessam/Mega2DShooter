using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Seperation of concerns.
/// Single responsibility.
/// (SOLID)
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private Vector2 _input;

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    // Input
    // Physics Movement (Vertical, Horizontal)
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _input * _speed;
    }
}