using Asteroids.Input;
using Asteroids.Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CompositeRoot
{
    public class ShipCompositeRoot : CompositeRoot
    {
        [SerializeField] private TransformableView _transformableView;
        [SerializeField] private BulletsViewFactory _bulletsViewFactory;
        [SerializeField] private Camera _camera;

        private Ship _shipModel;
        private ShipInputRouter _shipInputRouter;
        private ShipMovement _shipMovement;
        private DefaultGun _baseGun;
        private LaserGun _laserGun;
        private BulletsSimulation _bulletsSimulation;
        private LaserGunRollback _laserGunRollback;

        public Ship Model => _shipModel;
        public BulletsSimulation Bullets => _bulletsSimulation;
        public float Speed => _shipInputRouter.Speed;
        public LaserGun LaserGun => _laserGun;
        public LaserGunRollback LaserGunRollback => _laserGunRollback;

        public override void Compose()
        {
            _baseGun = new DefaultGun();
            _laserGun = new LaserGun(10);

            _shipModel = new Ship(new Vector2(0.5f, 0.5f), 0);
            _shipMovement = new ShipMovement(_shipModel);
            _shipInputRouter = new ShipInputRouter(_shipMovement)
                .BindGunToFirstSlot(_baseGun)
                .BindGunToSecondSlot(_laserGun);

            _transformableView.Init(_shipModel, _camera);

            _bulletsSimulation = new BulletsSimulation();
            _laserGunRollback = new LaserGunRollback(_laserGun, Config.LaserCooldown);
        }

        public void DisableShip()
        {
            _shipInputRouter.OnDisable();
        }

        private void OnEnable()
        {
            _shipInputRouter.OnEnable();

            _baseGun.Shot += OnShot;
            _laserGun.Shot += OnShot;

            _bulletsSimulation.Start += _bulletsViewFactory.Create;
            _bulletsSimulation.End += _bulletsViewFactory.Destroy;
        }

        private void OnDisable()
        {
            _shipInputRouter.OnDisable();

            _baseGun.Shot -= OnShot;
            _laserGun.Shot -= OnShot;

            _bulletsSimulation.Start -= _bulletsViewFactory.Create;
            _bulletsSimulation.End -= _bulletsViewFactory.Destroy;
        }

        private void Update()
        {
            _shipInputRouter.Update();
            _bulletsSimulation.Update(Time.deltaTime);
            _laserGunRollback.Tick(Time.deltaTime);
        }

        private void OnShot(Bullet bullet)
        {
            _bulletsSimulation.Simulate(bullet, _shipModel.Position, _shipMovement.Forward);
        }
    }
}