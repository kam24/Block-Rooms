//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Sources/Input/PlayerBallInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerBallInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerBallInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerBallInput"",
    ""maps"": [
        {
            ""name"": ""PlayerBall"",
            ""id"": ""261ca5e0-efff-4d51-adfc-297b2609296d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""0bc10f4d-e814-4c75-a30c-cdfcd313b77b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""24e1a24c-4b79-4e48-957d-a2275c5736ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Directed Interaction"",
                    ""type"": ""Value"",
                    ""id"": ""8e1b1b98-0925-4ef5-8261-a0895cf79c5c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d8ba7561-76da-4192-8f8f-4a413f1fa85d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""11584683-5e1e-43fa-873a-c9d9ca484690"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8bd23083-4381-4bdd-88c3-3b6ae048284e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3d0c4907-25f2-4317-8897-ac638548bb7e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a43ba08c-38e2-48a8-a0c7-e9433fb90a79"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""34bf9778-46ac-4011-93e6-6ff15e8488d9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2,ScaleVector2,StickDeadzone(min=0.5)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""604d2b41-d879-4f6d-adba-c843250ad0e1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c304d3d9-2dbc-465a-9596-3a4378c0a635"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""427ded8e-54c2-4fce-9b02-d98ef23491b4"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5c65b20d-955f-4e90-8334-646e53fdada7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Directed Interaction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""73342b6a-fdc2-4bf1-be87-4801a0d11fdd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Directed Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""751699e6-c408-42e2-a508-3753ead6abdf"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Directed Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ac28d182-edfe-4619-8a06-dfdb3ee6842a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Directed Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e81446e2-e028-4da9-b96f-87a7e5fcd7f3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Directed Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""641cf2e5-8331-4440-9e91-79aa193025c6"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2,ScaleVector2,StickDeadzone(min=0.5)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Directed Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerBall
        m_PlayerBall = asset.FindActionMap("PlayerBall", throwIfNotFound: true);
        m_PlayerBall_Movement = m_PlayerBall.FindAction("Movement", throwIfNotFound: true);
        m_PlayerBall_Interaction = m_PlayerBall.FindAction("Interaction", throwIfNotFound: true);
        m_PlayerBall_DirectedInteraction = m_PlayerBall.FindAction("Directed Interaction", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerBall
    private readonly InputActionMap m_PlayerBall;
    private IPlayerBallActions m_PlayerBallActionsCallbackInterface;
    private readonly InputAction m_PlayerBall_Movement;
    private readonly InputAction m_PlayerBall_Interaction;
    private readonly InputAction m_PlayerBall_DirectedInteraction;
    public struct PlayerBallActions
    {
        private @PlayerBallInput m_Wrapper;
        public PlayerBallActions(@PlayerBallInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerBall_Movement;
        public InputAction @Interaction => m_Wrapper.m_PlayerBall_Interaction;
        public InputAction @DirectedInteraction => m_Wrapper.m_PlayerBall_DirectedInteraction;
        public InputActionMap Get() { return m_Wrapper.m_PlayerBall; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerBallActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerBallActions instance)
        {
            if (m_Wrapper.m_PlayerBallActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerBallActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerBallActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerBallActionsCallbackInterface.OnMovement;
                @Interaction.started -= m_Wrapper.m_PlayerBallActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_PlayerBallActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_PlayerBallActionsCallbackInterface.OnInteraction;
                @DirectedInteraction.started -= m_Wrapper.m_PlayerBallActionsCallbackInterface.OnDirectedInteraction;
                @DirectedInteraction.performed -= m_Wrapper.m_PlayerBallActionsCallbackInterface.OnDirectedInteraction;
                @DirectedInteraction.canceled -= m_Wrapper.m_PlayerBallActionsCallbackInterface.OnDirectedInteraction;
            }
            m_Wrapper.m_PlayerBallActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @DirectedInteraction.started += instance.OnDirectedInteraction;
                @DirectedInteraction.performed += instance.OnDirectedInteraction;
                @DirectedInteraction.canceled += instance.OnDirectedInteraction;
            }
        }
    }
    public PlayerBallActions @PlayerBall => new PlayerBallActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerBallActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnDirectedInteraction(InputAction.CallbackContext context);
    }
}
