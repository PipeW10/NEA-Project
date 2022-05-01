using UnityEngine;
public class SpawnPowerUpORInteraction : MonoBehaviour
{
    [SerializeField] private GameObject speedPowerUp, damagePowerUp, meteor, snowMeteor;
    private Vector3 spawnPosition;
    private float randomTime, timer;
    private int minRandom, maxRandom;

    // Start is called before the first frame update
    void Start()
    {
        //Sets randomtime to 50 so a power-up isn't instantly instantiated
        randomTime = 50;
        //Finds the map's respawn point and stores it in the spawnPosition variable
        spawnPosition = FindObjectOfType<RespawnPoint>().transform.position;
        //Calls the SetRandomRange method
        SetRandomRange();
        //Calls the SetRandomTime method
        SetRandomTime();
    }

    //Sets the range of the random number used to choose what powerup or interaction to spawn
    //Based off what settings the players chose to play with
    private void SetRandomRange()
    {
        //Finds the values stored in the player manager which tells the script
        // what options the player picked in the settings menu
        bool useInteractions = PlayerManager.useInteractions;
        bool usePowerUps = PlayerManager.usePowerUps;
        //If the player wants both interactions and powerups
        if (usePowerUps && useInteractions)
        {
            //Use the full range of values
            minRandom = 1;
            maxRandom = 5;
        }
        //If the player just wants to use powerups
        else if(usePowerUps && !useInteractions)
        {
            //Just use values that will spawn powerups
            minRandom = 1;
            maxRandom = 3;
        }
        //If the player just wants to use interactions
        else if (!usePowerUps && useInteractions)
        {
            //Just use values that will spawn interactions
            minRandom = 3;
            maxRandom = 5;
        }
        //If the doesn't want powerups nor interactions
        else
        {
            //Destroy this gameObject as it is not needed
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    //Will be used to have timer 
    void Update()
    {
        //Adds the amount of time elapsed to the timer
        timer += Time.deltaTime;
        //If enough time has elapsed
        if(timer >= randomTime)
        {
            //Spawns a random power-up or interaction
            SpawnRandom();
        }
    }

    //Spawns a random power-up or interaction
    private void SpawnRandom()
    {
        //Selects a random number for the switch case
        int randomNumber = Random.Range(minRandom, maxRandom);
        //Switch case based on randomNumber
        switch (randomNumber)
        {
            case 1:
                //Instantiates a speedPowerup
                Instantiate(speedPowerUp, spawnPosition, Quaternion.identity);
                break;
            case 2:
                //Instantiates a damagePowerup
                Instantiate(damagePowerUp, spawnPosition, Quaternion.identity);
                break;
            case 3:
                //Instantiates a meteor
                Instantiate(meteor,new Vector3 (Random.Range(-9, 10), spawnPosition.y + 8, -1f), Quaternion.identity);
                break;
            case 4:
                //Instantiates a snow meteor
                Instantiate(snowMeteor, new Vector3 (Random.Range(-9, 10), spawnPosition.y + 8, -1f), Quaternion.identity);
                break;
        }
        //Sets a new random time
        SetRandomTime();
    }

    //Sets a random time and restarts the timer
    private void SetRandomTime()
    {
        //Random amount of time chosen between 10 and 2w0 seconds
        randomTime = Random.Range(10, 20);
        //The timer is reset to 0
        timer = 0;
    }
}
