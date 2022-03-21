using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void LoadPreviousScene()
    {
        if (SceneManager.GetActiveScene().name == "Settings")
        {
            SceneManager.LoadScene("Start Menu");
        }
        else if (SceneManager.GetActiveScene().name == "Map Menu")
        {
            FindObjectOfType<PlayerManager>().ClearSelections();
            SceneManager.LoadScene("Settings");
        }
        else if (SceneManager.GetActiveScene().name == "Player Selection")
        {
            bool usePowerUps = PlayerManager.usePowerUps;
            bool useInteractions = PlayerManager.useInteractions;
            SceneManager.LoadScene("Map Menu");
            FindObjectOfType<PlayerManager>().SettingsChoices(usePowerUps, useInteractions);
        }
        else if (SceneManager.GetActiveScene().name == "Start Menu")
        {
            Debug.Log("M");
            Application.Quit();
        }
    }
}
