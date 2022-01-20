using UnityEngine;

public class Button : MonoBehaviour
{
    [Header("Button Variables")]
    [SerializeField] private GameObject character;
    [SerializeField] private CharacterSelection selection;
    private int playerNumber;

    //Called when a gamobject with a collider enter the box collider on the button
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Sets the token which caused the trigger to the token variable
        Token token = collision.GetComponent<Token>();
        //Checks whether the token is actually a token and no token is already in the collider
        if (token != null && playerNumber == 0)
        {
            //Sets the player number to the tokenNumber on the token
            playerNumber = token.tokenNumber;
            //Calls the setPlayerCharacter method in the CharacterSelection script
            selection.SetPlayerCharacter(playerNumber, character);
        }
    }

    //Called when a gamobject with a collider exits the box collider on the button
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Sets the token which caused the trigger to the token variable
        Token token = collision.GetComponent<Token>();
        //Checks whether the token is actually a token
        if (token != null)
        {
            //Checks if the tokenNumber is the same as the player number to make sure it isn't a different player
            if(token.tokenNumber == playerNumber)
            {
                //Calls the RemovePlayerCharacter method in the CharacterSelection script
                selection.RemovePlayerCharacter(playerNumber);
                //Resets the playerNumber to 0
                playerNumber = 0;
            }
        }
    }
}
