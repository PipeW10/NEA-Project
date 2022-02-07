using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyButton : MonoBehaviour
{
    //Used to load either the character selection screen or the map to be played on
    public void LoadMap()
    {
        //If the current scene is the map menu
        if(SceneManager.GetActiveScene().name == "Map Menu")
        {
            //Loads the character selection screen
            SceneManager.LoadScene("Player Selection");
        }
        else
        {
            //Loads the map to be played on by finding the mapToPlay variable on the player manager script
            SceneManager.LoadScene(PlayerManager.mapToPlay);
        }
        
    }
}
