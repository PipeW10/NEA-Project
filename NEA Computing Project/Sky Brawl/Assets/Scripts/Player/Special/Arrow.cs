using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [Header("Arrow Varibles")]
    [SerializeField] private float arrowSpeed;
    [SerializeField] private int arrowDamage;
    [SerializeField] private float knockForceX;
    [SerializeField] private float knockForceY;
    [SerializeField] private float knockBackTime;
    [SerializeField] private bool isStickyArrow;

    [Header("Object Links")]
    [SerializeField] private GameObject arrowPlayerImpact;
    [SerializeField] private GameObject arrowMapImpact;
    [HideInInspector] public GameObject shooter;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the variable rigidBody arrrow's Rigibody2D in order to easily access the variable
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(transform.right * arrowSpeed);
    }

    //Detects when arrow collides with anything
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (shooter != collider.gameObject && collider.gameObject.layer != 8)
        {
            //Sets the collider's PlayerHealth script (if they have one) to colliderHealth
            PlayerHealth colliderHealth = collider.GetComponent<PlayerHealth>();

            //If a PlayerHealth script is found, the TakeDamage sub-rountine will take place on the collider
            if (colliderHealth != null)
            {
                colliderHealth.TakeDamage(arrowDamage, gameObject, knockForceX, knockForceY, knockBackTime);
                //Creates a bullet impact effect when a collision happens
                Instantiate(arrowPlayerImpact, transform.position, transform.rotation);

                //If the arrow is a Sticky Arrow, the Stick Player Subroutine is called on the StickyArrow script
                if(isStickyArrow)
                {
                    StartCoroutine(gameObject.GetComponent<StickyArrow>().StickPlayer(collider.gameObject));
                }
                //Else the arrow is destroyed
                else
                {
                    //The arrow game object is then destroyed
                    Destroy(gameObject);
                }

            }
            //If the Playerhealth script is not found
            else
            {
                //If the arrow is sticky
                if(isStickyArrow)
                {
                    //A normal impact effect is created
                    Instantiate(arrowMapImpact, transform.position, Quaternion.identity);
                }
                //If the arrow is not sticky
                else
                {
                    //A fire effect is created where the arrow lands and set to the fireEffect variable
                    GameObject fireEffect = Instantiate(arrowMapImpact, new Vector2(transform.position.x, transform.position.y + 0.13f), Quaternion.identity);
                    //The shooter variable in the FireLingerEffect script is set to shooter
                    fireEffect.GetComponentInChildren<FireLingerEffect>().shooter = shooter;
                }
                //The arrow game object is then destroyed
                Destroy(gameObject);
            }
        }
    }
}