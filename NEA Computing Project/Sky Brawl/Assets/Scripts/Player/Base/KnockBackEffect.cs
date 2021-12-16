using System.Collections;
using UnityEngine;

public class KnockBackEffect : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private PlayerHealth health;
    private float noMoveTimer;
    [HideInInspector] public bool isKnockedBack;
    private float noMovementTime;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the variable rigidBody character's Rigibody2D in order to easily access the variable
        rigidBody = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (isKnockedBack == true)
        {
            PauseMovement();
        }
    }

    //Controls the knock back effect for the game object
    //Normally called from a script attached to another game object
    public void KnockBackCharacter (GameObject attacker, float knockForceX, float knockForceY, float pausedTime)
    {
        //Sets the direction x and y variables to the direction we want the force to be applied
        Vector3 directionX = new Vector3(transform.position.x - attacker.transform.position.x, 0, 0);
        Vector3 directionY = new Vector3(0, 1, 0);
        //Adds forces in the x and y directions
        rigidBody.AddForce(directionX * knockForceX * (1 + GetComponent<PlayerHealth >().playerCurrentHealth/100));
        rigidBody.AddForce(directionY * knockForceY * (1 + GetComponent<PlayerHealth>().playerCurrentHealth/100));
        //Sets the noMovement time to the correct value
        if ((health.playerCurrentHealth / 20) > 1)
        {
            noMovementTime = pausedTime * (health.playerCurrentHealth / 20);
        }
        else
        {
            noMovementTime = pausedTime;
        }
        //Resets the timer
        noMoveTimer = 0;
        //Calls the PauseMovement subroutine
        PauseMovement();
    }

    // IEnumerator lets me wait between executing different lines
    private void PauseMovement()
    {
        //Disables the player's movement so they can't counter the knockback effect
        isKnockedBack = true;
        gameObject.GetComponent<PlayerController>().enabled = false;
        noMoveTimer += Time.deltaTime;
        //Enables the players movement if they are falling and enough time has elapsed
        if (rigidBody.velocity.y < 0 && noMoveTimer >= noMovementTime)
        {
            isKnockedBack = false;
            //Enables the player's movement
            gameObject.GetComponent<PlayerController>().enabled = true;
        }
    }
}
