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

    public void SetSettings(bool isPowerUpButton, bool isEnter)
    {
        if (isEnter)
        {
            if (isPowerUpButton)
            {
                usePowerUps = true;
            }
            else
            {
                useInteractions = true;
            }
        }
        else
        {
            if (isPowerUpButton)
            {
                usePowerUps = false;
            }
            else
            {
                useInteractions = false;
            }
        }

        playerManager.SettingsChoices(usePowerUps, useInteractions);
    }

}
