// GENERATED AUTOMATICALLY FROM 'Assets/Input System/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""MainMap"",
            ""id"": ""088824e5-116d-4123-af75-654f74ad9e96"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""21008fc3-988b-4936-84e1-498c38703ac0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Value"",
                    ""id"": ""8eefa2ec-38c0-4a5c-8c55-002261ad0c27"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""8f886d88-f6b4-4268-b148-427c0168de2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""28c95961-7759-40f1-9cfb-00bbe063b594"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b50a503e-5744-4fc7-9595-8c66ed81d244"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac4e6b1a-3075-4cc2-a67c-293d569fe889"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ae3b17e-34e1-48fc-bca8-12017f83b630"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0e5e2e1-15b5-4a00-ac5e-0250f0e40155"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game"",
            ""id"": ""68597168-2711-4a5f-9fef-0a7e30fcfde8"",
            ""actions"": [
                {
                    ""name"": ""Fire 1"",
                    ""type"": ""Button"",
                    ""id"": ""98e8d1d6-3cec-4f01-a3c3-25bd98b86528"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire 2"",
                    ""type"": ""Button"",
                    ""id"": ""96d46f68-bbdd-42f8-9042-f18466a51dc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""36d3852d-f2db-44f9-8a0f-dea82e5e880c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shield"",
                    ""type"": ""Button"",
                    ""id"": ""2a89258f-ba0b-4fb8-9874-158faf8a79c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X Movement"",
                    ""type"": ""Button"",
                    ""id"": ""c6ad43a4-c2b1-4335-8afb-bc584a82a45f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Duck"",
                    ""type"": ""Button"",
                    ""id"": ""04f7d461-ac34-42b1-b4dc-241f47f46363"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up Attack"",
                    ""type"": ""Button"",
                    ""id"": ""bca1868f-421c-45a9-9375-56d8f1157d75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a21b2181-2df7-4bcc-8ed1-ad177b9f04f2"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Fire 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60a18a82-ffaf-4360-b66a-b43171e35e15"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Fire 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad4dabbd-c18d-474a-b12c-d0cc0751f98e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Fire 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""567a9fb0-ea3f-43c9-9789-59b9aaa95bcf"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Fire 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6901ae8-91f1-4056-a4ea-8238aeb1deab"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Fire 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83b19793-0259-4149-b4cb-4b8b3c478fda"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Fire 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""676b7d3b-fd8c-422c-aa74-92d18b114dbd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05271786-ab05-41cb-bc9d-cafd987c8261"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53ecd3c5-9f1a-45bd-a9c5-719a71d86439"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8fd3294-29c5-441e-85be-1c7f2366fe33"",
                    ""path"": ""<SwitchProControllerHID>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da168e7f-fcff-4818-b9a8-0e891e0ecab1"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1f03742-8a87-42fd-a664-35c778996897"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54c9100e-97ef-4cba-8f1c-5bd8274d125a"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""675cfc0d-4f3d-4865-8b49-8080e8de4f77"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""e0787038-a6b1-4ab8-a7b6-2c2b878ed297"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""737e958c-69df-480b-aec2-424efdfe4592"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""X Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fb7c1d96-951b-4a57-87ae-2c76b390bf83"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""X Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Switch"",
                    ""id"": ""dde0e8fb-2bdd-4104-802b-c3b688818f9f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0b786d2a-88ff-42d8-95e7-e0744cc19a49"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""X Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fe9a44f2-392b-45e4-85cd-d866fe2011c4"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""X Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox"",
                    ""id"": ""ac8d3e44-fa9e-4a42-8e10-019f96dccf31"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""238595af-68e4-466d-b205-b483d13f4a73"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""X Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7e48a6bc-76f1-4976-b749-6b69590f8e99"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""X Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0c996213-27bb-4dc0-b92e-88d91654c447"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ca6a1a9-50b2-4b6e-bbbf-6652d87506d7"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13fbb145-e337-4d8b-9196-5955efc6d8e1"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""486f92c4-8e7f-4d9f-8af6-7683d985aa6d"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up Attack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""1607843e-0031-4c69-aea9-0f06c91243c1"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Up Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""78cc3f24-b90b-44a2-96d9-0784fda9c595"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Up Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox Button"",
                    ""id"": ""95f6ef0c-d308-41b6-9ac0-63da78985577"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up Attack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""3a4e31e1-0e71-4d53-8180-fa147da2cfb3"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Up Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""c18059cc-bace-40a6-bb3c-45f194554132"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Up Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Xbox Stick"",
                    ""id"": ""f18a9eaa-e633-4f47-b091-cf1c889f8f1c"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up Attack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0513934a-3f6f-4548-8d98-163326f100b5"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Up Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""07d2104a-0119-46db-8e15-921a63b41e97"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Up Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Switch Stick"",
                    ""id"": ""60566baf-caef-4206-97e4-125a4f55bfb5"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up Attack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""02e88770-4bf6-4501-aa26-46cfc6dc58fa"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Up Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""f30a843d-0cf5-4325-899d-839b1a52f1f4"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Up Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Switch Y"",
                    ""id"": ""39080da0-20a4-4a55-8fb3-200eb15a1ab3"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up Attack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""a67d17b6-b98b-4ca6-8f8f-515415372307"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Up Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""10bf5088-bdfa-4ab7-987f-9dc929ee62a9"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Up Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Swicth B"",
                    ""id"": ""acbfa79c-d382-4b0d-85fc-3f390333605f"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up Attack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""fcb81925-6961-40d7-ab19-c912281964e5"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Up Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""8d41c0c5-b2a6-4981-b153-1aa09c13ba6a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Switch"",
                    ""action"": ""Up Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Selection"",
            ""id"": ""71b3d961-c062-46b7-a001-2351c468da7d"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""8eca82dd-ca1e-4a76-95cf-806d9f7a2f0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Value"",
                    ""id"": ""a56f6092-167a-4a78-b822-f9354c15e96c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8c390afa-2fa3-4f03-9e2d-25ca819da7a4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e444412b-3cda-4260-814b-5a5447bce4f5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e60cf74c-0291-4156-9ef1-77b84461c90f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainMap
        m_MainMap = asset.FindActionMap("MainMap", throwIfNotFound: true);
        m_MainMap_Click = m_MainMap.FindAction("Click", throwIfNotFound: true);
        m_MainMap_Drag = m_MainMap.FindAction("Drag", throwIfNotFound: true);
        m_MainMap_Back = m_MainMap.FindAction("Back", throwIfNotFound: true);
        m_MainMap_Escape = m_MainMap.FindAction("Escape", throwIfNotFound: true);
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Fire1 = m_Game.FindAction("Fire 1", throwIfNotFound: true);
        m_Game_Fire2 = m_Game.FindAction("Fire 2", throwIfNotFound: true);
        m_Game_Jump = m_Game.FindAction("Jump", throwIfNotFound: true);
        m_Game_Shield = m_Game.FindAction("Shield", throwIfNotFound: true);
        m_Game_XMovement = m_Game.FindAction("X Movement", throwIfNotFound: true);
        m_Game_Duck = m_Game.FindAction("Duck", throwIfNotFound: true);
        m_Game_UpAttack = m_Game.FindAction("Up Attack", throwIfNotFound: true);
        // Selection
        m_Selection = asset.FindActionMap("Selection", throwIfNotFound: true);
        m_Selection_Click = m_Selection.FindAction("Click", throwIfNotFound: true);
        m_Selection_Drag = m_Selection.FindAction("Drag", throwIfNotFound: true);
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

    // MainMap
    private readonly InputActionMap m_MainMap;
    private IMainMapActions m_MainMapActionsCallbackInterface;
    private readonly InputAction m_MainMap_Click;
    private readonly InputAction m_MainMap_Drag;
    private readonly InputAction m_MainMap_Back;
    private readonly InputAction m_MainMap_Escape;
    public struct MainMapActions
    {
        private @PlayerControls m_Wrapper;
        public MainMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_MainMap_Click;
        public InputAction @Drag => m_Wrapper.m_MainMap_Drag;
        public InputAction @Back => m_Wrapper.m_MainMap_Back;
        public InputAction @Escape => m_Wrapper.m_MainMap_Escape;
        public InputActionMap Get() { return m_Wrapper.m_MainMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMapActions set) { return set.Get(); }
        public void SetCallbacks(IMainMapActions instance)
        {
            if (m_Wrapper.m_MainMapActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_MainMapActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_MainMapActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_MainMapActionsCallbackInterface.OnClick;
                @Drag.started -= m_Wrapper.m_MainMapActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_MainMapActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_MainMapActionsCallbackInterface.OnDrag;
                @Back.started -= m_Wrapper.m_MainMapActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MainMapActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MainMapActionsCallbackInterface.OnBack;
                @Escape.started -= m_Wrapper.m_MainMapActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_MainMapActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_MainMapActionsCallbackInterface.OnEscape;
            }
            m_Wrapper.m_MainMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
            }
        }
    }
    public MainMapActions @MainMap => new MainMapActions(this);

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Fire1;
    private readonly InputAction m_Game_Fire2;
    private readonly InputAction m_Game_Jump;
    private readonly InputAction m_Game_Shield;
    private readonly InputAction m_Game_XMovement;
    private readonly InputAction m_Game_Duck;
    private readonly InputAction m_Game_UpAttack;
    public struct GameActions
    {
        private @PlayerControls m_Wrapper;
        public GameActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire1 => m_Wrapper.m_Game_Fire1;
        public InputAction @Fire2 => m_Wrapper.m_Game_Fire2;
        public InputAction @Jump => m_Wrapper.m_Game_Jump;
        public InputAction @Shield => m_Wrapper.m_Game_Shield;
        public InputAction @XMovement => m_Wrapper.m_Game_XMovement;
        public InputAction @Duck => m_Wrapper.m_Game_Duck;
        public InputAction @UpAttack => m_Wrapper.m_Game_UpAttack;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Fire1.started -= m_Wrapper.m_GameActionsCallbackInterface.OnFire1;
                @Fire1.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnFire1;
                @Fire1.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnFire1;
                @Fire2.started -= m_Wrapper.m_GameActionsCallbackInterface.OnFire2;
                @Fire2.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnFire2;
                @Fire2.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnFire2;
                @Jump.started -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Shield.started -= m_Wrapper.m_GameActionsCallbackInterface.OnShield;
                @Shield.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnShield;
                @Shield.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnShield;
                @XMovement.started -= m_Wrapper.m_GameActionsCallbackInterface.OnXMovement;
                @XMovement.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnXMovement;
                @XMovement.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnXMovement;
                @Duck.started -= m_Wrapper.m_GameActionsCallbackInterface.OnDuck;
                @Duck.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnDuck;
                @Duck.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnDuck;
                @UpAttack.started -= m_Wrapper.m_GameActionsCallbackInterface.OnUpAttack;
                @UpAttack.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnUpAttack;
                @UpAttack.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnUpAttack;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire1.started += instance.OnFire1;
                @Fire1.performed += instance.OnFire1;
                @Fire1.canceled += instance.OnFire1;
                @Fire2.started += instance.OnFire2;
                @Fire2.performed += instance.OnFire2;
                @Fire2.canceled += instance.OnFire2;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Shield.started += instance.OnShield;
                @Shield.performed += instance.OnShield;
                @Shield.canceled += instance.OnShield;
                @XMovement.started += instance.OnXMovement;
                @XMovement.performed += instance.OnXMovement;
                @XMovement.canceled += instance.OnXMovement;
                @Duck.started += instance.OnDuck;
                @Duck.performed += instance.OnDuck;
                @Duck.canceled += instance.OnDuck;
                @UpAttack.started += instance.OnUpAttack;
                @UpAttack.performed += instance.OnUpAttack;
                @UpAttack.canceled += instance.OnUpAttack;
            }
        }
    }
    public GameActions @Game => new GameActions(this);

    // Selection
    private readonly InputActionMap m_Selection;
    private ISelectionActions m_SelectionActionsCallbackInterface;
    private readonly InputAction m_Selection_Click;
    private readonly InputAction m_Selection_Drag;
    public struct SelectionActions
    {
        private @PlayerControls m_Wrapper;
        public SelectionActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_Selection_Click;
        public InputAction @Drag => m_Wrapper.m_Selection_Drag;
        public InputActionMap Get() { return m_Wrapper.m_Selection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectionActions set) { return set.Get(); }
        public void SetCallbacks(ISelectionActions instance)
        {
            if (m_Wrapper.m_SelectionActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnClick;
                @Drag.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnDrag;
            }
            m_Wrapper.m_SelectionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
            }
        }
    }
    public SelectionActions @Selection => new SelectionActions(this);
    public interface IMainMapActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
    }
    public interface IGameActions
    {
        void OnFire1(InputAction.CallbackContext context);
        void OnFire2(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
        void OnXMovement(InputAction.CallbackContext context);
        void OnDuck(InputAction.CallbackContext context);
        void OnUpAttack(InputAction.CallbackContext context);
    }
    public interface ISelectionActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
    }
}
