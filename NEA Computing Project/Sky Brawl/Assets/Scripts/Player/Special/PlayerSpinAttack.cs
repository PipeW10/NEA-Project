using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpinAttack : Player
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    private MasterControls playerControls;
    private bool canAttack;

    [Header("Player Variables")]
    [SerializeField] private int spinDamage;
    [SerializeField] private float knockForceX;
    [SerializeField] private float knockForceY;
    [SerializeField] private float knockBackTime;
    [SerializeField] private float coolDownTime;

    [Header("Player Links")]
    [SerializeField] private Transform spinPoint1;
    [SerializeField] private Transform spinPoint2;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private SpriteRenderer attackRectangle;

    void Start()
    {
        //Sets the variables rigidBody and animator to the character's Rigibody2D and Animator Components in order to easily access variables
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        //Disables the attack rectangle at the start of the match
        attackRectangle.enabled = false;
        canAttack = true;
    }

    //First Method to be called in the script
    private void Awake()
    {
        //Sets the playercontrols variable to a reference for the master controls script
        playerControls = new MasterControls();
        //Links Inputs from the Game ipnut action map to specified sub-routines so action may be performed
        playerControls.Game.Fire2.performed += ctx => StartCoroutine(SpinAttack());
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
        //Detects whether the attack button was pressed and the calls SpinAttack 
        //The shield has to be off
        /*if (Input .GetButtonDown("Fire2") && GetComponent<PlayerShield>().isShieldOn == false && GetComponent<KnockBackEffect>().isKnockedBack == false
            && canAttack)
        {
            StartCoroutine(SpinAttack());
        }*/
        if (canAttack == false)
        {
            canAttack = CoolDownCounter(coolDownTime);
        }
    }

    public IEnumerator SpinAttack()
    {
        if(GetComponent<PlayerShield>().isShieldOn == false && GetComponent<KnockBackEffect>().isKnockedBack == false
            && canAttack)
        {
            //Sets the player's veloctiy to 0
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
        
            //Detects any enemies inside the attack range
            Collider2D[] hitEnemies = Physics2D.OverlapAreaAll(spinPoint1.position, spinPoint2.position, enemyLayers);

            //Calls the TakeDamage sub-routine in each of the attacked players' PlayerHealth Script
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy != gameObject)
                {
                    enemy.GetComponent<PlayerHealth>().TakeDamage(spinDamage, gameObject, knockForceX, knockForceY, knockBackTime);
                }
            }

            //Starts a cool down timer and sets the variables used to the correct values.
            canAttack = false;
            coolDownTimer = 0;
            canAttack = CoolDownCounter(coolDownTime);

            //Animations begin
            //Not an actual animation so all of the follwoing is needed
            attackRectangle.enabled = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetTrigger("Spin");
            yield return new WaitForSeconds(0.05f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetTrigger("Spin");
            yield return new WaitForSeconds(0.15f);
            attackRectangle.enabled = false;
        }
    }

    //Draws out the player's attack range
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(spinPoint1.position, new Vector2(spinPoint2.position.x, spinPoint1.position.y));
        Gizmos.DrawLine(spinPoint1.position, new Vector2(spinPoint1.position.x, spinPoint2.position.y));
        Gizmos.DrawLine(spinPoint2.position, new Vector2(spinPoint1.position.x, spinPoint2.position.y));
        Gizmos.DrawLine(spinPoint2.position, new Vector2(spinPoint2.position.x, spinPoint1.position.y));
    }
}
