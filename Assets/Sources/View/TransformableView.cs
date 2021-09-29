using Asteroids.Model;
using UnityEngine;

public class TransformableView : MonoBehaviour
{
    private Camera _camera;
    private Transformable _model;

    public void Init(Transformable model, Camera camera)
    {
        _model = model;
        _camera = camera;
    }

    public void LateUpdate()
    {
        transform.position = _camera.ViewportToWorldPoint(GetViewportPosition());
        transform.rotation = Quaternion.Euler(0, 0, _model.Rotation);
    }

    private Vector3 GetViewportPosition()
    {
        return new Vector3(_model.Position.x, _model.Position.y, 1);
    }
}
