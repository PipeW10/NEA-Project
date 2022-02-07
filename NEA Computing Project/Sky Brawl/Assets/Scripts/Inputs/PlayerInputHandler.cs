using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputDevice inputDevice;
    private GameObject character;
    private CharacterInputs characterInputs;
    private PlayerController playerController;
    private UpAttack upAttack;
    private PlayerShield shield;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputDevice = playerInput.devices[0];
        SpawnCharacter();
        SetCharacterInput();
        playerController = character.GetComponent<PlayerController>();
        upAttack = character.GetComponent<UpAttack>();
        shield = character.GetComponent<PlayerShield>();
    }


    public void Fire1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            characterInputs.Fire1(context);
        }
    }
    public void Fire2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            characterInputs.Fire2(context);
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerController.PlayerJump();
        }
    }
    public void Shield(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shield.ShieldOn();
        }
        else if (context.canceled)
        {
            shield.ShieldOff();
        }
    }
    public void Movement(InputAction.CallbackContext context)
    {
        playerController.Move(context.ReadValue<Vector2>());
    }
    public void Duck(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(playerController.PhaseThroughPlatform());
        }
    }
    public void UpAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            upAttack.JumpAttack();
        }
    }

    private void SetCharacterInput()
    {
         characterInputs = character.GetComponent<CharacterInputs>();
    }

    private void SpawnCharacter()
    {
        if (inputDevice == PlayerManager.player1Input)
        {
            character = Instantiate(PlayerManager.playerCharacters[0], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (inputDevice == PlayerManager.player2Input)
        {
            character = Instantiate(PlayerManager.playerCharacters[1], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (inputDevice == PlayerManager.player3Input)
        {
            character = Instantiate(PlayerManager.playerCharacters[2], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (inputDevice == PlayerManager.player4Input)
        {
            character = Instantiate(PlayerManager.playerCharacters[3], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

}
