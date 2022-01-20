using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelection : MonoBehaviour
{
    private InputDevice player1Input;
    private InputDevice player2Input;
    private InputDevice player3Input;
    private InputDevice player4Input;

    private GameObject player1Character;
    private GameObject player2Character;
    private GameObject player3Character;
    private GameObject player4Character;

    [SerializeField] private int numberPlayers;

    [Header("Buttons")]
    [SerializeField] Button archerButton;

    //First Method to be called in the script
    private void Awake()
    {
        //Sets the number of players to 0
        numberPlayers = 0;
    }

    //Called from the button script and links the character chosen to the specified player
    public void SetPlayerCharacter(int playerNumber, GameObject character)
    {
        //Switch Case branch with the playerNumber passed as the switch
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
            default:
                Debug.Log("Fail character");
                break;
        }
    }

    //Called from the button script and un-links the character chosen to the specified player
    public void RemovePlayerCharacter(int playerNumber)
    {
        //Switch Case branch with the playerNumber passed as the switch
        switch (playerNumber)
        {
            case 1:
                player1Character = null;
                break;
            case 2:
                player2Character = null;
                break;
            case 3:
                player3Character = null;
                break;
            case 4:
                player4Character = null;
                break;
            default:
                Debug.Log("Fail character");
                break;
        }
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
        //Adds 1 to the number of players
        numberPlayers += 1;
    }
}
