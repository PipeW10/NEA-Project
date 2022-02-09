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

    // Start is called before the first frame update
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        if (playerInput.devices [0].ToString() == "UnityEngine.InputSystem.Mouse")
        {
            Debug.Log("Mouse");
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        inputDevice = playerInput.devices[0];
        SpawnCharacter();
    }


    public void Fire1(InputAction.CallbackContext context)
    {
        if (context.performed && characterInputs != null)
        {
            characterInputs.Fire1(context);
        }
    }
    public void Fire2(InputAction.CallbackContext context)
    {
        if (context.performed && characterInputs != null)
        {
            characterInputs.Fire2(context);
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && playerController != null)
        {
            playerController.PlayerJump();
        }
    }
    public void Shield(InputAction.CallbackContext context)
    {
        if (context.performed && playerController != null)
        {
            shield.ShieldOn();
        }
        else if (context.canceled && playerController != null)
        {
            shield.ShieldOff();
        }
    }
    public void Movement(InputAction.CallbackContext context)
    {
        if(playerController != null)
        {
            playerController.Move(context.ReadValue<float>());
        }
    }

    public void Duck(InputAction.CallbackContext context)
    {
        if (context.performed && playerController != null)
        {
            StartCoroutine(playerController.PhaseThroughPlatform());
        }
    }
    public void UpAttack(InputAction.CallbackContext context)
    {
        if (context.performed && playerController != null)
        {
            upAttack.JumpAttack();
        }
    }

    private void SpawnCharacter()
    {
        if (inputDevice == PlayerManager.player1Input)
        {
            character = Instantiate(PlayerManager.player1Character, new Vector3(0, 0, 0), Quaternion.identity);
            LinkComponents();
        }
        else if (inputDevice == PlayerManager.player2Input)
        {
            character = Instantiate(PlayerManager.player2Character,  new Vector3(0, 0, 0), Quaternion.identity);
            LinkComponents();
        }
        else if (inputDevice == PlayerManager.player3Input)
        {
            character = Instantiate(PlayerManager.player3Character, new Vector3(0, 0, 0), Quaternion.identity);
            LinkComponents();
        }
        else if (inputDevice == PlayerManager.player4Input)
        {
            character = Instantiate(PlayerManager.player4Character, new Vector3(0, 0, 0), Quaternion.identity);
            LinkComponents();
        }

    }

    private void LinkComponents()
    {
        playerController = character.GetComponent<PlayerController>();
        upAttack = character.GetComponent<UpAttack>();
        shield = character.GetComponent<PlayerShield>();
        characterInputs = character.GetComponent<CharacterInputs>();
    }
}
