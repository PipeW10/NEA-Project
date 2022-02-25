using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControlScript : MonoBehaviour
{
    [SerializeField] private AudioClip gameAudio1;
    [SerializeField] private AudioClip gameAudio2;
    [SerializeField] private AudioClip menuAudio;
    private AudioSource audioSource;
    public static MusicControlScript musicScript;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(musicScript == null)
        {
            musicScript = this;
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        SetAudio();
    }

    public void SetAudio()
    {
        if (SceneManager.GetActiveScene().name == "Player Selection")
        {
            var randomValue = Random.Range(0, 2);
            if (randomValue == 0)
            {
                audioSource.clip = gameAudio1;
            }
            else
            {
                audioSource.clip = gameAudio2;
            }
            audioSource.Play();
        }
        else if (audioSource.clip != menuAudio)
        {
            audioSource.clip = menuAudio;
            audioSource.Play();
        }
        
    }
}
