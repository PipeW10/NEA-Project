using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyButton : MonoBehaviour
{
    private MusicControlScript musicController;
    private PlayerManager playerManager;

    private void Start()
    {
        //Finds a music controller script in the scene
        musicController = FindObjectOfType<MusicControlScript>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    //Used to load either the character selection screen or the map to be played on
    public void LoadMap()
    {
        //If the current scene is the map menu
        if(SceneManager.GetActiveScene().name == "Map Menu")
        {
            //Loads the character selection screen
            SceneManager.LoadScene("Player Selection");
        }
        //If the current scene is the start menu
        else if (SceneManager.GetActiveScene().name == "Start Menu")
        {
            //Loads the Map Menu scene
            SceneManager.LoadScene("Map Menu");
        }
        //If the current scene is the Win Screen
        else if(SceneManager.GetActiveScene().name == "Win Screen")
        {
            //Go back to the start menu and change the music
            //Calls the ClearSelections method from the PlayerManager
            playerManager.ClearSelections();
            SceneManager.LoadScene("Start Menu");
            musicController.SetAudio();
        }
        else
        {
            //Loads the map to be played on by finding the mapToPlay variable on the player manager script
            SceneManager.LoadScene(PlayerManager.mapToPlay);
            musicController.SetAudio();
        }

    }
}
