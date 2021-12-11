using System.Collections;
using UnityEngine;

public class KnockBackEffect : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private PlayerHealth health;
    private float noMoveTimer;
    [HideInInspector] public bool isKnockedBack;

    [Header("Knockback Varibles")]
    [SerializeField] private float noMovementTime;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the variable rigidBody character's Rigibody2D in order to easily access the variable
        rigidBody = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();
    }

    //Controls the knock back effect for the game object
    //Normally called from a script attached to another game object
    public void KnockBackCharacter (GameObject attacker, float knockForceX, float knockForceY)
    {
        //Sets the direction x and y variables to the direction we want the force to be applied
        Vector3 directionX = new Vector3(transform.position.x - attacker.transform.position.x, 0, 0);
        Vector3 directionY = new Vector3(0, 1, 0);
        //Adds forces in the x and y directions
        rigidBody.AddForce(directionX * knockForceX * (1 + GetComponent<PlayerHealth >().playerCurrentHealth/100));
        rigidBody.AddForce(directionY * knockForceY * (1 + GetComponent<PlayerHealth>().playerCurrentHealth/100));
        //Calls the PauseMovement subroutine
        PauseMovement();
    }

    // IEnumerator lets me wait between executing different lines
    private void PauseMovement()
    {
        bool canMove = false;

        //Disables the player's movement so they can't counter the knockback effect
        isKnockedBack = true;
        gameObject.GetComponent<PlayerController>().enabled = false;
        while (canMove == false ){
            noMoveTimer += Time.deltaTime;
            //Exits the loop either when the player is moving downwards or when enough time has elapsed
            if (rigidBody.velocity.y < 0 && noMoveTimer >= (noMovementTime * health.playerCurrentHealth)){
                canMove = true;
            }
        }
        isKnockedBack = false;
        //Enables the player's movement
        gameObject.GetComponent<PlayerController>().enabled = true;
    }
}
