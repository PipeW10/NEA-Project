using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;

    [Header("Player Variables")]
    [SerializeField] private float meleeRange;
    [SerializeField] private int meleeDamage;
    [SerializeField] private float knockForceX;
    [SerializeField] private float knockForceY;

    [Header("Player Links")]
    [SerializeField] private Transform meleePoint;
    [SerializeField] private LayerMask enemyLayers;

    private void Start()
    {
        //Sets the variables rigidBody and animator to the character's Rigibody2D and Animator Components in order to easily access variables
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Detects whether the attack button was pressed and the calls MeleeAttack 
        //The shield has to be off
        if (Input.GetButtonDown("Fire1") && GetComponent<PlayerShield>().isShieldOn == false 
            && GetComponent<KnockBackEffect>().isKnockedBack == false && !Input.GetButton("Jump"))
        {
            MeleeAttack();
        }
    }

    //Performs the attack animation and detects what the attack collided with
    private void MeleeAttack()
    {
        //Triggers the attack animation
        animator.SetTrigger("Attack");

        //Sets the player's Y velocity to 0 if they are falling so air attacks feel better
        if(rigidBody.velocity.y < 0)
        {
            rigidBody.velocity = new Vector2 (rigidBody.velocity.x , 0);
        }

        //Detects any enemies inside the attack range
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(meleePoint.position, meleeRange, enemyLayers);

        //Calls the TakeDamage sub-routine in each of the attacked players' PlayerHealth Script
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy != gameObject)
            {
                enemy.GetComponent<PlayerHealth>().TakeDamage(meleeDamage, gameObject, knockForceX, knockForceY);
            }
        }
    }

    //Draws a circle around the attack point to easily see and change the attack range
    //Only used when developing the game
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(meleePoint.position, meleeRange);
    }
}
