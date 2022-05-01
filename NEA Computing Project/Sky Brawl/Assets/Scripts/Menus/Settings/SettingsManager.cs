using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private bool usePowerUps;
    private bool useInteractions;
    private PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    //Used to set the usePowerups and useInteractions variables depeniding on what the
    // player picks in the settings menu
    public void SetSettings(bool isPowerUpButton, bool isEnter)
    {
        //isEnter is a parameter which tells the method if a token was placed or removed from a button
        //If a token was placed onto a button
        if (isEnter)
        {
            //If that button was the powerUp button
            if (isPowerUpButton)
            {
                //Set usePowerUps to true
                usePowerUps = true;
            }
            //If that button was the interaction button
            else
            {
                useInteractions = true;
            }
        }
        //If a token was removed from a button
        else
        {
            //If that button was the powerUp button
            if (isPowerUpButton)
            {
                //Set usePowerUps to true
                usePowerUps = false;
            }
            //If that button was the interaction button
            else
            {
                //Set useInteractions to true
                useInteractions = false;
            }
        }
        //Store the new values in the playerManager
        playerManager.SettingsChoices(usePowerUps, useInteractions);
    }

}
