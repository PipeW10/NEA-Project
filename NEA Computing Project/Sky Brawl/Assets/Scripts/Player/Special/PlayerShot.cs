using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    private MasterControls playerControls;
    private bool canAttack;
    private float coolDownTimer;

    [Header("Player Variables")]
    [SerializeField] private float coolDownTime;

    [Header("Player Links")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the variables rigidBody and animator to the character's Rigibody2D and Animator Components in order to easily access variables
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        canAttack = true;
    }

    //First Method to be called in the script
    private void Awake()
    {
        //Sets the playercontrols variable to a reference for the master controls script
        playerControls = new MasterControls();
        //Links Inputs from the Game ipnut action map to specified sub-routines so action may be performed
        playerControls.Game.Fire1.performed += ctx => FireShot();
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
        //Detects whether the attack button was pressed and the calls Shot Attack 
        //The shield has to be off
        /*if (Input.GetButtonDown("Fire1") && GetComponent<PlayerShield>().isShieldOn == false 
            && GetComponent<KnockBackEffect>().isKnockedBack == false && !Input.GetButton("Jump")
            && canAttack)
        {
            FireShot();
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

    private void FireShot()
    {
        if(GetComponent<PlayerShield>().isShieldOn == false
            && GetComponent<KnockBackEffect>().isKnockedBack == false && canAttack)
        {
            //Triggers the attack animation
            animator.SetTrigger("Attack");

            //Sets the player's Y velocity to 0 if they are falling so air attacks feel better
            if (rigidBody.velocity.y < 0)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            }

            //Creates a bullet clone from the fire point
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            //Shooter variable in the Arrow script is set to this player
            projectile.GetComponent<Projectile>().shooter = gameObject;
            //Starts a cool down timer and sets the variables used to the correct values.
            canAttack = false;
            coolDownTimer = 0;
            CoolDownCounter();
        }
    }
}
