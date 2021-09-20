using Asteroids.Model;
using UnityEngine;

public class ShipView : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Ship _model;

    public void Init(Ship model) => _model = model;

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
