using UnityEngine;

public class UpAttack : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private PlayerController controller;
    private MasterControls playerControls;
    private bool hasJumpAttacked;
    private bool canAttack;
    private float coolDownTimer;

    [Header("Player Variables")]
    [SerializeField] private float jumpAttackForce;
    [SerializeField] private float coolDownTime;

    [Header("Player Links")]
    [SerializeField] private GameObject upAttackCircle;

    private void Awake()
    {
        playerControls = new MasterControls();
        playerControls.Game.UpAttack.started += ctx => JumpAttack();
    }

    private void OnEnable()
    {
        playerControls.Game.Enable();
    }

    private void OnDisable()
    {
        playerControls.Game.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Sets the variables rigidBody and animator to the character's Rigibody2D and controller Components in order to easily access variables
        rigidBody = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack == false)
        {
            CoolDownCounter();
        }

        //Checks whether the player is performing an up attack and falling to change their color back to white
        if (hasJumpAttacked && rigidBody.velocity.y < 0)
        {
            upAttackCircle.SetActive(false);
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

    //Performs the jump attack
    private void JumpAttack()
    {
        if (canAttack && !hasJumpAttacked)
        {
            //Sets hasJumpAttacked to true
            hasJumpAttacked = true;
            if (controller.jumpCount >= 2)
            {
                //Performs a jump
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
                rigidBody.AddForce(new Vector2(0, jumpAttackForce), ForceMode2D.Impulse);
            }
            upAttackCircle.SetActive(true);
            //Starts a cool down timer and sets the variables used to the correct values.
            canAttack = false;
            coolDownTimer = 0;
            CoolDownCounter();
        }
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
}
