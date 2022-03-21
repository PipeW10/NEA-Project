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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.collider.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(meteorDamage, gameObject, knockForceX, knockForceY, knockBackTime);
            if (isSnowMeteor)
            {
                StartCoroutine(gameObject.GetComponent<SnowMeteor>().FreezePlayer(collision.gameObject));
            }
        }
        else if(playerHealth == null && !isSnowMeteor)
        {
            GameObject newFire = Instantiate(fire, transform.position, Quaternion.identity);
            newFire.transform.localScale = new Vector2(7.761333f, 7.761333f);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        RemoveFromTargetGroup();
        
    }

    //Removes the powerup from the camera target group
    private void RemoveFromTargetGroup()
    {
        //Checks to see that the targetgroup is not null and the powerup is a part of it
        if (targetGroup.FindMember(gameObject.transform) != -1 && targetGroup != null)
        {
            //Removes the powerup from the camera target group
            targetGroup.RemoveMember(gameObject.transform);
        }
    }

    //Adds the powerup to the camera target group and sets the weight and radius
    private void AddToTargetGroup()
    {
        targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        targetGroup.AddMember(gameObject.transform, 1, 1);
    }
}
