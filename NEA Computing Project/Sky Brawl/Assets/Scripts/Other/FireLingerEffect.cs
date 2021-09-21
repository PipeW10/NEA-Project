using UnityEngine;
using System.Collections;

public class FireLingerEffect : MonoBehaviour
{
    private float lifeTimer;
    private float tickTimer;

    [Header("Fire Varibles")]
    [SerializeField] private float lifeTime;
    [SerializeField] private float tickTime;
    [SerializeField] private int fireDamage;
    [SerializeField] private float fireRange;

    [Header("Object Links")]
    [SerializeField] private LayerMask enemyLayers;
    [HideInInspector] public GameObject shooter;

    // Update is called once per frame
    void Update()
    {
        //Every frame, the amount of time elapsed is added the the life timer and tick timer variables
        lifeTimer += Time.deltaTime;
        tickTimer += Time.deltaTime;

        //If enough time has elapsed since the fireAttack subroutine was last called, it is called again
        if (tickTimer >= tickTime)
        {
            FireAttack();
        }
        //If the life timer is greater than the lifetime, the fire gameobject is destroyed
        if (lifeTimer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    //Performs the attack animation and detects what the attack collided with
    private void FireAttack()
    {
        //Detects any enemies inside the attack range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, fireRange, enemyLayers);

        //Calls the TakeDamage sub-routine in each of the attacked players' PlayerHealth Script
        foreach (Collider2D enemy in hitEnemies)
        {
            //Makes sure the shooter isn't damaged
            if (enemy.gameObject != shooter)
            {
                enemy.GetComponent<PlayerHealth>().TakeDamage(fireDamage, gameObject, 0, 0);
                //Tick timer is then set to 0
                tickTimer = 0;
            }
        }
    }

    //Draws a circle around the attack point to easily see and change the attack range
    //Only used when developing the game
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, fireRange);
    }
}
