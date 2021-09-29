using Asteroids.Input;
using Asteroids.Model;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipInputRouter
{
    private ShipInput _input;
    private InertMovement _inertMovement;
    private ShipMovement _shipMovement;

    private DefaultGun _firstGunSlot;
    private DefaultGun _secondGunSlot;

    public float Speed => _inertMovement.Acceleration.magnitude;

    public ShipInputRouter(ShipMovement shipMovement)
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

    public ShipInputRouter BindGunToFirstSlot(DefaultGun gun)
    {
        _firstGunSlot = gun;
        return this;
    }

    public ShipInputRouter BindGunToSecondSlot(DefaultGun gun)
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
        TryShoot(_firstGunSlot);
    }

    private void OnSecondSlootShoot(InputAction.CallbackContext obj)
    {
        TryShoot(_secondGunSlot);
    }

    private void TryShoot(DefaultGun gun)
    {
        if (gun.CanShoot())
            gun.Shoot();
    }

    private void TryRotate()
    {
        float direction = _input.Ship.Rotate.ReadValue<float>();

        if(direction != 0)
            _shipMovement.Rotate(direction, Time.deltaTime);
    }
}
