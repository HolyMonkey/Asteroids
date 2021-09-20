using Asteroids.Input;
using Asteroids.Model;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController
{
    private ShipInput _input;
    private InertMovement _inertMovement;
    private ShipMovement _shipMovement;

    private BaseGun _firstGunSlot;
    private BaseGun _secondGunSlot;

    public ShipController(ShipMovement shipMovement)
    {
        _input = new ShipInput();
        _inertMovement = new InertMovement();
        _shipMovement = shipMovement;
    }

    public void OnEnable()
    {
        _input.Enable();
        _input.Ship.FirstSlotShoot.performed += OnFirstSlootShoot;
        _input.Ship.SecondSlotShoot.performed += OnSecondSlootShoot;
    }

    public void OnDisable()
    {
        _input.Disable();
        _input.Ship.FirstSlotShoot.performed -= OnFirstSlootShoot;
        _input.Ship.SecondSlotShoot.performed -= OnSecondSlootShoot;
    }

    public void Update()
    {
        if (MoveForwardPerformed())
            _inertMovement.Accelerate(_shipMovement.Forward, Time.deltaTime);
        else
            _inertMovement.Slowdown(Time.deltaTime);

        _shipMovement.Move(_inertMovement.Acceleration);
        TryRotate();
    }

    public ShipController BindGunToFirstSlot(BaseGun gun)
    {
        _firstGunSlot = gun;
        return this;
    }

    public ShipController BindGunToSecondSlot(BaseGun gun)
    {
        _secondGunSlot = gun;
        return this;
    }

    private bool MoveForwardPerformed()
    {
        return _input.Ship.MoveForward.phase == InputActionPhase.Performed;
    }

    private void OnFirstSlootShoot(InputAction.CallbackContext obj)
    {
        if (_firstGunSlot.CanShoot())
            _firstGunSlot.Shoot();
    }

    private void OnSecondSlootShoot(InputAction.CallbackContext obj)
    {
        if (_secondGunSlot.CanShoot())
            _secondGunSlot.Shoot();
    }

    private void TryRotate()
    {
        float direction = _input.Ship.Rotate.ReadValue<float>();

        if(direction != 0)
            _shipMovement.Rotate(_input.Ship.Rotate.ReadValue<float>(), Time.deltaTime);
    }
}
