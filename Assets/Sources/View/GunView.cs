using Asteroids.Model;
using UnityEngine;

public class GunView : MonoBehaviour
{
    [SerializeField] private GameObject _projectileTemplate;
    [SerializeField] private Transform _shootingPoint;

    private IGun _model;

    public void Init(BaseGun model)
    {
        _model = model;
    }

    private void OnEnable()
    {
        _model.Shot += OnShot;
    }

    private void OnDisable()
    {
        _model.Shot -= OnShot;
    }

    private void OnShot()
    {
        ThrowProjectile();
    }

    private void ThrowProjectile()
    {
        Instantiate(_projectileTemplate, _shootingPoint.position, Quaternion.identity);
    }
}
