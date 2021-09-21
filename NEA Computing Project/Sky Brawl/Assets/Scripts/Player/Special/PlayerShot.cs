using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;

    [Header("Player Links")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectilePrefab;

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
        //Detects whether the attack button was pressed and the calls Shot Attack 
        //The shield has to be off
        if (Input.GetButtonDown("Fire1") && GetComponent<PlayerShield>().isShieldOn == false 
            && GetComponent<KnockBackEffect>().isKnockedBack == false && !Input.GetButton("Jump"))
        {
            FireShot();
        }
    }

    private void FireShot()
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
    }
}
