//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Inputs/Player/PlayerInputs.inputactions
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

public partial class @PlayerInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""World"",
            ""id"": ""e2bced94-0fd7-458a-a067-6b7cc53fc883"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4ef54d3c-3830-4498-bb2f-e16c4edbb9f5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c543d6df-2a06-4ac1-b4e0-a9fdde9bc8de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7a514f46-b6dd-49ae-9996-a1cdf0d8a6ba"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SprintStart"",
                    ""type"": ""Button"",
                    ""id"": ""61a06da3-7bcf-4a64-9b5f-17db6f0ccc52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SprintFinish"",
                    ""type"": ""Button"",
                    ""id"": ""0830b1ee-fb0c-41dd-9147-2b3f4223753b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextLevel"",
                    ""type"": ""Button"",
                    ""id"": ""e8546fc0-b572-44cf-a277-04b5b325d301"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GodMode"",
                    ""type"": ""Button"",
                    ""id"": ""8e75174c-006e-43bd-84c8-619069c982a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Flash"",
                    ""type"": ""Button"",
                    ""id"": ""0179f84f-b260-4db2-911e-bf4b08965f14"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FeatherFall"",
                    ""type"": ""Button"",
                    ""id"": ""f8510775-a1ff-46fc-8e71-122b92f36693"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UpMovementPress"",
                    ""type"": ""Button"",
                    ""id"": ""047b9ddd-e461-454b-9bbe-49b7cd9a3371"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UpMovementRelease"",
                    ""type"": ""Button"",
                    ""id"": ""a38fa12d-f1cb-4fbd-955e-13c3a17391ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DownMovementPress"",
                    ""type"": ""Button"",
                    ""id"": ""bc5b9a8c-69ca-41f7-99ce-d7653145ae3d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DownMovementRelease"",
                    ""type"": ""Button"",
                    ""id"": ""72b40c4e-ea55-4898-ab1e-90c210d3bf87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""564863c6-0710-4527-9a73-c78e3888e787"",
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
                    ""id"": ""743350b8-d049-4902-9369-566fd73d3525"",
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
                    ""id"": ""69223212-a682-452d-b7cf-446bd6fb4ca7"",
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
                    ""id"": ""afab4bd0-ec1f-4b24-b411-5bd2c794ffb1"",
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
                    ""id"": ""510b0b1a-6e12-4aa2-a440-41687157ca21"",
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
                    ""id"": ""b15527e4-5978-40d1-89e4-bc0c2a9c0ae0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""127a2307-8f86-4e79-9c83-946ed8bdea4f"",
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
                    ""id"": ""6fc6d241-1412-41f2-93d2-a69dad97c29c"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43e41a8b-2073-44d2-87ae-60317bed892f"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintFinish"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""9caf8c4a-76fe-4c16-a9fa-49e7736f0d5c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.1,max=1)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e55a6d0a-6a16-437f-88bf-c962cc78db2c"",
                    ""path"": ""<DualShockGamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""170fc165-3a7a-4cdf-9518-c1a16ef31229"",
                    ""path"": ""<DualShockGamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""23afd8e3-77e8-4643-a12f-49b8602d5ef9"",
                    ""path"": ""<DualShockGamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""26673f49-093d-4c0c-94f5-d7f935b16485"",
                    ""path"": ""<DualShockGamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bed663ef-ea17-4e85-b8b3-ddb905580207"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0823e1c-b4fc-47f9-9072-f2d5e3f9286a"",
                    ""path"": ""<DualShockGamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone(min=0.2,max=0.8)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8ab8256-3097-41fa-9e14-c7e1d3641238"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": ""Press(pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4f6b551-35a5-4f91-b54c-8af626542606"",
                    ""path"": ""<DualShockGamepad>/leftShoulder"",
                    ""interactions"": ""Press(pressPoint=1,behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SprintFinish"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fedb0ab-6cfa-4862-add5-e5df27ccbf73"",
                    ""path"": ""<Keyboard>/f9"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ee3d3e5-887c-49af-a172-94188e2e4251"",
                    ""path"": ""<DualShockGamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cdf929b-3456-4f72-8727-defa8f0b9792"",
                    ""path"": ""<Keyboard>/f10"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GodMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc2e13e0-2461-4fe6-af32-0005b1aea2a2"",
                    ""path"": ""<DualShockGamepad>/dpad/down"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GodMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c39c5368-1d14-47ec-8f70-a1aa438cebac"",
                    ""path"": ""<Keyboard>/f11"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a476bd9-244b-410c-81fa-034ef538054e"",
                    ""path"": ""<DualShockGamepad>/dpad/right"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""564290ce-a5d1-42dd-b804-edf3f023163c"",
                    ""path"": ""<Keyboard>/f12"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FeatherFall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5128b865-ff43-4ce7-817a-57e02ddacdb0"",
                    ""path"": ""<DualShockGamepad>/dpad/up"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FeatherFall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67aa033b-c295-44d2-8bb5-cb0fb9fc46f3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMovementPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e621c740-7e21-4971-86a3-329b2251f386"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMovementPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd09e8d6-3d7f-4e5b-b7c9-4c21a4cf3ff7"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownMovementPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6c4ecdc-baaf-4c10-abb4-39a028b73f8c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownMovementPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef655b8f-2b57-425b-9cae-de718de30caf"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownMovementPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""928123ba-46b9-48df-882c-bbbf9816de30"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMovementRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a20ad454-7e19-4826-b549-4c0f1929fcf3"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpMovementRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""448b2e0b-533f-46bc-adc4-7627b9578f29"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownMovementRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c23a3a6-f67d-4ad6-9257-e2af57b47885"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownMovementRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94d2619d-b29e-415b-8dad-c48051eb6064"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownMovementRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // World
        m_World = asset.FindActionMap("World", throwIfNotFound: true);
        m_World_Move = m_World.FindAction("Move", throwIfNotFound: true);
        m_World_Jump = m_World.FindAction("Jump", throwIfNotFound: true);
        m_World_Look = m_World.FindAction("Look", throwIfNotFound: true);
        m_World_SprintStart = m_World.FindAction("SprintStart", throwIfNotFound: true);
        m_World_SprintFinish = m_World.FindAction("SprintFinish", throwIfNotFound: true);
        m_World_NextLevel = m_World.FindAction("NextLevel", throwIfNotFound: true);
        m_World_GodMode = m_World.FindAction("GodMode", throwIfNotFound: true);
        m_World_Flash = m_World.FindAction("Flash", throwIfNotFound: true);
        m_World_FeatherFall = m_World.FindAction("FeatherFall", throwIfNotFound: true);
        m_World_UpMovementPress = m_World.FindAction("UpMovementPress", throwIfNotFound: true);
        m_World_UpMovementRelease = m_World.FindAction("UpMovementRelease", throwIfNotFound: true);
        m_World_DownMovementPress = m_World.FindAction("DownMovementPress", throwIfNotFound: true);
        m_World_DownMovementRelease = m_World.FindAction("DownMovementRelease", throwIfNotFound: true);
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

    // World
    private readonly InputActionMap m_World;
    private List<IWorldActions> m_WorldActionsCallbackInterfaces = new List<IWorldActions>();
    private readonly InputAction m_World_Move;
    private readonly InputAction m_World_Jump;
    private readonly InputAction m_World_Look;
    private readonly InputAction m_World_SprintStart;
    private readonly InputAction m_World_SprintFinish;
    private readonly InputAction m_World_NextLevel;
    private readonly InputAction m_World_GodMode;
    private readonly InputAction m_World_Flash;
    private readonly InputAction m_World_FeatherFall;
    private readonly InputAction m_World_UpMovementPress;
    private readonly InputAction m_World_UpMovementRelease;
    private readonly InputAction m_World_DownMovementPress;
    private readonly InputAction m_World_DownMovementRelease;
    public struct WorldActions
    {
        private @PlayerInputs m_Wrapper;
        public WorldActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_World_Move;
        public InputAction @Jump => m_Wrapper.m_World_Jump;
        public InputAction @Look => m_Wrapper.m_World_Look;
        public InputAction @SprintStart => m_Wrapper.m_World_SprintStart;
        public InputAction @SprintFinish => m_Wrapper.m_World_SprintFinish;
        public InputAction @NextLevel => m_Wrapper.m_World_NextLevel;
        public InputAction @GodMode => m_Wrapper.m_World_GodMode;
        public InputAction @Flash => m_Wrapper.m_World_Flash;
        public InputAction @FeatherFall => m_Wrapper.m_World_FeatherFall;
        public InputAction @UpMovementPress => m_Wrapper.m_World_UpMovementPress;
        public InputAction @UpMovementRelease => m_Wrapper.m_World_UpMovementRelease;
        public InputAction @DownMovementPress => m_Wrapper.m_World_DownMovementPress;
        public InputAction @DownMovementRelease => m_Wrapper.m_World_DownMovementRelease;
        public InputActionMap Get() { return m_Wrapper.m_World; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WorldActions set) { return set.Get(); }
        public void AddCallbacks(IWorldActions instance)
        {
            if (instance == null || m_Wrapper.m_WorldActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WorldActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @SprintStart.started += instance.OnSprintStart;
            @SprintStart.performed += instance.OnSprintStart;
            @SprintStart.canceled += instance.OnSprintStart;
            @SprintFinish.started += instance.OnSprintFinish;
            @SprintFinish.performed += instance.OnSprintFinish;
            @SprintFinish.canceled += instance.OnSprintFinish;
            @NextLevel.started += instance.OnNextLevel;
            @NextLevel.performed += instance.OnNextLevel;
            @NextLevel.canceled += instance.OnNextLevel;
            @GodMode.started += instance.OnGodMode;
            @GodMode.performed += instance.OnGodMode;
            @GodMode.canceled += instance.OnGodMode;
            @Flash.started += instance.OnFlash;
            @Flash.performed += instance.OnFlash;
            @Flash.canceled += instance.OnFlash;
            @FeatherFall.started += instance.OnFeatherFall;
            @FeatherFall.performed += instance.OnFeatherFall;
            @FeatherFall.canceled += instance.OnFeatherFall;
            @UpMovementPress.started += instance.OnUpMovementPress;
            @UpMovementPress.performed += instance.OnUpMovementPress;
            @UpMovementPress.canceled += instance.OnUpMovementPress;
            @UpMovementRelease.started += instance.OnUpMovementRelease;
            @UpMovementRelease.performed += instance.OnUpMovementRelease;
            @UpMovementRelease.canceled += instance.OnUpMovementRelease;
            @DownMovementPress.started += instance.OnDownMovementPress;
            @DownMovementPress.performed += instance.OnDownMovementPress;
            @DownMovementPress.canceled += instance.OnDownMovementPress;
            @DownMovementRelease.started += instance.OnDownMovementRelease;
            @DownMovementRelease.performed += instance.OnDownMovementRelease;
            @DownMovementRelease.canceled += instance.OnDownMovementRelease;
        }

        private void UnregisterCallbacks(IWorldActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @SprintStart.started -= instance.OnSprintStart;
            @SprintStart.performed -= instance.OnSprintStart;
            @SprintStart.canceled -= instance.OnSprintStart;
            @SprintFinish.started -= instance.OnSprintFinish;
            @SprintFinish.performed -= instance.OnSprintFinish;
            @SprintFinish.canceled -= instance.OnSprintFinish;
            @NextLevel.started -= instance.OnNextLevel;
            @NextLevel.performed -= instance.OnNextLevel;
            @NextLevel.canceled -= instance.OnNextLevel;
            @GodMode.started -= instance.OnGodMode;
            @GodMode.performed -= instance.OnGodMode;
            @GodMode.canceled -= instance.OnGodMode;
            @Flash.started -= instance.OnFlash;
            @Flash.performed -= instance.OnFlash;
            @Flash.canceled -= instance.OnFlash;
            @FeatherFall.started -= instance.OnFeatherFall;
            @FeatherFall.performed -= instance.OnFeatherFall;
            @FeatherFall.canceled -= instance.OnFeatherFall;
            @UpMovementPress.started -= instance.OnUpMovementPress;
            @UpMovementPress.performed -= instance.OnUpMovementPress;
            @UpMovementPress.canceled -= instance.OnUpMovementPress;
            @UpMovementRelease.started -= instance.OnUpMovementRelease;
            @UpMovementRelease.performed -= instance.OnUpMovementRelease;
            @UpMovementRelease.canceled -= instance.OnUpMovementRelease;
            @DownMovementPress.started -= instance.OnDownMovementPress;
            @DownMovementPress.performed -= instance.OnDownMovementPress;
            @DownMovementPress.canceled -= instance.OnDownMovementPress;
            @DownMovementRelease.started -= instance.OnDownMovementRelease;
            @DownMovementRelease.performed -= instance.OnDownMovementRelease;
            @DownMovementRelease.canceled -= instance.OnDownMovementRelease;
        }

        public void RemoveCallbacks(IWorldActions instance)
        {
            if (m_Wrapper.m_WorldActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWorldActions instance)
        {
            foreach (var item in m_Wrapper.m_WorldActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WorldActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WorldActions @World => new WorldActions(this);
    public interface IWorldActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnSprintStart(InputAction.CallbackContext context);
        void OnSprintFinish(InputAction.CallbackContext context);
        void OnNextLevel(InputAction.CallbackContext context);
        void OnGodMode(InputAction.CallbackContext context);
        void OnFlash(InputAction.CallbackContext context);
        void OnFeatherFall(InputAction.CallbackContext context);
        void OnUpMovementPress(InputAction.CallbackContext context);
        void OnUpMovementRelease(InputAction.CallbackContext context);
        void OnDownMovementPress(InputAction.CallbackContext context);
        void OnDownMovementRelease(InputAction.CallbackContext context);
    }
}
