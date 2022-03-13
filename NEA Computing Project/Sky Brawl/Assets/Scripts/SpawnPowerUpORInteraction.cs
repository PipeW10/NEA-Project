using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUpORInteraction : MonoBehaviour
{
    [SerializeField] private GameObject speedPowerUp, damagePowerUp;
    private Vector3 spawnPosition;
    private float randomTime, timer;

    // Start is called before the first frame update
    void Start()
    {
        randomTime = 50;
        spawnPosition = FindObjectOfType<RespawnPoint>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= randomTime)
        {
            SpawnRandom();
        }
    }

    private void SpawnRandom()
    {
        int randomNumber = Random.Range(1, 3);
        switch (randomNumber)
        {
            case 1:
                Instantiate(speedPowerUp, spawnPosition, Quaternion.identity);
                break;
            case 2:
                Instantiate(damagePowerUp, spawnPosition, Quaternion.identity);
                break;
        }
        SetRandomTime();
    }

    private void SetRandomTime()
    {
        randomTime = Random.Range(15, 60);
        timer = 0;
    }
}
