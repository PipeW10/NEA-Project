using System.Collections;
using UnityEngine;

public class StickyArrow : MonoBehaviour
{
    [Header("Sticky Arrow Varibles")]
    [SerializeField] private float stickTime;

    //Finds the enemy's PlayerController component and disables it the reenables it after a while
    // IEnumerator lets me wait between executing different lines
    public IEnumerator StickPlayer(GameObject enemyHit)
    {
        //Calls The DisableComponents SubRoutine
        DisableComponents();

        //Finding the enemy's PlayerController and SpriteRenderer
        PlayerController enemyControl = enemyHit.GetComponent<PlayerController>();
        SpriteRenderer enemySprite = enemyHit.GetComponent<SpriteRenderer>();

        //If the enemy isn't already stuck
        if (enemyControl.isActiveAndEnabled)
        {
            //Changes the enemy's colour to cyan and disables their movment
            enemyControl.enabled = false;
            enemySprite.color = Color.green;
            //Waits for a certain amount of tie before executing next lines
            yield return new WaitForSeconds(4);
            //Changes their colour back and re-enables their movement
            enemySprite.color = Color.white;
            enemyControl.enabled = true;
        }
        //Destoys the game object
        Destroy(gameObject);
    }

    //Disables the Sticky Arrrow's sprite renderer and Box Collider so it doesn't interact with the rest of the scene
    private void DisableComponents()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
