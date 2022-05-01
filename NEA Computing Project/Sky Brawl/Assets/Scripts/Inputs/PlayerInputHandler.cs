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
        //Finds the playerInput component on the object instantiated by the Player Input Manager when a new player joins
        playerInput = GetComponent<PlayerInput>();
        //If the input device that joined was a mouse
        if (playerInput.devices [0].ToString() == "UnityEngine.InputSystem.Mouse")
        {
            //Disable then destroy the gameObject
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        //Sets the inputDevice variable to the inputDevice currently in use
        inputDevice = playerInput.devices[0];
        //Calls the spawn character method
        SpawnCharacter();
        //Calls the wait for players method from the player manager script
        FindObjectOfType<PlayerManager>().WaitForPlayers(true);
    }

    //Method is called whenever the Fire1 input is pressed by the player
    public void Fire1(InputAction.CallbackContext context)
    {
        //If the input was "performed" and the character inputs is not null
        if (context.performed && characterInputs != null)
        {
            //Calls the Fire1 method on the characterInputs script
            characterInputs.Fire1(context);
        }
    }
    //Method is called whenever the Fire2 input is pressed by the player
    public void Fire2(InputAction.CallbackContext context)
    {
        //If the input was "performed" and the character inputs is not null
        if (context.performed && characterInputs != null)
        {
            //Calls the Fire2 method on the characterInputs script
            characterInputs.Fire2(context);
        }
    }
    //Method is called whenever the Jump input is pressed by the player
    public void Jump(InputAction.CallbackContext context)
    {
        //If the input was "performed" and the character inputs is not null and is enabled
        if (context.performed && playerController != null && playerController.isActiveAndEnabled)
        {
            //Calls the PlayerJump method on the playerController script
            playerController.PlayerJump();
        }
    }
    //Method is called whenever the Shield input is pressed by the player
    public void Shield(InputAction.CallbackContext context)
    {
        //If the input was "performed" and the shield is not null
        if (context.performed && shield != null)
        {
            //Calls the shieldOn method on the shield component
            shield.ShieldOn();
        }
        //If the input was "canceled" and the shield is not null
        else if (context.canceled && shield != null)
        {
            //Calls the shieldOff method on the shield component
            shield.ShieldOff();
        }
    }
    //Method is called whenever the Movement input is performed by the player
    public void Movement(InputAction.CallbackContext context)
    {
        //If the playerController is not null and is enabled
        if(playerController != null && playerController.isActiveAndEnabled)
        {
            //Calls the Move method on the player controller and passes the value of the input as a float
            playerController.Move(context.ReadValue<float>());
        }
    }
    //Method is called whenever the Duck input is pressed by the player
    public void Duck(InputAction.CallbackContext context)
    {
        //If the input was "performed" and the playercontroller is not null and is enabled
        if (context.performed && playerController != null && playerController.isActiveAndEnabled)
        {
            //Calls the PhaseThroughPlatform method on the playerController
            StartCoroutine(playerController.PhaseThroughPlatform());
        }
    }
    //Method is called whenever the UpAttack input is pressed by the player
    public void UpAttack(InputAction.CallbackContext context)
    {
        //If the input was "performed" and the upAttack is not null and that the player controller is enabled
        if (context.performed && upAttack != null && playerController.isActiveAndEnabled)
        {
            //Calls the JumpAttack method on the up attack script
            upAttack.JumpAttack();
        }
    }

    //Is used to spawn the correct character at the beginning of a match
    private void SpawnCharacter()
    {
        //Used so each character has a unique number stored in their player script
        //  this number is then used to store match stats in the player manager
        int playerNumber = 0;
        //Compares each input device stored to the input device currently in use
        //Then, instantiates the correct character
        if (inputDevice == PlayerManager.player1Input)
        {
            character = Instantiate(PlayerManager.player1Character, new Vector3(0, 0, 0), Quaternion.identity);
            LinkComponents();
            playerNumber = 1;
        }
        else if (inputDevice == PlayerManager.player2Input)
        {
            character = Instantiate(PlayerManager.player2Character,  new Vector3(0, 0, 0), Quaternion.identity);
            LinkComponents();
            playerNumber = 2;
        }
        else if (inputDevice == PlayerManager.player3Input)
        {
            character = Instantiate(PlayerManager.player3Character, new Vector3(0, 0, 0), Quaternion.identity);
            LinkComponents();
            playerNumber = 3;
        }
        else if (inputDevice == PlayerManager.player4Input)
        {
            character = Instantiate(PlayerManager.player4Character, new Vector3(0, 0, 0), Quaternion.identity);
            LinkComponents();
            playerNumber = 4;
        }
        //Sets the character number in the player script
        character.GetComponent<Player>().characterNumber = playerNumber;
    }

    //Links each component on the instatiated character
    private void LinkComponents()
    {
        playerController = character.GetComponent<PlayerController>();
        upAttack = character.GetComponent<UpAttack>();
        shield = character.GetComponent<PlayerShield>();
        characterInputs = character.GetComponent<CharacterInputs>();
    }
}
