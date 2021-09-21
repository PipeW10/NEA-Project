using UnityEngine;

public class UpAttack : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private PlayerController controller;
    private SpriteRenderer spriteRenderer;
    private bool hasJumpAttacked;

    [Header("Player Variables")]
    [SerializeField] private float jumpAttackForce;
    [SerializeField] private float attackRange;
    [SerializeField] private float knockForceX, knockForceY;
    [SerializeField] private int upAttackDamage;
    [SerializeField] private LayerMask enemyLayers;

    [Header("Player Links")]
    [SerializeField] private Transform upAttackPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        //Sets the variables rigidBody and animator to the character's Rigibody2D and Animator Components in order to easily access variables
        rigidBody = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the jump button and the fire1 button were pressed to perform an up attack
        if (Input.GetButtonDown ("Fire1") && Input.GetButton ("Jump") && !hasJumpAttacked)
        {
            JumpAttack();
        }

        //Checks whether the player is performing an up attack and falling to change their color back to white
        if(hasJumpAttacked && rigidBody.velocity.y < 0)
        {
            spriteRenderer.color = Color.white;
        }

        //Checks whether the player is performing an up attack and are rising to check whether to deal damage
        if (hasJumpAttacked && rigidBody.velocity.y > 0)
        {
            CheckAndAttack();
        }
    }

    //Performs the jump attack
    private void JumpAttack()
    {
        //Sets hasJumpAttacked to true
        hasJumpAttacked = true;
        //Performs a jump
        rigidBody.AddForce(new Vector2(0, jumpAttackForce), ForceMode2D.Impulse);
        //Changes the player's colour to red
        spriteRenderer.color = Color.red;
    }

    //Detects if an object collides with the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks to see of the player is on the ground or on a wall
        if (controller.isGrounded || controller.isTouchingWall)
        {
            //Changes hasJumpedAttacked to false
            hasJumpAttacked = false;
        }
    }

    //Checks for an attack
    private void CheckAndAttack()
    {
        //Draws a circle over a certain point and finds all the objects inside a certain radius
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(upAttackPoint.position, attackRange, enemyLayers);

        //Calls the TakeDamage sub-routine in each of the attacked players' PlayerHealth Script
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy != gameObject)
            {
                enemy.GetComponent<PlayerHealth>().TakeDamage(upAttackDamage, gameObject, knockForceX, knockForceY);
            }
        }
    }
}
