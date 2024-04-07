//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/InputMap/InputMap.inputactions
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

namespace NewInputSystem
{
    public partial class @InputMap: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""d552b217-8edf-4881-a8e2-d87b0c1d1db6"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""4079372f-01f0-490c-adea-f5a0eb15a8a0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LeftButton"",
                    ""type"": ""Button"",
                    ""id"": ""04ef8e91-ca63-44ed-b175-ae6796e33cc1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightButton"",
                    ""type"": ""Button"",
                    ""id"": ""6bd91e6a-8699-4a1c-be13-5c8b3087b7ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fe9684a5-3b99-4df8-bf68-2d52789dec5e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ae11804-a9e5-4873-a757-22df55651a63"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60bf4917-1c27-4fc9-8bfc-e2a243c620a4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""LeftButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87fdf3b9-b5ba-4420-bf3e-1ecdb8abc963"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""RightButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""id"": ""cc03b1ce-032e-43c6-8a1d-31b8731e007d"",
            ""actions"": [
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""60f887fe-cde5-48bd-8877-5cd78006b713"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4a2baec4-68b9-4ce8-a421-7d508c5f81eb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": []
        }
    ]
}");
            // Mouse
            m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
            m_Mouse_MousePosition = m_Mouse.FindAction("MousePosition", throwIfNotFound: true);
            m_Mouse_LeftButton = m_Mouse.FindAction("LeftButton", throwIfNotFound: true);
            m_Mouse_RightButton = m_Mouse.FindAction("RightButton", throwIfNotFound: true);
            // Keyboard
            m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
            m_Keyboard_Exit = m_Keyboard.FindAction("Exit", throwIfNotFound: true);
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

        // Mouse
        private readonly InputActionMap m_Mouse;
        private List<IMouseActions> m_MouseActionsCallbackInterfaces = new List<IMouseActions>();
        private readonly InputAction m_Mouse_MousePosition;
        private readonly InputAction m_Mouse_LeftButton;
        private readonly InputAction m_Mouse_RightButton;
        public struct MouseActions
        {
            private @InputMap m_Wrapper;
            public MouseActions(@InputMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @MousePosition => m_Wrapper.m_Mouse_MousePosition;
            public InputAction @LeftButton => m_Wrapper.m_Mouse_LeftButton;
            public InputAction @RightButton => m_Wrapper.m_Mouse_RightButton;
            public InputActionMap Get() { return m_Wrapper.m_Mouse; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
            public void AddCallbacks(IMouseActions instance)
            {
                if (instance == null || m_Wrapper.m_MouseActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_MouseActionsCallbackInterfaces.Add(instance);
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @LeftButton.started += instance.OnLeftButton;
                @LeftButton.performed += instance.OnLeftButton;
                @LeftButton.canceled += instance.OnLeftButton;
                @RightButton.started += instance.OnRightButton;
                @RightButton.performed += instance.OnRightButton;
                @RightButton.canceled += instance.OnRightButton;
            }

            private void UnregisterCallbacks(IMouseActions instance)
            {
                @MousePosition.started -= instance.OnMousePosition;
                @MousePosition.performed -= instance.OnMousePosition;
                @MousePosition.canceled -= instance.OnMousePosition;
                @LeftButton.started -= instance.OnLeftButton;
                @LeftButton.performed -= instance.OnLeftButton;
                @LeftButton.canceled -= instance.OnLeftButton;
                @RightButton.started -= instance.OnRightButton;
                @RightButton.performed -= instance.OnRightButton;
                @RightButton.canceled -= instance.OnRightButton;
            }

            public void RemoveCallbacks(IMouseActions instance)
            {
                if (m_Wrapper.m_MouseActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IMouseActions instance)
            {
                foreach (var item in m_Wrapper.m_MouseActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_MouseActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public MouseActions @Mouse => new MouseActions(this);

        // Keyboard
        private readonly InputActionMap m_Keyboard;
        private List<IKeyboardActions> m_KeyboardActionsCallbackInterfaces = new List<IKeyboardActions>();
        private readonly InputAction m_Keyboard_Exit;
        public struct KeyboardActions
        {
            private @InputMap m_Wrapper;
            public KeyboardActions(@InputMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @Exit => m_Wrapper.m_Keyboard_Exit;
            public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
            public void AddCallbacks(IKeyboardActions instance)
            {
                if (instance == null || m_Wrapper.m_KeyboardActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_KeyboardActionsCallbackInterfaces.Add(instance);
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }

            private void UnregisterCallbacks(IKeyboardActions instance)
            {
                @Exit.started -= instance.OnExit;
                @Exit.performed -= instance.OnExit;
                @Exit.canceled -= instance.OnExit;
            }

            public void RemoveCallbacks(IKeyboardActions instance)
            {
                if (m_Wrapper.m_KeyboardActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IKeyboardActions instance)
            {
                foreach (var item in m_Wrapper.m_KeyboardActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_KeyboardActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public KeyboardActions @Keyboard => new KeyboardActions(this);
        private int m_KeyboardAndMouseSchemeIndex = -1;
        public InputControlScheme KeyboardAndMouseScheme
        {
            get
            {
                if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
                return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
            }
        }
        public interface IMouseActions
        {
            void OnMousePosition(InputAction.CallbackContext context);
            void OnLeftButton(InputAction.CallbackContext context);
            void OnRightButton(InputAction.CallbackContext context);
        }
        public interface IKeyboardActions
        {
            void OnExit(InputAction.CallbackContext context);
        }
    }
}
