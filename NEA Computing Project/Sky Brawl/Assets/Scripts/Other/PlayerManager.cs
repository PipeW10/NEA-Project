using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //Variables are static to make sure they keep their current state when moving between scenes
    public static InputDevice player1Input;
    public static InputDevice player2Input;
    public static InputDevice player3Input;
    public static InputDevice player4Input;

    public static GameObject player1Character;
    public static GameObject player2Character;
    public static GameObject player3Character;
    public static GameObject player4Character;

    public static string mapToPlay;

    //First method called when the script is activated
    private void Awake()
    {
        //Makes sure the variables aren't reset
        DontDestroyOnLoad(gameObject);
    }

    //Sets the input device when a new player joins to the input device they are using
    public void SetInputDevice(InputDevice input, int playerNumber)
    {
        //Switch case to do this as it is more efficient than if statements
        //Based on the amount of players currently active
        switch (playerNumber)
        {
            case 1:
                player1Input = input;
                break;
            case 2:
                player2Input = input;
                break;
            case 3:
                player3Input = input;
                break;
            case 4:
                player4Input = input;
                break;
        }
    }

    //Sets the player's chosen character to then be instatiated
    public void SetPlayerCharacter(int playerNumber, GameObject character)
    {
        switch (playerNumber)
        {
            case 1:
                player1Character = character;
                break;
            case 2:
                player2Character = character;
                break;
            case 3:
                player3Character = character;
                break;
            case 4:
                player4Character = character;
                break;
        }
    }

    //Is used to set the mapToPlay variable to the map chosen by the player
    public void SetMap(string chosenMap)
    {
        mapToPlay = chosenMap;
    }

    //Is used to reset the mapToPlay variable once the player removes the token
    public void ResetMap(string chosenMap)
    {
        if(mapToPlay == chosenMap)
        {
            mapToPlay = null;
        }
    }
}
