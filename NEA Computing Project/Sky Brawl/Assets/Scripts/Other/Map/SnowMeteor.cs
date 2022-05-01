using UnityEngine;
using System.Collections;

public class SnowMeteor : MonoBehaviour
{
    [SerializeField] private float freezeTime;
 
    //Finds the enemy's PlayerController component and disables it the reenables it after a while
    // IEnumerator lets me wait between executing different lines
    public IEnumerator FreezePlayer(GameObject enemyHit)
    {
        //Calls The DisableComponents SubRoutine
        DisableComponents();

        //Finding the enemy's PlayerController and SpriteRenderer
        PlayerController enemyControl = enemyHit.GetComponent<PlayerController>();
        SpriteRenderer enemySprite = enemyHit.GetComponent<SpriteRenderer>();

        //If the enemy isn't already frozen
        if (enemyControl.isActiveAndEnabled)
        {
            //Changes the enemy's colour to cyan and disables their movement
            enemyControl.enabled = false;
            enemySprite.color = Color.cyan;
            //Waits for a certain amount of tie before executing next lines
            yield return new WaitForSeconds(freezeTime);
            //Changes their colour back and re-enables their movement
            enemySprite.color = Color.white;
            enemyControl.enabled = true;
        }
        //Destoys the game object
        Destroy(gameObject);
    }

    //Disables the Snow Meteor's sprite renderer and Circle Collider so it doesn't interact with the rest of the scene
    private void DisableComponents()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
