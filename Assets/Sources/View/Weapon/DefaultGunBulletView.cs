using UnityEngine;
using Asteroids.Model;

public class DefaultGunBulletView : BulletView<DefaultBullet>
{
    public override void OnInit(DefaultBullet bullet) => Debug.Log("Default");
}
