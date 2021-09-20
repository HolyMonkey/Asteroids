using UnityEngine;
using Asteroids.Model;

public class LaserGunBulletView : BulletView<LaserGunBullet>
{
    public override void OnInit(LaserGunBullet bullet) => Debug.Log("Laser Gun");
}
