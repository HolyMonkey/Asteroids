using UnityEngine.UI;
using CompositeRoot;
using UnityEngine;
using Asteroids.Model;

public class ShipDebugUIView : MonoBehaviour
{
    [SerializeField] private ShipCompositeRoot _ship;

    [SerializeField] private Text _positionLabel;
    [SerializeField] private Text _rotationLabel;
    [SerializeField] private Text _speedLabel;
    [SerializeField] private Text _laserBulletsLabel;
    [SerializeField] private Text _laserRollbackLabel;

    private void OnEnable()
    {
        _ship.LaserGun.Shot += OnLaserGunShot;
        _ship.LaserGun.ShotAdd += OnLaserGunShotAdd;

        UpdateLasersCount();
    }

    private void OnDisable()
    {
        _ship.LaserGun.Shot -= OnLaserGunShot;
        _ship.LaserGun.ShotAdd += OnLaserGunShotAdd;
    }


    private void Update()
    {
        _positionLabel.text = $"Position: {_ship.Model.Position}";
        _rotationLabel.text = $"Rotation: {Mathf.RoundToInt(_ship.Model.Rotation)}°";
        _speedLabel.text = $"Speed: {Mathf.RoundToInt(_ship.Speed * 10000)}";
        _laserRollbackLabel.text = $"To Rollback: {(_ship.LaserGunRollback.Cooldown - _ship.LaserGunRollback.AccumulatedTime):0.0}";
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
        _laserBulletsLabel.text = $"Lasers: {_ship.LaserGun.Bullets} / {_ship.LaserGun.MaxBullets}";
    }
}
