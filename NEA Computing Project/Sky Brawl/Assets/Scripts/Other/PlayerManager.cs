using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

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
    public static int numberOfPlayers;
    public static int playersAlive;
    public static int playersJoinedGame;
    public static GameObject winner;


    public static PlayerManager playerManager;

    //First method called when the script is activated
    private void Awake()
    {
        //Makes sure the variables aren't reset
        DontDestroyOnLoad(gameObject);
        //Checks to see whether there is another player manager in the scene and if so, destroys the gameObject
        if(playerManager == null)
        {
            playerManager = this;
            playersJoinedGame = 0;
        }
        else
        {
            Destroy(gameObject);
        }
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
        numberOfPlayers = playerNumber;
        playersAlive = numberOfPlayers;
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

    //Called from PlayerHealth whenever a player dies
    public void PlayerDied()
    {
        //Minus 1 from playersAlive
        playersAlive -= 1;
        //If only 1 player is left alive
        if(playersAlive == 1)
        {
            //Set winner to the characterSprite object on the player left alive
            winner = FindObjectOfType<Player>().characterSprite;
            //Load the winscreen
            SceneManager.LoadScene("Win Screen");
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

    //Method used to clear all variables so a new game can be started
    public void ClearSelections()
    {
        player1Character = null;
        player2Character = null;
        player3Character = null;
        player4Character = null;

        player1Input = null;
        player2Input = null;
        player3Input = null;
        player4Input = null;

        playersAlive = 0;
        numberOfPlayers = 0;
        playersJoinedGame = 0;
        mapToPlay = null;
    }

    public void WaitForPlayers(bool playerJoined)
    {
        if (playerJoined)
        {
            playersJoinedGame++;
            if (playersJoinedGame == numberOfPlayers)
            {
                Time.timeScale = 1f;
            }
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}
