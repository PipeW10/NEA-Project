using UnityEngine;

public class UpAttackCircle : MonoBehaviour
{
    [Header("Circle Variables")]
    [SerializeField] int upAttackDamage;
    [SerializeField] float knockForceX, knockForceY;
    [SerializeField] private float knockBackTime;

    [Header("Circle Links")]
    [SerializeField] GameObject attacker;

    private void Start()
    {
        //Sets the circle to false at the beginning of the game
        gameObject.SetActive(false);
    }

    //Called when the circle collides with an object
    private void OnCollisionEnter2D(Collision2D collision)
    {
            //Sets the collider's PlayerHealth script (if they have one) to colliderHealth
            PlayerHealth colliderHealth = collision.gameObject.GetComponent<PlayerHealth>();

            //If a PlayerHealth script is found, the TakeDamage sub-rountine will take place on the collider
            if (colliderHealth != null)
            {
                colliderHealth.TakeDamage(upAttackDamage, attacker, knockForceX, knockForceY, knockBackTime);
            }
    }
}
