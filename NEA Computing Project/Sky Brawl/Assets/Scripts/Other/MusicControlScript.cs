using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControlScript : MonoBehaviour
{
    [SerializeField] private AudioClip gameAudio1;
    [SerializeField] private AudioClip gameAudio2;
    [SerializeField] private AudioClip menuAudio;
    private AudioSource audioSource;
    public static MusicControlScript musicScript;

    //First method called when the script is activated
    private void Awake()
    {
        //Makes it so this gameobject isn't destroyed when changing scene
        DontDestroyOnLoad(gameObject);
        //These if statements are used to make sure there is only one music script active
        //Makes sure only 1 audio source is currently playing
        //If there is no musicScript currently active
        if(musicScript == null)
        {
            //musicScript is equal to this script
            musicScript = this;
        }
        //If there is a music script currently active
        else
        {
            //Destroy this gameobject
            Destroy(gameObject);
        }

        //Finds the AudioSource component attached to the gameobject for furture reference
        audioSource = GetComponent<AudioSource>();
        //Calls the SetAudio Method
        SetAudio();
    }

    //Plays the correct music track 
    //Called from the player manager or when the script is first active
    public void SetAudio()
    {
        //If the currently active scene is the player selection menu
        if (SceneManager.GetActiveScene().name == "Player Selection")
        {
            //Chooses a random value between 0 and 1
            var randomValue = Random.Range(0, 2);
            //If the value is 0
            if (randomValue == 0)
            {
                //Sets the audio clip to gameAudio1
                audioSource.clip = gameAudio1;
            }
            //else
            else
            {
                //Sets the audio clip to gameAudio2
                audioSource.clip = gameAudio2;
            }
            //Plays the audio
            audioSource.Play();
        }
        //If any other scene is currently active
        else if (audioSource.clip != menuAudio)
        {
            //Sets the audio clip to menu audio
            audioSource.clip = menuAudio;
            //Plays the audio
            audioSource.Play();
        }
        
    }
}
