// GENERATED AUTOMATICALLY FROM 'Assets/_Inputs/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""ThirdPerson"",
            ""id"": ""51b5f6c6-bd89-4ccd-ae90-b628481a5e47"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b20486ae-8d91-44a0-91cf-65482d0b48cc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""bbd49cb4-6acf-4ff5-b797-dc23f29fca94"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PickUp"",
                    ""type"": ""Button"",
                    ""id"": ""3125f65d-1752-40de-9f09-c23a678cf2b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Stun"",
                    ""type"": ""Button"",
                    ""id"": ""95930a3a-2c5a-4a2c-93da-d5b72e57c48d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8ec51d08-ed89-498c-a5e3-8f1f79027695"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e876de37-3300-437c-8083-b94f744c4b38"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""329d18e9-dab0-4fdb-9ab8-41f93790c607"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d848f273-a215-432f-baa6-377e2d64923b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""152ab9af-162d-4c6a-a0b0-9ac77bab2279"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cb69db1a-b722-4085-a70b-68b5f3738f8f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cac0ede-8b49-48ef-9fa3-310483a67bd5"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fed8d38c-7434-4f36-9c24-c62a68a1e5c7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ThirdPerson
        m_ThirdPerson = asset.FindActionMap("ThirdPerson", throwIfNotFound: true);
        m_ThirdPerson_Move = m_ThirdPerson.FindAction("Move", throwIfNotFound: true);
        m_ThirdPerson_Look = m_ThirdPerson.FindAction("Look", throwIfNotFound: true);
        m_ThirdPerson_PickUp = m_ThirdPerson.FindAction("PickUp", throwIfNotFound: true);
        m_ThirdPerson_Stun = m_ThirdPerson.FindAction("Stun", throwIfNotFound: true);
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

    // ThirdPerson
    private readonly InputActionMap m_ThirdPerson;
    private IThirdPersonActions m_ThirdPersonActionsCallbackInterface;
    private readonly InputAction m_ThirdPerson_Move;
    private readonly InputAction m_ThirdPerson_Look;
    private readonly InputAction m_ThirdPerson_PickUp;
    private readonly InputAction m_ThirdPerson_Stun;
    public struct ThirdPersonActions
    {
        private @PlayerInputActions m_Wrapper;
        public ThirdPersonActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ThirdPerson_Move;
        public InputAction @Look => m_Wrapper.m_ThirdPerson_Look;
        public InputAction @PickUp => m_Wrapper.m_ThirdPerson_PickUp;
        public InputAction @Stun => m_Wrapper.m_ThirdPerson_Stun;
        public InputActionMap Get() { return m_Wrapper.m_ThirdPerson; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ThirdPersonActions set) { return set.Get(); }
        public void SetCallbacks(IThirdPersonActions instance)
        {
            if (m_Wrapper.m_ThirdPersonActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnLook;
                @PickUp.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnPickUp;
                @PickUp.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnPickUp;
                @PickUp.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnPickUp;
                @Stun.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnStun;
                @Stun.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnStun;
                @Stun.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnStun;
            }
            m_Wrapper.m_ThirdPersonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @PickUp.started += instance.OnPickUp;
                @PickUp.performed += instance.OnPickUp;
                @PickUp.canceled += instance.OnPickUp;
                @Stun.started += instance.OnStun;
                @Stun.performed += instance.OnStun;
                @Stun.canceled += instance.OnStun;
            }
        }
    }
    public ThirdPersonActions @ThirdPerson => new ThirdPersonActions(this);
    public interface IThirdPersonActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnPickUp(InputAction.CallbackContext context);
        void OnStun(InputAction.CallbackContext context);
    }
}
