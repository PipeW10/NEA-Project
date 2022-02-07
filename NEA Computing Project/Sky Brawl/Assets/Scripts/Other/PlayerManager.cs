using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //Variables are static to make sure they keep their current state when moving between scenes
    public static InputDevice player1Input;
    public static InputDevice player2Input;
    public static InputDevice player3Input;
    public static InputDevice player4Input;
    public static string mapToPlay;

    [SerializeField] public static GameObject[] playerCharacters;

    //First method called when the script is activated
    private void Awake()
    {
        //Makes sure the variables aren't reset
        DontDestroyOnLoad(gameObject);
        //Creates a new playerCharacters array if the array is empty
        if(playerCharacters[0] == null)
        {
            playerCharacters = new GameObject[4];
        }
    }

    //Sets the input device when a new player joins to the input device they are using
    public void SetInputDevice(InputDevice input, int playerNumber)
    {
        //Switch case to do this as it is more efficient than if statements
        //Based on the amount of players currently active
        switch (playerNumber)
        {
            case 0:
                player1Input = input;
                break;
            case 1:
                player2Input = input;
                break;
            case 2:
                player3Input = input;
                break;
            case 3:
                player4Input = input;
                break;
        }
    }

    //Sets the player's chosen character to then be instatiated
    public void SetPlayerCharacter(int playerNumber, GameObject character)
    {
        playerCharacters[playerNumber - 1] = character;
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
