// GENERATED AUTOMATICALLY FROM 'Assets/Sources/Input/ShipInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Asteroids.Input
{
    public class @ShipInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ShipInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ShipInput"",
    ""maps"": [
        {
            ""name"": ""Ship"",
            ""id"": ""057b7762-5199-4552-a4c1-0bc83990bfbc"",
            ""actions"": [
                {
                    ""name"": ""MoveForward"",
                    ""type"": ""Button"",
                    ""id"": ""a5734cbb-66d0-4b66-8a79-5fbc7f23696d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FirstSlotShoot"",
                    ""type"": ""Button"",
                    ""id"": ""db44999b-b1f5-43e2-8e24-479fee798b4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondSlotShoot"",
                    ""type"": ""Button"",
                    ""id"": ""424ade2a-7918-4c84-8745-ab275bd4a60c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""14f05330-31ac-4537-8288-d39dc249aeeb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8fcf2221-66b5-47df-8b9d-f17d8a252368"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Hold(duration=0.001,pressPoint=0.001)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa03d3d8-7663-4d47-8972-43fdb4f324ac"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstSlotShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1d9e4db-49df-4050-8c52-775be950a253"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondSlotShoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Direction"",
                    ""id"": ""ca7ac779-c41f-42ad-aeda-565f48879850"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""02f47a46-655b-45f2-9d92-f28adde1e988"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""64ecaf39-7d68-4106-80b7-0df12a9cda4c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Ship
            m_Ship = asset.FindActionMap("Ship", throwIfNotFound: true);
            m_Ship_MoveForward = m_Ship.FindAction("MoveForward", throwIfNotFound: true);
            m_Ship_FirstSlotShoot = m_Ship.FindAction("FirstSlotShoot", throwIfNotFound: true);
            m_Ship_SecondSlotShoot = m_Ship.FindAction("SecondSlotShoot", throwIfNotFound: true);
            m_Ship_Rotate = m_Ship.FindAction("Rotate", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Ship
        private readonly InputActionMap m_Ship;
        private IShipActions m_ShipActionsCallbackInterface;
        private readonly InputAction m_Ship_MoveForward;
        private readonly InputAction m_Ship_FirstSlotShoot;
        private readonly InputAction m_Ship_SecondSlotShoot;
        private readonly InputAction m_Ship_Rotate;
        public struct ShipActions
        {
            private @ShipInput m_Wrapper;
            public ShipActions(@ShipInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveForward => m_Wrapper.m_Ship_MoveForward;
            public InputAction @FirstSlotShoot => m_Wrapper.m_Ship_FirstSlotShoot;
            public InputAction @SecondSlotShoot => m_Wrapper.m_Ship_SecondSlotShoot;
            public InputAction @Rotate => m_Wrapper.m_Ship_Rotate;
            public InputActionMap Get() { return m_Wrapper.m_Ship; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
            public void SetCallbacks(IShipActions instance)
            {
                if (m_Wrapper.m_ShipActionsCallbackInterface != null)
                {
                    @MoveForward.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnMoveForward;
                    @MoveForward.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnMoveForward;
                    @MoveForward.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnMoveForward;
                    @FirstSlotShoot.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnFirstSlotShoot;
                    @FirstSlotShoot.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnFirstSlotShoot;
                    @FirstSlotShoot.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnFirstSlotShoot;
                    @SecondSlotShoot.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnSecondSlotShoot;
                    @SecondSlotShoot.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnSecondSlotShoot;
                    @SecondSlotShoot.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnSecondSlotShoot;
                    @Rotate.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotate;
                    @Rotate.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotate;
                    @Rotate.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotate;
                }
                m_Wrapper.m_ShipActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MoveForward.started += instance.OnMoveForward;
                    @MoveForward.performed += instance.OnMoveForward;
                    @MoveForward.canceled += instance.OnMoveForward;
                    @FirstSlotShoot.started += instance.OnFirstSlotShoot;
                    @FirstSlotShoot.performed += instance.OnFirstSlotShoot;
                    @FirstSlotShoot.canceled += instance.OnFirstSlotShoot;
                    @SecondSlotShoot.started += instance.OnSecondSlotShoot;
                    @SecondSlotShoot.performed += instance.OnSecondSlotShoot;
                    @SecondSlotShoot.canceled += instance.OnSecondSlotShoot;
                    @Rotate.started += instance.OnRotate;
                    @Rotate.performed += instance.OnRotate;
                    @Rotate.canceled += instance.OnRotate;
                }
            }
        }
        public ShipActions @Ship => new ShipActions(this);
        public interface IShipActions
        {
            void OnMoveForward(InputAction.CallbackContext context);
            void OnFirstSlotShoot(InputAction.CallbackContext context);
            void OnSecondSlotShoot(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
        }
    }
}
