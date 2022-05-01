using UnityEngine;
using Cinemachine;

public class Meteor : MonoBehaviour
{
    [SerializeField] int meteorDamage;
    [SerializeField] float knockForceX, knockForceY, knockBackTime;
    [SerializeField] bool isSnowMeteor;
    [SerializeField] GameObject fire;
    private CinemachineTargetGroup targetGroup;

    // Start is called before the first frame update
    private void Start()
    {
        //Calls the AddToTargetGroup method
        AddToTargetGroup();
    }

    //Detects when the meteor collides with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Tries to find a player health script in the collider
        PlayerHealth playerHealth = collision.collider.gameObject.GetComponent<PlayerHealth>();
        //If the collider was a player
        if (playerHealth != null)
        {
            //Deals damage to the player
            playerHealth.TakeDamage(meteorDamage, gameObject, knockForceX, knockForceY, knockBackTime);
            //If the meteor is a snow meteor
            if (isSnowMeteor)
            {
                //Calls the FreezePlayer method in the snow meteor script
                StartCoroutine(gameObject.GetComponent<SnowMeteor>().FreezePlayer(collision.gameObject));
            }
            //If the meteor is a normal meteor
            else
            {
                //Detroys the game object
                Destroy(gameObject);
            }
        }
        //If the collider wasn't a player and the meteor is a normal meteor
        else if(playerHealth == null && !isSnowMeteor)
        {
            //Instantiates a fire at the point of impact
            GameObject newFire = Instantiate(fire, transform.position, Quaternion.identity);
            //Scales the fire up to make it larger than a fire from the archer's arrow
            newFire.transform.localScale = new Vector2(7.761333f, 7.761333f);
            //Destroys the meteor gameobject
            Destroy(gameObject);
        }
        //If the collider wasn't a player and the meteor is a snow meteor
        else
        {
            //Destroys the snow meteor game object
            Destroy(gameObject);
        }
        //Calls the remove from target group method
        RemoveFromTargetGroup();
        
    }

    //Removes the meteor from the camera target group
    private void RemoveFromTargetGroup()
    {
        //Checks to see that the targetgroup is not null and the powerup is a part of it
        if (targetGroup.FindMember(gameObject.transform) != -1 && targetGroup != null)
        {
            //Removes the powerup from the camera target group
            targetGroup.RemoveMember(gameObject.transform);
        }
    }

    //Adds the meteor to the camera target group and sets the weight and radius
    private void AddToTargetGroup()
    {
        targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        targetGroup.AddMember(gameObject.transform, 1, 1);
    }
}
