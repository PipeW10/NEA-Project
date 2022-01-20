using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MasterControls playerControls;
    private Rigidbody2D rigidBody;
    private Animator animator;
    //varibles needed throughout the script. Privated as none need to be accessed elsewhere
    private float xMovement;
    [HideInInspector] public int jumpCount = 0;
    [HideInInspector] public bool isWallSliding, isTouchingWall, isGrounded;
   
    [Header("Player Varibles")]
    [SerializeField] private int YRotation;
    // Serializing fields allows me to change the varible's value from the inspector table whilst playing
    [SerializeField] private float movementSpeed, jumpForce, doubleJumpForce, xWallJumpForce, yWallJumpForce, checkRadius, wallSlidingSpeed;

    [Header("Player Links")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallJumpLayer;
    [SerializeField] private Transform wallCheck, groundCheck;


    // Start is called before the first frame update
    void Start()
    {
        //Sets the variables rigidBody and animator to the character's Rigibody2D and Animator Components in order to easily access variables
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    //First Method to be called in the script
    private void Awake()
    {
        //Sets the playercontrols variable to a reference for the master controls script
        playerControls = new MasterControls();
        //Links Inputs from the Game ipnut action map to specified sub-routines so action may be performed
        playerControls.Game.Jump.performed += ctx => PlayerJump();
        playerControls.Game.Duck.performed += ctx => StartCoroutine(PhaseThroughPlatform());
    }

    //Called after awake or whenever the script is enabled
    private void OnEnable()
    {
        //Enables the Game Ipnut action map so this script can detect certain inputs
        playerControls.Game.Enable();
    }

    //Called whenever the script is disabled
    private void OnDisable()
    {
        //Disables the Gampe input action map
        playerControls.Game.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //Calls Flip Player
        FlipPlayer();

        //Calls the CheckWallSlide method
        CheckWallSlide();

        //Checks for ground if the player is in the air
        if (jumpCount != 0)
        {
            CheckForGround();
        }

    }

    //FixedUpdate is called 50 times a second, no matter the framerate
    private void FixedUpdate()
    {
        //Moves the player in the x axis depending on the variable xMovement and the character's movement speed.
        //This is done in FixedUpdate Instead of Upadate to make the movement smoother
        xMovement = playerControls.Game.XMovement.ReadValue<float>();
        transform.position += new Vector3(xMovement, 0, 0) * movementSpeed;
        //Sets the animation paramter speed to the characters's X velocity in order to correctly play animations
        animator.SetFloat("Speed", Mathf.Abs(xMovement));
    }

    //Turns the player's collider into a trigger so they are not affected by the platforms and can phase through them
    //Can still be hit by attacks
    //IEnumerator lets me wait between executing different lines
    private IEnumerator PhaseThroughPlatform()
    {
        //Overlap circle makes a circle from a determied point and checks what is in it's radius
        //Checks to see if the player is on ground which can be phased through
        if (Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer) == true)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            //Waits for 0.4 seconds
            yield return new WaitForSeconds(0.5f);
            //Then turns the trigger back to false
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    //Used to check is the player is touching a wall and wallsliding
    private void CheckWallSlide()
    {
        //Overlap circle makes a circle from a determied point and checks what is in it's radius
        //Here it is trying to find a wall to slide on
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, checkRadius, wallJumpLayer);
        //If the player is touching a wall and running into it
        if (isTouchingWall && isGrounded == false && xMovement != 0)
        {
            //WallSlide is called
            WallSlide();
        }
        else
        {
            //They are not wall sliding the the boolean is set to false
            isWallSliding = false;
        }
    }

    //Performs a wall slide
    private void WallSlide()
    {
        //Sets the boolean to true
        isWallSliding = true;
        //Resets the jump count
        jumpCount = 0;
        //Sets their y velocity to stay between a certain range
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, Mathf.Clamp(rigidBody.velocity.y, -wallSlidingSpeed, float.MaxValue));
    }

    //Flips player sprite so it faces the direction of movement
    private void FlipPlayer()
    {
        if (xMovement > 0)
        {
            transform.rotation =  Quaternion.Euler(0, YRotation + 180,0);
        }
        else if (xMovement < 0)
        {
            transform.rotation = Quaternion.Euler(0, YRotation, 0);
        }
    }

    private void PlayerJump()
    {
        if (jumpCount < 2)
        {
            
            //Increases jump count to make sure the player can only jump twice before having to land again
            jumpCount += 1;
            //Plays the jumping animation
            animator.SetTrigger("Jump");
            animator.SetBool("IsJumping", true);

            //Sets their velocity to 0 to make the jump overcome any gravity effects and make double jumps more consistent
           rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);

            //If the player is wall sliding so a different force is added to the character
            if (isWallSliding)
            {
                rigidBody.AddForce(new Vector2(xWallJumpForce * -xMovement, yWallJumpForce), ForceMode2D.Impulse);
            }
            //Checks whether the jump is the player's second or first jump and adds a force upwards depending
            else if (jumpCount == 1)
            {
                rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            else
            {
                rigidBody.AddForce(new Vector2(0, doubleJumpForce), ForceMode2D.Impulse);
            }
        }

    }

    //Checks for ground using an overlap circle
    private void CheckForGround()
    {
        //Overlap circle makes a circle from a determied point and checks what is in it's radius
        //Has to check for 2 different types of platforms
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGrounded == false)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, wallJumpLayer);
        }
    }



    //On OnCollisionEnter2D is called whenever the object collides (touches) another obejct in the game
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checkforground is called
        //This checks whether the character is on the ground
        CheckForGround();
        //If the player is grounded, jump count is set to 0
        if(isGrounded)
        {
            jumpCount = 0;
            //Ends the jumping animation
            animator.SetBool("IsJumping", false);
        }
    }



    //On OnCollisionExit2D is called whenever the object stops touchinng another object
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Checkforground is called
        //This checks whether the character is in the air without jumping and makes sure they cannot double jump
        CheckForGround();
        //If this is the case
        if (jumpCount == 0 && isGrounded == false)
        {
            //Jump count is set to 1
            jumpCount = 1;
            //Plays the jumping animation
            animator.SetTrigger("Jump");
            animator.SetBool("IsJumping", true);
        }
    }
        //Draws a circle around the attack point to easily see and change the attack range
    //Only used when developing the game
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
