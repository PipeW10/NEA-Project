using System.Collections;
using UnityEngine;

public class KnockBackEffect : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [HideInInspector] public bool isKnockedBack;

    [Header("Knockback Varibles")]
    [SerializeField] private float noMovementTime;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the variable rigidBody character's Rigibody2D in order to easily access the variable
        rigidBody = GetComponent<Rigidbody2D>();
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
        StartCoroutine(PauseMovement());
    }

    // IEnumerator lets me wait between executing different lines
    private IEnumerator PauseMovement()
    {
        //Disables the player's movement so they can't counter the knockback effect
        isKnockedBack = true;
        gameObject.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(noMovementTime);
        isKnockedBack = false;
        gameObject.GetComponent<PlayerController>().enabled = true;
    }
}
