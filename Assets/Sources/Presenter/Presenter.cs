using Asteroids.Model;
using UnityEngine;

public class Presenter : MonoBehaviour
{
    private Camera _camera;
    private Transformable _model;

    private IUpdatable _updatable = null;

    public Transformable Model => _model;

    public void Init(Transformable model, Camera camera)
    {
        _camera = camera;
        _model = model;

        if (_model is IUpdatable)
            _updatable = (IUpdatable)_model;

        enabled = true;

        OnMoved();
        OnRotated();
    }

    private void OnEnable()
    {
        _model.Moved += OnMoved;
        _model.Rotated += OnRotated;
        _model.Destroying += OnDestroying;
    }

    private void OnDisable()
    {
        _model.Moved -= OnMoved;
        _model.Rotated -= OnRotated;
        _model.Destroying -= OnDestroying;
    }

    private void Update() => _updatable?.Update(Time.deltaTime);

    private Vector3 GetViewportPosition(Transformable transformable)
    {
        return new Vector3(transformable.Position.x, transformable.Position.y, 1);
    }

    private void OnMoved()
    {
        transform.position = _camera.ViewportToWorldPoint(GetViewportPosition(_model));
    }

    private void OnRotated()
    {
        transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);
    }

    private void OnDestroying()
    {
        Destroy(gameObject);
    }

    protected void DestroyCompose()
    {
        _model.Destroy();
    }
}
