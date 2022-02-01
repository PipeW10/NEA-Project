using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [HideInInspector]  public bool isShieldOn = false;

    private float shieldTimer;
    private float shieldConstant;
    private SpriteRenderer sprite;
    private MonoBehaviour playerMovement;
    private MasterControls playerControls;

    [Header("Shield Variables")]
    [SerializeField] private float shieldMaxTime;  
    [SerializeField] private float shieldMaxHealth;
    [SerializeField] private float regenDampener;
    
    private void Start()
    {
        //Sets the variables rigidBody and animator to the character's Controller and Sprite Renderer Components in order to easily access variables
        sprite = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerController>();
        //Sets a constant multiplier to be used to change between the shield timer and health
        shieldConstant = shieldMaxTime * shieldMaxHealth;
        //Sets the shield timer and health to the values they need to be at the start of the match
        shieldTimer = shieldMaxTime;

       
    }

    //First Method to be called in the script
    private void Awake()
    {
        //Sets the playercontrols variable to a reference for the master controls script
        playerControls = new MasterControls();
        //Links Inputs from the Game ipnut action map to specified sub-routines so action may be performed
        playerControls.Game.Shield.performed += ctx => ShieldOn();
        playerControls.Game.Shield.canceled += ctx => ShieldOff();
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
    private void Update()
    {

       /* //If the shield button is held down and the shield is currently off and the timer hasn't surpased the max time allowed, ShieldOn is called
        if (Input.GetButton("Shield") && isShieldOn == false 
            && GetComponent<KnockBackEffect>().isKnockedBack == false 
            && shieldTimer > 0)
        {
            ShieldOn();
        }

        //If the shield button is released and the shield is on ShieldOff is called
        if (Input.GetButtonUp("Shield"))
        {
            ShieldOff();
        }*/

        //If the shield is on, the shield degeneration subroutine is called
        if(isShieldOn)
        {
            ShieldDegeneration();
        }
        //Else the timer is increased by the amount of time elapsed so if the shield is turned on just after it has been used, it doesn't last as long
        else if (shieldTimer < shieldMaxTime )
        {
            //Dampener stops the player from spamming shield too much
            shieldTimer += Time.deltaTime * regenDampener;
        }
    }

    //Makes the shield fade away with time
    private void ShieldDegeneration()
    {
        //Subratcts the time elapsed to the timer
        shieldTimer -= Time.deltaTime;
        
        //If the timer is greater than the maximum shield time allowed the shield is turned off       
        if (shieldTimer <= 0)
        {
            ShieldOff();
        }
        //Else the shield colour slowly fades to white as the timer decreases
        else
        {
            sprite.color = Color.Lerp(Color.white, Color.blue, shieldTimer / shieldMaxTime);
        }
    }

    //Called from the player health script when the player is attacked whilst their shield is on
    public void TakeShieldDamage(int damageDealt)
    {
        shieldTimer -= shieldConstant / damageDealt;
    }

    //Performs shield animations and disables movement
    //Attacks are disbaled on the attack scripts
    public void ShieldOn()
    {
        if (isShieldOn == false && GetComponent<KnockBackEffect>().isKnockedBack == false
            && shieldTimer > 0)
        {
            isShieldOn = true;
            //Changes the player's colour to blue
            sprite.color = Color.blue;
            //Disables player movement
            playerMovement.enabled = false;
        }
    }

    //Enables movement and stops shield animations
    //Attacks are enabled on the attack scripts
    public void ShieldOff()
    {
        isShieldOn = false;
        //Changes the player's colour back to white
        sprite.color = Color.white;
        //Enables player movement
        playerMovement.enabled = true;
    }
}
