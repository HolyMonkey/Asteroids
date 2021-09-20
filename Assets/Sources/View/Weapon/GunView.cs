using Asteroids.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunView : MonoBehaviour
{
    [SerializeField] private BulletView _viewTemplate;
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

    private void OnShot(Bullet bullet)
    {
        if (IsViewFor(bullet) == false)
            throw new InvalidOperationException();

        ThrowBullet(bullet);
    }

    private bool IsViewFor(Bullet bullet)
    {
        return _viewTemplate.GetType().BaseType.GetGenericArguments().Any(type => type == bullet.GetType());
    }

    private void ThrowBullet(Bullet bullet)
    {
        var view = Instantiate(_viewTemplate, _shootingPoint.position, Quaternion.identity);
        view.Init(bullet);
    }
}
