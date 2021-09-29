using UnityEngine;
using Asteroids.Model;

public class PhysicsEventsBroadcaster : MonoBehaviour
{
    private PhysicsRouter _router;
    private object _model;

    public void Init(PhysicsRouter router, object model)
    {
        _router = router;
        _model = model;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out PhysicsEventsBroadcaster broadcaster))
            _router.TryAddCollision(_model, broadcaster._model);
    }
}
