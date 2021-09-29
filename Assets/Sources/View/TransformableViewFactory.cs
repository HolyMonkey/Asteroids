using Asteroids.Model;
using CompositeRoot;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransformableViewFactory<T> : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PhysicsRoutingCompositeRoot _router;

    private Dictionary<Simulation<T>.PlacedEntity, TransformableView> _views = new Dictionary<Simulation<T>.PlacedEntity, TransformableView>();

    public void Create(Simulation<T>.PlacedEntity placedEntity)
    {
        TransformableView view = Instantiate(GetTemplate(placedEntity.Entity), placedEntity.Transform.Position, Quaternion.identity);

        if(view.gameObject.TryGetComponent(out PhysicsEventsBroadcaster broadcaster))
        {
            broadcaster.Init(_router.Model, placedEntity.Entity);
        }

        view.Init(placedEntity.Transform, _camera);

        _views.Add(placedEntity, view);
    }

    public void Destroy(Simulation<T>.PlacedEntity placedEntity)
    {
        TransformableView view = _views[placedEntity];

        _views.Remove(placedEntity);

        Destroy(view.gameObject);
    }

    protected abstract TransformableView GetTemplate(T entity);
}
