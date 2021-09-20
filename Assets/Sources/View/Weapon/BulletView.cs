using Asteroids.Model;
using UnityEngine;

public abstract class BulletView : MonoBehaviour
{
    public void Init(Bullet bullet)
    {
        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, bullet.Direction));
        ((dynamic)this).OnInit((dynamic)bullet);
    }
}

public abstract class BulletView<M> : BulletView where M : Bullet
{
    public abstract void OnInit(M bullet);
}
