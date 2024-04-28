using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _gunDamage;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Transform _bulletHolder;
    [SerializeField] private float _maxAmmo;
    [SerializeField] private float _maxMagazine;
    [SerializeField] private float _firingCooldown;
    private float _currentAmmo;
    private float _currentMagazine = 1;
    private bool _canShoot = true;
    public void Shoot()
    {
        // Guard Clause
        if (!_canShoot)
        {
            return;
        }
        if (_currentMagazine == 0)
        {
            Reload();
            return;
        }
        StartCoroutine(Cooldown());
        Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, quaternion.identity, _bulletHolder);
        bullet.Right = transform.right;
        bullet.Damage = _gunDamage;
    }
    public void Reload()
    {
    }

    private IEnumerator Cooldown()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_firingCooldown);
        _canShoot = true;
    }
}