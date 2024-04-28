using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _health;
    [SerializeField] private float _speed = 4;
    public float Damage;

    private void Start()
    {
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            KillEnemy();
        }
    }
    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, GameManager.Instance.Player.transform.position, Time.deltaTime * _speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            stats.TakeDamage(Damage);
        }
    }
}
