using UnityEngine.UI;
using UnityEngine;
using Asteroids.Model;

public class ShipDebugUIPresenter : MonoBehaviour
{
    [SerializeField] private Root _init;

    [SerializeField] private Text _positionLabel;
    [SerializeField] private Text _rotationLabel;
    [SerializeField] private Text _speedLabel;
    [SerializeField] private Text _laserBulletsLabel;
    [SerializeField] private Text _laserRollbackLabel;

    private void OnEnable()
    {
        _init.LaserGun.Shot += OnLaserGunShot;
        _init.LaserGun.ShotAdd += OnLaserGunShotAdd;

        UpdateLasersCount();
    }

    private void OnDisable()
    {
        _init.LaserGun.Shot -= OnLaserGunShot;
        _init.LaserGun.ShotAdd += OnLaserGunShotAdd;
    }


    private void Update()
    {
        _positionLabel.text = $"Position: {_init.Ship.Position}";
        _rotationLabel.text = $"Rotation: {Mathf.RoundToInt(_init.Ship.Rotation)}°";
        _speedLabel.text = $"Speed: {Mathf.RoundToInt(_init.Ship.Acceleration.magnitude * 10000)}";
        _laserRollbackLabel.text = $"To Rollback: {(_init.LaserGunRollback.Cooldown - _init.LaserGunRollback.AccumulatedTime):0.0}";
    }

    private void OnLaserGunShot(Bullet bullet)
    {
        UpdateLasersCount();
    }

    private void OnLaserGunShotAdd()
    {
        UpdateLasersCount();
    }

    private void UpdateLasersCount()
    {
        _laserBulletsLabel.text = $"Lasers: {_init.LaserGun.Bullets} / {_init.LaserGun.MaxBullets}";
    }
}
