using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpinAttack : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;

    [Header("Player Variables")]
    [SerializeField] private int spinDamage;
    [SerializeField] private float knockForceX;
    [SerializeField] private float knockForceY;

    [Header("Player Links")]
    [SerializeField] private Transform spinPoint1;
    [SerializeField] private Transform spinPoint2;
    [SerializeField] private LayerMask enemyLayers;

    void Start()
    {
        //Sets the variables rigidBody and animator to the character's Rigibody2D and Animator Components in order to easily access variables
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Detects whether the attack button was pressed and the calls SpinAttack 
        //The shield has to be off
        if (Input .GetButtonDown("Fire2") && GetComponent<PlayerShield>().isShieldOn == false && GetComponent<KnockBackEffect>().isKnockedBack == false)
        {
            StartCoroutine(SpinAttack());
        }
    }

    private IEnumerator SpinAttack()
    {
        //Detects any enemies inside the attack range
        Collider2D[] hitEnemies = Physics2D.OverlapAreaAll(spinPoint1.position, spinPoint2.position, enemyLayers);

        //Calls the TakeDamage sub-routine in each of the attacked players' PlayerHealth Script
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy != gameObject)
            {
                enemy.GetComponent<PlayerHealth>().TakeDamage(spinDamage, gameObject, knockForceX, knockForceY);
            }
        }

        //Animations begin
        //Not an actual animation so all of the follwoing is needed
        transform.rotation = Quaternion.Euler(0, 0, 0);
        animator.SetTrigger("Spin");
        yield return new WaitForSeconds(0.05f);
        transform.rotation = Quaternion.Euler(0, 180, 0);
        animator.SetTrigger("Spin");
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
