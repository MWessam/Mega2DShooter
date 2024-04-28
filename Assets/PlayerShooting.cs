using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Gun _currentGun;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _currentGun.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _currentGun.Reload();
        }
    }
}