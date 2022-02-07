using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoining : MonoBehaviour
{
    private InputDevice input;
    private PlayerInput playerInput;
    private CharacterSelection selectManager;
    
    //First Method to be called in the script
    private void Awake()
    {
        //Finds a CharacterSelection object in the scene
        selectManager = FindObjectOfType<CharacterSelection>();
        //Finds the player input component 
        playerInput = GetComponent<PlayerInput>();
        //Calls the linkInput method
        LinkInput();
    }

    //Links an input device to a new player
    private void LinkInput()
    {
        //If the device is not a mouse
        if (playerInput.devices[0].GetType().ToString() != "UnityEngine.InputSystem.Mouse" /*&& selectManager.numberPlayers < 4*/)
        {
            //Sets the input variable to the input device
            input = playerInput.devices[0];
            //Calls the AddPlayerDevice method in the CharacterSelection script
            selectManager.AddPlayerDevice(input);
            //Outputs a log saying Input found
            Debug.Log("Input found");
        }
        //If the input device is a mouse
        else
        {
            Debug.Log("Mouse");
        }
    }
}
