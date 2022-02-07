using System.Collections;
using UnityEngine;

public class PlayerLaser : Player
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    //private MasterControls playerControls;
    private bool canAttack;

    [Header("Player Variables")]
    [SerializeField] private int rayDamage;
    [SerializeField] private float knockForceX;
    [SerializeField] private float knockForceY;
    [SerializeField] private float knockBackTime;
    [SerializeField] private float coolDownTime;

    [Header("Player Links")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private LineRenderer laserLine;


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
        //playerControls = new MasterControls();
        //Links Inputs from the Game ipnut action map to specified sub-routines so action may be performed
        //playerControls.Game.Fire2.performed += ctx => StartCoroutine(FireLaser());
    }

    //Called after awake or whenever the script is enabled
    private void OnEnable()
    {
        //Enables the Game Ipnut action map so this script can detect certain inputs
        //playerControls.Game.Enable();
    }

    //Called whenever the script is disabled
    private void OnDisable()
    {
        //Disables the Gampe input action map
        //playerControls.Game.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //Detects whether the attack button was pressed and the calls Laser Attack 
        //The shield has to be off
        /*if (Input.GetButtonDown("Fire2") && GetComponent<PlayerShield>().isShieldOn == false && GetComponent<KnockBackEffect>().isKnockedBack == false
            && canAttack)
        {
            StartCoroutine(FireLaser());
        }*/
        if (canAttack == false)
        {
            canAttack = CoolDownCounter(coolDownTime);
        }
    }

    public IEnumerator FireLaser()
    {
        if (GetComponent<PlayerShield>().isShieldOn == false && GetComponent<KnockBackEffect>().isKnockedBack == false
            && canAttack)
        {
            //Raycast 2D finds the closest object directly in front of where it starts
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
            //Plays attack animation
            animator.SetTrigger("Attack");
            //Sets the player y velocity to 0
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            //If hitInfo is not null (something was hit)
            if (hitInfo)
            {
                //Player health script found on the object
                PlayerHealth rayTargetHealth = hitInfo.transform.GetComponent<PlayerHealth>();

                //If a health script was foun
                if(rayTargetHealth != null)
                {
                    //Take damage is called on the object hit
                    rayTargetHealth.TakeDamage(rayDamage, gameObject, knockForceX, knockForceY, knockBackTime);
                }
                //Impact effect created
                Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
                //Laser start and finish set (from the player's firepoint to the collided object
                laserLine.SetPosition(0, firePoint.position);
                laserLine.SetPosition(1, hitInfo.point);
            }
            //If nothing was hit
            else
            {
                //Laser effect still created but to a point point far away
                laserLine.SetPosition(0, firePoint.position);
                laserLine.SetPosition(1, firePoint.position + firePoint.right * 100);
            }
            //Starts a cool down timer and sets the variables used to the correct values.
            canAttack = false;
            coolDownTimer = 0;
            canAttack = CoolDownCounter(coolDownTime);

            //Laser line enabled then disabled 0.02 seconds later
            laserLine.enabled = true;
            yield return new WaitForSeconds(0.02f);
            laserLine.enabled = false;
        }
    }
}
