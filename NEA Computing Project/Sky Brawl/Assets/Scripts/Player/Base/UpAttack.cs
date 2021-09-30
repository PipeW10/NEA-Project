using UnityEngine;

public class UpAttack : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private PlayerController controller;
    private bool hasJumpAttacked;

    [Header("Player Variables")]
    [SerializeField] private float jumpAttackForce;

    [Header("Player Links")]
    [SerializeField] private GameObject upAttackCircle;
    
    // Start is called before the first frame update
    void Start()
    {
        //Sets the variables rigidBody and animator to the character's Rigibody2D and controller Components in order to easily access variables
        rigidBody = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
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
            upAttackCircle.SetActive(false);
        }
    }

    //Performs the jump attack
    private void JumpAttack()
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
