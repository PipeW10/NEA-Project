using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] ReadyButton readyButton;
    private string mapToPlay;

    //Is used to set the mapToPlay variable to the map chosen by the player
    public void SetMap(string chosenMap)
    {
        mapToPlay = chosenMap;
        //Enables the ready Button
        readyButton.gameObject.SetActive(true);
    }

    //Is used to reset the mapToPlay variable once the player removes the token
    public void ResetMap(string chosenMap)
    {
        //Only resets the the mapToPLay variable if it is equal to the chosenMap to avoid issues
        // with the token overlapping two map buttons
        if (mapToPlay == chosenMap)
        {
            mapToPlay = null;
            //Disbales the ready button
            readyButton.gameObject.SetActive(false);
        }
    }
}
