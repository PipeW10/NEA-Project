using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void LoadPreviousScene()
    {
        if (SceneManager.GetActiveScene().name == "Map Menu")
        {
            SceneManager.LoadScene("Start Menu");
        }
        else if (SceneManager.GetActiveScene().name == "Player Selection")
        {
            FindObjectOfType<PlayerManager>().ClearSelections();
            SceneManager.LoadScene("Map Menu");
        }
        else if (SceneManager.GetActiveScene().name == "Start Menu")
        {
            Debug.Log("M");
            Application.Quit();
        }
    }
}
