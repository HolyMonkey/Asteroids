using Asteroids.Input;
using Asteroids.Model;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CompositeRoot
{
    public class ShipCompositeRoot : MonoBehaviour
    {
        [SerializeField] private List<ShipView> _shipView;
        [SerializeField] private GunView _baseGunView;
        [SerializeField] private GunView _laserGunView;

        private Ship _shipModel;
        private ShipController _shipController;
        private ShipMovement _shipMovement;
        private BaseGun _baseGun;
        private LaserGun _laserGun;

        private void Awake()
        {
            _baseGun = new BaseGun();
            _laserGun = new LaserGun(10);

            _shipModel = new Ship(new Vector2(0.5f, 0.5f), 0);
            _shipMovement = new ShipMovement(_shipModel);
            _shipController = new ShipController(_shipMovement)
                .BindGunToFirstSlot(_baseGun)
                .BindGunToSecondSlot(_laserGun);

            _shipView.ForEach(view => view.Init(_shipModel));
            _baseGunView.Init(_baseGun);
            _laserGunView.Init(_laserGun);
        }

        private void OnEnable()
        {
            _shipController.OnEnable();
        }

        private void OnDisable()
        {
            _shipController.OnDisable();
        }

        private void Update()
        {
            _shipController.Update();
        }
    }
}