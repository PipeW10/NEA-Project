using System.Collections;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;

    [Header("Player Variables")]
    [SerializeField] private int rayDamage;
    [SerializeField] private float knockForceX;
    [SerializeField] private float knockForceY;

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
    }

    // Update is called once per frame
    void Update()
    {
        //Detects whether the attack button was pressed and the calls Laser Attack 
        //The shield has to be off
        if (Input.GetButtonDown("Fire2") && GetComponent<PlayerShield>().isShieldOn == false && GetComponent<KnockBackEffect>().isKnockedBack == false)
        {
            StartCoroutine(FireLaser());
        }
    }

    private IEnumerator FireLaser()
    {
        //Raycast 2D finds the closest object directly in front of where it starts
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        //Plays attack animation
        animator.SetTrigger("Attack");
        //Sets the player y velocity to 0
        rigidBody.velocity = Vector2.zero;
        //If hitInfo is not null (something was hit)
        if (hitInfo)
        {
            //Player health script found on the object
            PlayerHealth rayTargetHealth = hitInfo.transform.GetComponent<PlayerHealth>();

            //If a health script was foun
            if(rayTargetHealth != null)
            {
                //Take damage is called on the object hit
                rayTargetHealth.TakeDamage(rayDamage, gameObject, knockForceX, knockForceY);
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

        //Laser line enabled then disabled 0.02 seconds later
        laserLine.enabled = true;
        yield return new WaitForSeconds(0.02f);
        laserLine.enabled = false;
    }
}
