using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    private MasterControls playerControls;
    private bool canAttack;
    private float coolDownTimer;

    [Header("Player Variables")]
    [SerializeField] private float meleeRange;
    [SerializeField] private int meleeDamage;
    [SerializeField] private float knockForceX;
    [SerializeField] private float knockForceY;
    [SerializeField] private float coolDownTime;
    [SerializeField] private float knockBackTime;

    [Header("Player Links")]
    [SerializeField] private Transform meleePoint;
    [SerializeField] private LayerMask enemyLayers;

    private void Start()
    {
        //Sets the variables rigidBody and animator to the character's Rigibody2D and Animator Components in order to easily access variables
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        //Sets canAttack to true at the beginning of the game
        canAttack = true;
    }

    private void Awake()
    {
        playerControls = new MasterControls();
        playerControls.Game.Fire1.performed += ctx => MeleeAttack(); 
    }

    private void OnEnable()
    {
        playerControls.Game.Enable();
    }

    private void OnDisable()
    {
        playerControls.Game.Disable();
    }

    void Update()
    {
        //Detects whether the attack button was pressed and the calls MeleeAttack 
        //The shield has to be off
        /*if (Input.GetButtonDown("Fire1") && GetComponent<PlayerShield>().isShieldOn == false 
            && GetComponent<KnockBackEffect>().isKnockedBack == false && !Input.GetButton("Jump")
            && canAttack)
        {
            MeleeAttack();
        }*/
        if (canAttack == false)
        {
            CoolDownCounter();
        }
    }

    //Makes it so that the player can only attack again once enough time hs elapsed
    private void CoolDownCounter()
    {
        //Increses the counter by the amount of time elapsed
        coolDownTimer += Time.deltaTime;
        if (coolDownTimer >= coolDownTime)
        {
            //Enables the player's attack
            canAttack = true;
        }
    }

    //Performs the attack animation and detects what the attack collided with
    private void MeleeAttack()
    {
        if (GetComponent<PlayerShield>().isShieldOn == false
            && GetComponent<KnockBackEffect>().isKnockedBack == false && canAttack)
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
                    enemy.GetComponent<PlayerHealth>().TakeDamage(meleeDamage, gameObject, knockForceX, knockForceY, knockBackTime);
                }
            }
            //Starts a cool down timer and sets the variables used to the correct values.
            canAttack = false;
            coolDownTimer = 0;
            CoolDownCounter();
        }
    }

    //Draws a circle around the attack point to easily see and change the attack range
    //Only used when developing the game
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(meleePoint.position, meleeRange);
    }
}
