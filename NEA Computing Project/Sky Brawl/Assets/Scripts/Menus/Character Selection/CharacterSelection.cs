using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelection : MonoBehaviour
{
    private InputDevice player1Input;
    private InputDevice player2Input;
    private InputDevice player3Input;
    private InputDevice player4Input;

    [SerializeField] private GameObject[] playerCharacters;
    [SerializeField] private SelectionBox[] selectBoxes;
    [SerializeField] private Token[] tokens;
    [SerializeField] private ReadyButton readyButton;
    
    [HideInInspector] public int numberPlayers;
    [SerializeField] private PlayerManager playerManager;


    //First Method to be called in the script
    private void Awake()
    {
        //Sets the number of players to 0
        numberPlayers = 0;
    }

    //Checks whether all players are ready
    private void PlayersReady()
    {
        //allReady used as a flag
        bool allReady = true;
        //Loops through all players checking whether they have selected a character
        for(int i = 0; i < numberPlayers; i++)
        {
            if(playerCharacters [i] == null)
            {
                //Sets allReady to false if they haven't
                allReady = false;
            }
        }

        //If all players are ready the ready button is displayed
        if (allReady && numberPlayers > 1)
        {
            readyButton.gameObject.SetActive(true);
        }
        else if (readyButton.gameObject.activeSelf)
        {
            readyButton.gameObject.SetActive(false);
        }
    }

    //Called from the button script and links the character chosen to the specified player
    public void SetPlayerCharacter(int playerNumber, GameObject character, GameObject choiceFace)
    {
        //Only does this if the player is active 
        if(playerNumber <= numberPlayers)
        {
            //Sets the playerCharcters array position linked to the player to the chosen character
            playerCharacters[playerNumber - 1] = character;
            //Calls the playersReady method
            PlayersReady();
            //Calls a method in the selectBoxes script linked to the player to display the character's face
            selectBoxes[playerNumber - 1].DisplayChoice(choiceFace);
            //Sets the character in the player manager script
            playerManager.SetPlayerCharacter(playerNumber, character);
        }
    }

    //Called from the button script and un-links the character chosen to the specified player
    public void RemovePlayerCharacter(int playerNumber)
    {
        //Sets the playerCharcters array position linked to the player to null
        playerCharacters[playerNumber - 1] = null;
        //Calls the playersReady method
        PlayersReady();
        //Calls a method in the selectBoxes script linked to the player to stop displaying the character's face
        selectBoxes[playerNumber - 1].RemoveChoice();
        //Removes the character in the player manager script
        playerManager.SetPlayerCharacter(playerNumber, null);
    }

    //Called from the PlayerJoining script and links an input device to the next available player
    public void AddPlayerDevice(InputDevice input)
    {
        //Switch Case branch with the current number of players passed as the switch
        switch (numberPlayers)
        {
            case 0:
                player1Input = input;
                Debug.Log("1 joined");
                break;
            case 1:
                player2Input = input;
                Debug.Log("2 joined");
                break;
            case 2:
                player3Input = input;
                Debug.Log("3 joined");
                break;
            case 3:
                player4Input = input;
                Debug.Log("4 joined");
                break;
            default:
                Debug.Log("Fail");
                numberPlayers -= 1;
                break;
        }
        //Activates the Selection box linked to the new player
        selectBoxes[numberPlayers].gameObject.SetActive(true);
        //Activates the token linked to the new player
        tokens[numberPlayers].gameObject.SetActive(true);
        //Adds 1 to the number of players
        numberPlayers += 1;
        //Sets the input device in the player Manager script
        playerManager.SetInputDevice(input, numberPlayers);
        //Calls the playersReady method
        PlayersReady();
    }
}
