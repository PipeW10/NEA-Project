using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [Header("Projectile Varibles")]
    [SerializeField] private float projectileSpeed;
    [SerializeField] private int projectileDamage;
    [SerializeField] private float knockForceX;
    [SerializeField] private float knockForceY;
    [SerializeField] private float knockBackTime;

    [Header("Object Links")]
    [SerializeField] private GameObject projectileImpact;
    [HideInInspector] public GameObject shooter;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the variable rigidBody projectile's Rigibody2D in order to easily access the variable
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce( transform.right * projectileSpeed);
    }

    //Detects when bullet collides with anything
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(shooter != collider.gameObject)
        {
            //Sets the collider's PlayerHealth script (if they have one) to colliderHealth
            PlayerHealth colliderHealth = collider.GetComponent<PlayerHealth>();

            //If a PlayerHealth script is found, the TakeDamage sub-rountine will take place on the collider
            if (colliderHealth != null)
            {
                colliderHealth.TakeDamage(projectileDamage, shooter, knockForceX, knockForceY, knockBackTime);
            }

            //Creates a bullet impact effect when a collision happens
            Instantiate(projectileImpact, transform.position, transform.rotation);
            //The bullet game object is then destroyed
            Destroy(gameObject);
        }
    }
}
