using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool isDead;
    private Animator animator;
    private Rigidbody2D rigidBody;
    private HealthText healthText;
    private SpriteRenderer spriteRenderer;
    private PlayerShield shield;
    [SerializeField] private Player playerComponent;
    [HideInInspector] public float playerCurrentHealth = 0; 

    [Header("Player Variables")]
    [SerializeField] private float healthDamping;
    [SerializeField] private int playerLives;
    [SerializeField] private float respawnTime;
    [SerializeField] private float gravityStrength;
    [SerializeField] private Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        //Sets the variables rigidBody, healthText and animator to the character's Rigibody2D, HealthText, SpriteRenderer and Animator Components in order to easily access variables
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        healthText = GetComponent<HealthText>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        shield = GetComponent<PlayerShield>();
        playerComponent = GetComponent<Player>();
        respawnPoint = FindObjectOfType<RespawnPoint>().transform;
        //Calls setHealthText so it updates at the start
        SetHealthText();
    }

    //Calls the set update text and lives subrountines in the HealthText script
    private void SetHealthText()
    {
        healthText.UpdateHealth(playerCurrentHealth);
        healthText.UpdateLives(playerLives);
    }

    //Takes care of reducing player health when attacker
    public void TakeDamage (int damageDealt, GameObject attacker, float knockForceX, float knockForceY, float knocBackTime)
    {
        //Only take damage is the player's shield is off, they didn't attack themsleves and they are not dead
        if (shield.isShieldOn == false && gameObject != attacker && isDead == false)
        {
            if (attacker.GetComponent<PlayerPowerUps>().isDamageBuffed)
            {
                damageDealt = Mathf.RoundToInt(damageDealt * attacker.GetComponent<PlayerPowerUps>().damageBuff);
            }
            //Increases the player's "percentage" with their damping effect
            playerCurrentHealth += damageDealt * healthDamping;
            //Rounds their health and calls the update health script
            Mathf.Round(playerCurrentHealth);
            healthText.UpdateHealth(playerCurrentHealth);

            //If a knock force effect should be applied
            if (knockForceX !=0  && knockForceY != 0)
            {
                //Performs a knockback effect on the player
                GetComponent<KnockBackEffect>().KnockBackCharacter(attacker, knockForceX, knockForceY, knocBackTime);
            }
            //Plays the hurt animation
            animator.SetTrigger("Hurt");
        }
        else if (shield.isShieldOn && gameObject != attacker && isDead == false)
        {
            shield.TakeShieldDamage(damageDealt);
        }
    }

    //Performs the die animation, disbles any scripts linked to the gameobject and then destroys the object
    // IEnumerator lets me wait between executing different lines
    public IEnumerator Die()
    {
        //Takes one life away
        playerLives -= 1;
        //Resets health
        playerCurrentHealth = 0;
        //Updates the players health and life text
        healthText.UpdateHealth(0);
        healthText.UpdateLives(playerLives);
        //Removes the gameObject from the camera target group
        playerComponent.RemoveFromTargetGroup();
        //Sets isDead to true
        isDead = true;
        //Finds all the scripts linked to the game object
        MonoBehaviour[] components = GetComponents<MonoBehaviour>();
        //Disables all scripts linked to the game object in order to make sure the character can no longer move when dead
        foreach(MonoBehaviour comp in components)
        {
            comp.enabled = false;
        }
        //Disables the player's collider
        GetComponent<BoxCollider2D>().enabled = false;
        //Sets the players velocity at 0 and disables their gravity to stop them falling
        rigidBody.gravityScale = 0;
        rigidBody.velocity = new Vector2(0, 0);
        //Disables the player's sprite renderer
        spriteRenderer.enabled = false; 

        //If the player still has lives left
        if (playerLives > 0)
        {
            //waits for a set amount of time before executing the next line
            yield return new WaitForSeconds(respawnTime);
            //Sets isDead to false
            isDead = false;
            //Enables all scripts linked to the game object in order to make sure the character can no longer move when dead
            foreach (MonoBehaviour comp in components)
            {
                comp.enabled = true;
            }
            //Sets their gravity back to normal
            rigidBody.gravityScale = gravityStrength;
            //Re-activates their box collider
            GetComponent<BoxCollider2D>().enabled = true;
            //Enables sprite renderer
            spriteRenderer.enabled = true;
            //Respawns the player at the respawn point
            transform.position = respawnPoint.position;
            //Adds the gameObject back onto the camera target group
            playerComponent.AddToTargetGroup();
        }
        //If the player has no lives they are destroyed
        else
        {
            gameObject.SetActive(false);
            FindObjectOfType<PlayerManager>().PlayerDied();
            Destroy(gameObject);
        }
    }
}
