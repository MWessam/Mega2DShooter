using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Transform _cursor;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void Update()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x);
        angle = (180 / Mathf.PI) * angle;
        transform.eulerAngles = new Vector3(0, 0, angle);
        _cursor.position = Vector2.Lerp(_cursor.position, mousePosition, Time.deltaTime * 10.0f);
    }
}
