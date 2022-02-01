using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static InputDevice player1Input;
    public static InputDevice player2Input;
    public static InputDevice player3Input;
    public static InputDevice player4Input;

    [SerializeField] public static GameObject[] playerCharacters;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetInputDevice(InputDevice input, int playerNumber)
    {
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

    public void SetPlayerCharacter(int playerNumber, GameObject character)
    {
        playerCharacters[playerNumber - 1] = character;
    }
}
